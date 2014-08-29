using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace click
{
    class Design
    {
        static private TextBox x;
        public static TextBox X
        {
            get { return Design.x; }
        }
        static private TextBox y;
        public static TextBox Y
        {
            get { return Design.y; }
        }
        static private TextBox delay;

        public static TextBox Delay
        {
            get { return Design.delay; }
        }
        static private TextBox repeat;

        public static TextBox Repeat
        {
            get { return Design.repeat; }
        }
        static private TextBox glob_repeat;
        public static TextBox Glob_repeat
        {
            get { return Design.glob_repeat; }
        }
        static private TextBox del_lane;
        static private TextBox speed;
        static private TextBox swap_b;
        static private TextBox swap_a;
        static private RichTextBox rt;

        public static RichTextBox Rt
        {
            get { return Design.rt; }
        }
        static private Button speed_up;
        static private Button speed_down;
        static private Button swap;
        static private List<Click> click = new List<Click>();
        internal static List<Click> Click
        {
            get { return Design.click; }
            set { Design.click = value; }
        }
        static Form mainform;

        public static Form Mainform
        {
            get { return Design.mainform; }
        }


        static public void INIT(Form form, int what)
        {
            if (what == 0)
            {
                #region design
                //
                //Form:
                //
                mainform = form;
                form.KeyPreview = true; //MUST HAVE for the buttons
                form.Text = "Auto-clicker by Nakia";
                //---------------------------------------------------
                form.Location = new Point(Screen.GetWorkingArea(form).Width - 550, 150);
                form.Size = new Size(450, 525);
                //---------------------------------------------------
                //
                //Menu:
                //
                MenuStrip mainmenu = new MenuStrip();
                //---
                ToolStripMenuItem file = new ToolStripMenuItem("File");
                //---
                ToolStripMenuItem options = new ToolStripMenuItem("Options");
                options.Click += options_Click;
                //---
                ToolStripMenuItem exit = new ToolStripMenuItem("Exit");
                exit.Click += exit_Click;
                //---
                ToolStripMenuItem[] filemenu = { options, exit };
                file.DropDownItems.AddRange(filemenu);
                //---
                mainmenu.Items.Add(file);
                form.Controls.Add(mainmenu);
                //---------------------------------------------------
                //
                //Buttons:
                //
                Button assign = new Button();
                assign = Designn("Assign (F6)", new Point(140, 30), 1, new Size(0, 0));
                assign.Click += assign_Click;
                //---------------------------------------------------
                Button add = new Button();
                add = Designn("Add (F8)", new Point(140, 120), 0, new Size(0, 0));
                add.Click += add_Click;
                //---------------------------------------------------
                Button start = new Button();
                start = Designn("Start (F7)", new Point(275, 120), 2, new Size(0, 0));
                start.BackColor = Color.LightGreen;
                start.Enabled = false;
                start.Click += start_Click;
                //---------------------------------------------------
                Button del_l = new Button();
                del_l = Designn("Delete", new Point(180, 390), -1, new Size(50, 22));
                del_l.Click += del_l_Click;
                //---------------------------------------------------
                speed_up = new Button();
                speed_up = Designn("U", new Point(180, 415), -1, new Size(20, 22));
                speed_up.BackColor = Color.LightSkyBlue;
                speed_up.Click += speed_up_Click;
                //---------------------------------------------------
                speed_down = new Button();
                speed_down = Designn("D", new Point(200, 415), -1, new Size(20, 22));
                speed_down.BackColor = Color.Red;
                speed_down.Click += speed_down_Click;
                //---------------------------------------------------
                Button save = new Button();
                save = Designn("Save", new Point(315, 390), -1, new Size(50, 22));
                save.Click += save_Click;
                //---------------------------------------------------
                Button load = new Button();
                load = Designn("Load", new Point(315, 420), -1, new Size(50, 22));
                load.Click += load_Click;
                //---------------------------------------------------
                Button help = new Button();
                help = Designn("Help", new Point(315, 450), -1, new Size(50, 22));
                help.BackColor = Color.LightBlue;
                help.Click += help_Click;
                //---------------------------------------------------
                swap = new Button();
                swap = Designn("Swap", new Point(180, 440), -1, new Size(50, 22));
                swap.Click += swap_Click;
                //---------------------------------------------------
                //
                //Textboxes:
                //
                x = Designn(new Point(30, 32), new Size(0, 0), "");
                //---------------------------------------------------
                y = Designn(new Point(30, 62), new Size(0, 0), "");
                //---------------------------------------------------
                delay = Designn(new Point(45, 92), new Size(85, 22), "1000");
                //---------------------------------------------------
                repeat = Designn(new Point(45, 122), new Size(85, 22), "1");
                //---------------------------------------------------
                glob_repeat = Designn(new Point(350, 62), new Size(50, 22), "0");
                //---------------------------------------------------
                del_lane = Designn(new Point(140, 392), new Size(35, 22), "");
                //---------------------------------------------------
                speed = Designn(new Point(140, 417), new Size(35, 22), "100");
                //---------------------------------------------------
                swap_b = Designn(new Point(140, 442), new Size(35, 22), "");
                //---------------------------------------------------
                swap_a = Designn(new Point(100, 442), new Size(35, 22), "");
                //---------------------------------------------------
                //
                //Lablels:
                //
                Designn("X:", new Point(10, 35), new Size(0, 0));
                //---------------------------------------------------
                Designn("Y:", new Point(10, 65), new Size(0, 0));
                //---------------------------------------------------
                Designn("delay:", new Point(10, 95), new Size(36, 22));
                //---------------------------------------------------
                Designn("click:", new Point(10, 125), new Size(45, 22));
                //---------------------------------------------------
                Designn("Coordinates:", new Point(95, 164), new Size(75, 16));
                //---------------------------------------------------
                Designn("delay (ms):", new Point(185, 164), new Size(60, 16));
                //---------------------------------------------------
                Designn("click:", new Point(285, 164), new Size(42, 16));
                //---------------------------------------------------
                Designn("Full process run:", new Point(260, 65), new Size(110, 22));
                //---------------------------------------------------
                Designn("No.:", new Point(47, 164), new Size(28, 16));
                //---------------------------------------------------
                Designn("Delete No.:", new Point(75, 395), new Size(62, 22));
                //---------------------------------------------------
                //
                //RichTextBox:
                //
                rt = new RichTextBox();
                form.Controls.Add(rt);
                rt.Location = new Point(50, 180);
                rt.Size = new Size(325, 200);
                rt.ReadOnly = true;
                rt.BackColor = Color.White;
                //---------------------------------------------------
                GlobalKeys.Detect();
                #endregion
            }
            else
            {
                Deny_Allow(what);
            }
        }

        static void exit_Click(object sender, EventArgs e)
        {
            
        }

        static void options_Click(object sender, EventArgs e)
        {
            
        }

        #region Button clicks
        static void add_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Add();
        }

        static void del_l_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Del(del_lane);
        }

        static void assign_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Assign();
        }

        static void save_Click(object sender, EventArgs e)
        {
            Load_Save.Save();
        }

        static void load_Click(object sender, EventArgs e)
        {
            Load_Save.Load();
        }

        static void start_Click(object sender, EventArgs e)
        {
            Start_Tick.Start();
        }

        static void help_Click(object sender, EventArgs e)
        {
            Help.Help_out();
        }

        static void speed_down_Click(object sender, EventArgs e)
        {
            Speed_change(false);
        }

        static void speed_up_Click(object sender, EventArgs e)
        {
            Speed_change(true);
        }

        static void swap_Click(object sender, EventArgs e)
        {
            Swap();
        }
        #endregion

        #region Design functions
        static private Button Designn(string Text, Point Location, int Tabindex, Size Size)
        {
            Button button = new Button();
            mainform.Controls.Add(button);
            button.Text = Text;
            button.Location = Location;
            if (Tabindex != -1)
                button.TabIndex = Tabindex;
            if (Size != new Size(0,0))
                button.Size = Size;

            return button;
        }

        static private TextBox Designn(Point Location, Size Size, string Text)
        {
            TextBox txt = new TextBox();
            mainform.Controls.Add(txt);
            txt.Location = Location;
            if (Size != new Size(0, 0))
                txt.Size = Size;
            if (Text != "")
                txt.Text = Text;

            return txt;
        }

        static private void Designn(string Text, Point Location, Size Size)
        {
            Label label = new Label();
            mainform.Controls.Add(label);
            label.Text = Text;
            label.Location = Location;
            if (Size != new Size(0, 0))
                label.Size = Size;
        }
        #endregion

        static private void Speed_change(bool way)
        {
            if (click.Count > 0)
            {
                int number = 0;
                for (int i = 0; i < click.Count; i++)
                {
                    try
                    {
                        number = Convert.ToInt32(speed.Text);
                    }
                    catch (FormatException) { }
                    if (way) //UP
                        click[i].Delay += number;
                    else // DOWN
                        click[i].Delay -= number;
                    if (click[i].Delay < 0)
                        click[i].Delay = 0;
                }
                rt.Text = "";
                for (int j = 0; j < click.Count; j++)
                    rt.Text += click[j].Click_Out(j) + "\n";
            }
        }

        static private void Swap()
        {
            if (click.Count > 1)
            {
                int a = -2;
                int b = -2;
                Click temp;
                Click temp_b;
                try
                {
                    a = Convert.ToInt32(swap_a.Text);
                }
                catch (FormatException) { }
                try
                {
                    b = Convert.ToInt32(swap_b.Text);
                }
                catch (FormatException) { }
                if (a > -2 && b > -2 && a < click.Count && b < click.Count)
                {
                    if (a != -1 && b != -1)
                    {
                        temp = click[a];
                        click[a] = click[b];
                        click[b] = temp;
                    }
                    else if (a == -1 && b != -1)
                    {
                        temp = click[0];
                        click[0] = click[b];
                        for (int i = 1; i < click.Count; i++)
                        {
                            temp_b = click[i];
                            click[i] = temp;
                            temp = temp_b;
                        }
                    }
                    else if (a != -1 && b == -1)
                    {
                        temp = click[0];
                        click[0] = click[a];
                        for (int i = 1; i < click.Count; i++)
                        {
                            temp_b = click[i];
                            click[i] = temp;
                            temp = temp_b;
                        }
                    }
                }
                rt.Text = "";
                for (int j = 0; j < click.Count; j++)
                    rt.Text += click[j].Click_Out(j) + "\n";
            }
        }

        static private void Deny_Allow(int what)
        {
            if (what == 1) // Started
            {
                foreach (Object obj in mainform.Controls)
                {
                    if (obj is Button && (obj as Button).Text != "Start (F7)")
                        (obj as Button).Enabled = false;
                    else if (obj is Button && (obj as Button).Text == "Start (F7)")
                    {
                        (obj as Button).Text = "Stop (F7)";
                        (obj as Button).BackColor = Color.Red;
                    }
                    else if (obj is TextBox)
                        (obj as TextBox).Enabled = false;
                }
                speed.Visible = false;
                speed_down.Visible = false;
                speed_up.Visible = false;
                swap.Visible = false;
                swap_a.Visible = false;
                swap_b.Visible = false;
            }
            if (what == 2) // Stopped
            {
                foreach (Object obj in mainform.Controls)
                {
                    if (obj is Button && (obj as Button).Text != "Stop (F7)")
                        (obj as Button).Enabled = true;
                    else if (obj is Button && (obj as Button).Text == "Stop (F7)")
                    {
                        (obj as Button).Text = "Start (F7)";
                        (obj as Button).Enabled = true;
                        (obj as Button).BackColor = Color.LightGreen;
                    }
                    else if (obj is TextBox)
                        (obj as TextBox).Enabled = true;
                }
                speed.Visible = true;
                speed_down.Visible = true;
                speed_up.Visible = true;
                swap.Visible = true;
                swap_a.Visible = true;
                swap_b.Visible = true;
            }
        }
    }
}
