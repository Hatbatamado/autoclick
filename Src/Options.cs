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
            this.KeyDown += Options_KeyDown;
            Button defaul = new Button();
            Button save = new Button();
            Button cancel = new Button();
            Design.Opt_Design(this, ref assign, ref add, ref start, ref d,
                ref c, ref p, ref s, ref save, ref cancel, ref defaul);

            assign.Click += assign_Click;
            add.Click += add_Click;
            start.Click += start_Click;
            defaul.Click += defaul_Click;
            save.Click += save_Click;
            cancel.Click += cancel_Click;
        }

        //Messagebox moving method:
        static public void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
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
            Design.Options_Default(assign, add, start, d, c, p, s);
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalKeys.Detect();
        }
    }
}
