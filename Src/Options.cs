using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace click
{
    public partial class Options : Form
    {
        //Messagebox location needs:
        //http://www.codeproject.com/Tips/472294/Position-a-Windows-Forms-MessageBox-in-Csharp
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr classname, string title);
        [DllImport("user32.dll")]
        static extern void MoveWindow(IntPtr hwnd, int X, int Y,
            int nWidth, int nHeight, bool rePaint);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect
            (IntPtr hwnd, out Rectangle rect);

        public Options()
        {
            InitializeComponent();
            Options_Design();
        }

        Button assign, add, start;
        TextBox d, c, p, s;
        private void Options_Design()
        {
            //TODO: simplify/change this code for the default button
            //maybe move these to Design.cs
            this.Location = new Point(Screen.GetWorkingArea(this).Width - 550, 150);
            this.KeyPreview = true;
            this.KeyDown += Options_KeyDown;
            //--------------
            Label options = new Label();
            options.Font = new Font("Arial", 12, FontStyle.Bold);
            options.Text = "Options";
            options.Location = new Point(110, 10);
            this.Controls.Add(options);
            //--------------
            //Labels
            Design.Designn(this, "Assign:", new Point(50, 50), new Size(50, 22));
            Design.Designn(this, "Add:", new Point(50, 75), new Size(50, 22));
            Design.Designn(this, "Start:", new Point(50, 100), new Size(50, 22));
            Design.Designn(this, "Delay:", new Point(50, 125), new Size(50, 22));
            Design.Designn(this, "Repeat:", new Point(50, 150), new Size(50, 22));
            Design.Designn(this, "Process:", new Point(50, 175), new Size(50, 22));
            Design.Designn(this, "Speed:", new Point(50, 200), new Size(50, 22));
            //--------------
            //Buttons
            assign = new Button();
            assign = Design.Designn(this, ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("assign").ToString())).ToString(),
                new Point(100, 47), -1, new Size(114, 22));
            assign.Click += assign_Click;
            //--------------
            add = new Button();
            add = Design.Designn(this, ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("add").ToString())).ToString(),
                new Point(100, 72), -1, new Size(114, 22));
            add.Click += add_Click;
            //--------------
            start = new Button();
            start = Design.Designn(this, ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("start").ToString())).ToString(),
                new Point(100, 97), -1, new Size(114, 22));
            start.Click += start_Click;
            //---
            Button defaul = new Button();
            defaul = Design.Designn(this, "Default", new Point(40, 225),
                -1, new Size(60, 22));
            defaul.Click += defaul_Click;
            //---
            Button save = new Button();
            save = Design.Designn(this, "Save", new Point(110, 225),
                -1, new Size(60, 22));
            save.Click += save_Click;
            //---
            Button cancel = new Button();
            cancel = Design.Designn(this, "Cancel", new Point(180, 225),
                -1, new Size(60, 22));
            cancel.Click += cancel_Click;
            //--------------
            //Textboxes
            d = Design.Designn(this, new Point(100, 122), new Size(114, 22),
                Config.Config_settings("delay").ToString());
            c = Design.Designn(this, new Point(100, 147), new Size(114, 22),
                Config.Config_settings("click").ToString());
            p = Design.Designn(this, new Point(100, 172), new Size(114, 22),
                Config.Config_settings("process").ToString());
            s = Design.Designn(this, new Point(100, 197), new Size(114, 22),
                Config.Config_settings("speed").ToString());
        }

        //Messagebox moving method:
        void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
        {
            Thread thr = new Thread(() => // create a new thread
            {
                IntPtr msgBox = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                // after the while loop, msgBox is the handle of your MessageBox
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r); // Gets the rectangle of the message box
                MoveWindow(msgBox /* handle of the message box */, x, y,
                   r.Width - r.X /* width of originally message box */,
                   r.Height - r.Y /* height of originally message box */,
                   repaint /* if true, the message box repaints */);
            });
            thr.Start(); // starts the thread
        }

        void cancel_Click(object sender, EventArgs e)
        {
            FindAndMoveMsgBox(Screen.GetWorkingArea(this).Width - 575, 225, true, "Cancel");
            DialogResult result =
                MessageBox.Show("Are you sure you want to close this without saving?",
                "Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                this.Close();
            else
            {
                Save();
            }
        }

        void save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (assign.Text == add.Text || assign.Text == start.Text ||
                add.Text == start.Text)
            {
                FindAndMoveMsgBox(Screen.GetWorkingArea(this).Width - 575, 225,
                    true, "Warning");
                MessageBox.Show("Atleast 2 buttons set for the same, please change it",
                    "Warning", MessageBoxButtons.OK);
            }
            else
            {
                Config.Config_Change((Keys)Enum.Parse(typeof(Keys), assign.Text, true),
                    (Keys)Enum.Parse(typeof(Keys), add.Text, true),
                    (Keys)Enum.Parse(typeof(Keys), start.Text, true),
                    d.Text, c.Text, p.Text, s.Text);
                Design.Design_Refresh();
                this.Close();
            }
        }

        void start_Click(object sender, EventArgs e)
        {
            if (!Button_Text(sender as Button))
            {
                (sender as Button).Text = "push a button";
                setbutton = 2;
            }
        }

        void add_Click(object sender, EventArgs e)
        {
            if (!Button_Text(sender as Button))
            {
                (sender as Button).Text = "push a button";
                setbutton = 1;
            }
        }

        int setbutton = -1;
        void assign_Click(object sender, EventArgs e)
        {
            if (!Button_Text(sender as Button))
            {
                (sender as Button).Text = "push a button";
                setbutton = 0;
            }
        }

        Button temp = new Button();
        string b_text = "";
        private bool Button_Text(Button button)
        {            
            if (setbutton == -1)
            {
                temp = button;
                b_text = button.Text;
                return false;
            }
            else
            {
                if (temp.Text == "push a button")
                    temp.Text = b_text;
                setbutton = -1;
                return true;
            }
        }

        void Options_KeyDown(object sender, KeyEventArgs e)
        {
            if (setbutton != -1)
            {
                switch (setbutton)
                {
                    case 0:
                        assign.Text = e.KeyCode.ToString();
                        e.Handled = true;
                        setbutton = -1;
                        break;
                    case 1:
                        add.Text = e.KeyCode.ToString();
                        e.Handled = true;
                        setbutton = -1;
                        break;
                    case 2:
                        start.Text = e.KeyCode.ToString();
                        e.Handled = true;
                        setbutton = -1;
                        break;
                }
            }
        }


        void defaul_Click(object sender, EventArgs e)
        {
            Config.Default();
            this.Controls.Clear(); //TODO: only clear the changeable parts
            Options_Design();
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalKeys.Detect();
        }
    }
}
