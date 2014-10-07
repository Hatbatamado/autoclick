using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace click
{
    class Design
    {
        #region fields
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
        static private Button assign, add, start;
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
        #endregion

        static public void INIT(Form form, int what)
        {
            if (what == 0)
            {
                #region Main design
                //
                //Form:
                //
                mainform = form;
                form.KeyPreview = true; //MUST HAVE for the buttons
                form.Text = "Auto-clicker by Nakia";
                //---------------------------------------------------
                form.StartPosition = FormStartPosition.Manual;
                Screen_check();
                form.Location = new Point(Config.Config_settings("oX"), Config.Config_settings("oY"));
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
                form.MaximizeBox = false;
                form.Size = new Size(450, 505);
                //---------------------------------------------------
                //
                //Menu:
                //
                MenuStrip mainmenu = new MenuStrip();
                //---
                ToolStripMenuItem file = new ToolStripMenuItem("File");
                //---
                ToolStripMenuItem save = new ToolStripMenuItem("Save");
                save.ShortcutKeys = Keys.Control | Keys.S;
                save.Click+=save_Click;
                //---
                ToolStripMenuItem load = new ToolStripMenuItem("Load");
                load.ShortcutKeys = Keys.Control | Keys.L;
                load.Click+=load_Click;
                //---
                ToolStripMenuItem options = new ToolStripMenuItem("Options");
                options.ShortcutKeys = Keys.Control | Keys.O;
                options.Click += options_Click;
                //---
                ToolStripMenuItem exit = new ToolStripMenuItem("Exit");
                exit.ShortcutKeys = Keys.Alt | Keys.F4;
                exit.Click += exit_Click;
                //---
                ToolStripMenuItem[] filemenu = { save, load, options, exit };
                file.DropDownItems.AddRange(filemenu);
                //---
                mainmenu.Items.Add(file);
                //---
                ToolStripMenuItem help = new ToolStripMenuItem("Help");
                //---
                ToolStripMenuItem vhelp = new ToolStripMenuItem("View Help");
                vhelp.ShortcutKeys = Keys.Control | Keys.F1;
                vhelp.Click += help_Click;
                //---
                help.DropDownItems.Add(vhelp);
                //---
                mainmenu.Items.Add(help);
                //---
                form.Controls.Add(mainmenu);
                //---------------------------------------------------
                //
                //Buttons:
                //
                assign = new Button();
                assign = Designn(form, "Assign (" + Button_Names("assign") + ")",
                    new Point(140, 30), 1, new Size(0, 0));
                assign.Click += assign_Click;
                //---------------------------------------------------
                add = new Button();
                add = Designn(form, "Add (" + Button_Names("add") + ")",
                    new Point(140, 120), 0, new Size(0, 0));
                add.Click += add_Click;
                //---------------------------------------------------
                start = new Button();
                start = Designn(form, "Start (" + Button_Names("start") + ")",
                    new Point(275, 120), 2, new Size(0, 0));
                start.BackColor = Color.LightGreen;
                start.Name = "Start";
                start.Enabled = false;
                start.Click += start_Click;
                //---------------------------------------------------
                Button del_l = new Button();
                del_l = Designn(form, "Delete", new Point(180, 390), -1, new Size(50, 22));
                del_l.Click += del_l_Click;
                //---------------------------------------------------
                speed_up = new Button();
                speed_up = Designn(form, "U", new Point(335, 390), -1, new Size(20, 22));
                speed_up.BackColor = Color.LightSkyBlue;
                speed_up.Click += speed_up_Click;
                //---------------------------------------------------
                speed_down = new Button();
                speed_down = Designn(form, "D", new Point(360, 390), -1, new Size(20, 22));
                speed_down.BackColor = Color.Red;
                speed_down.Click += speed_down_Click;
                //---------------------------------------------------
                swap = new Button();
                swap = Designn(form, "Swap", new Point(330, 415), -1, new Size(50, 22));
                swap.Click += swap_Click;
                //---------------------------------------------------
                //
                //Textboxes:
                //
                x = Designn(form, new Point(30, 32), new Size(0, 0), "");
                //---------------------------------------------------
                y = Designn(form, new Point(30, 62), new Size(0, 0), "");
                //---------------------------------------------------
                delay = Designn(form, new Point(45, 92), new Size(85, 22),
                    Config.Config_settings("delay").ToString());
                //---------------------------------------------------
                repeat = Designn(form, new Point(45, 122), new Size(85, 22),
                    Config.Config_settings("click").ToString());
                //---------------------------------------------------
                glob_repeat = Designn(form, new Point(350, 62), new Size(50, 22),
                    Config.Config_settings("process").ToString());
                //---------------------------------------------------
                del_lane = Designn(form, new Point(140, 392), new Size(35, 22), "");
                //---------------------------------------------------
                speed = Designn(form, new Point(290, 392), new Size(35, 22),
                    Config.Config_settings("speed").ToString());
                //---------------------------------------------------
                swap_b = Designn(form, new Point(290, 417), new Size(35, 22), "");
                //---------------------------------------------------
                swap_a = Designn(form, new Point(250, 417), new Size(35, 22), "");
                //---------------------------------------------------
                //
                //Lablels:
                //
                Designn(form, "X:", new Point(10, 35), new Size(0, 0));
                //---------------------------------------------------
                Designn(form, "Y:", new Point(10, 65), new Size(0, 0));
                //---------------------------------------------------
                Designn(form, "delay:", new Point(10, 95), new Size(36, 22));
                //---------------------------------------------------
                Designn(form, "click:", new Point(10, 125), new Size(45, 22));
                //---------------------------------------------------
                Designn(form, "Coordinates:", new Point(95, 164), new Size(75, 16));
                //---------------------------------------------------
                Designn(form, "delay (ms):", new Point(185, 164), new Size(60, 16));
                //---------------------------------------------------
                Designn(form, "click:", new Point(285, 164), new Size(42, 16));
                //---------------------------------------------------
                Designn(form, "Full process run:", new Point(260, 65), new Size(110, 22));
                //---------------------------------------------------
                Designn(form, "No.:", new Point(47, 164), new Size(28, 16));
                //---------------------------------------------------
                Designn(form, "Delete No.:", new Point(75, 395), new Size(62, 22));
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

        static public void Design_Refresh()
        {
            delay.Text = Config.Config_settings("delay").ToString();
            repeat.Text = Config.Config_settings("click").ToString();
            glob_repeat.Text = Config.Config_settings("process").ToString();
            speed.Text = Config.Config_settings("speed").ToString();
            assign.Text = "Assign (" + Button_Names("assign") + ")";
            add.Text = "Add (" + Button_Names("add") + ")";
            start.Text = "Start (" + Button_Names("start") + ")";
            mainform.Location = new Point(Config.Config_settings("oX"),
                Config.Config_settings("oY"));
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

        static void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static void options_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.Show();
        }
        #endregion

        #region Designn functions
        static public Button Designn(Form form, string Text, Point Location, int Tabindex, Size Size)
        {
            Button button = new Button();
            form.Controls.Add(button);
            button.Text = Text;
            button.Location = Location;
            if (Tabindex != -1)
                button.TabIndex = Tabindex;
            if (Size != new Size(0,0))
                button.Size = Size;

            return button;
        }

        static public TextBox Designn(Form form, Point Location, Size Size, string Text)
        {
            TextBox txt = new TextBox();
            form.Controls.Add(txt);
            txt.Location = Location;
            if (Size != new Size(0, 0))
                txt.Size = Size;
            if (Text != "")
                txt.Text = Text;

            return txt;
        }

        static public void Designn(Form form, string Text, Point Location, Size Size)
        {
            Label label = new Label();
            form.Controls.Add(label);
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
                    if (obj is Button && (obj as Button).Name != "Start")
                        (obj as Button).Enabled = false;
                    else if (obj is Button && (obj as Button).Name == "Start")
                    {
                        (obj as Button).Text = "Stop (" + Button_Names("start") + ")";
                        (obj as Button).BackColor = Color.Red;
                    }
                    else if (obj is TextBox)
                        (obj as TextBox).Enabled = false;
                }
            }
            if (what == 2) // Stopped
            {
                foreach (Object obj in mainform.Controls)
                {
                    if (obj is Button && (obj as Button).Name != "Start")
                        (obj as Button).Enabled = true;
                    else if (obj is Button && (obj as Button).Name == "Start")
                    {
                        (obj as Button).Text = "Start (" + Button_Names("start") + ")";
                        (obj as Button).BackColor = Color.LightGreen;
                    }
                    else if (obj is TextBox)
                        (obj as TextBox).Enabled = true;
                }
            }
        }

        static public void Opt_Design(Form form, ref Button assign, ref Button add,
            ref Button start, ref TextBox d, ref TextBox c, ref TextBox p, ref TextBox s,
            ref Button save, ref Button cancel, ref Button defaul, ref TextBox oX, ref TextBox oY)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(Config.Config_settings("oX"), Config.Config_settings("oY"));
            form.Size = new Size(300, 335);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.KeyPreview = true;
            
            //--------------
            Label options = new Label();
            options.Font = new Font("Arial", 12, FontStyle.Bold);
            options.Text = "Options";
            options.Location = new Point(110, 10);
            form.Controls.Add(options);
            //--------------
            //Labels
            Designn(form, "Assign:", new Point(50, 50), new Size(50, 22));
            Designn(form, "Add:", new Point(50, 75), new Size(50, 22));
            Designn(form, "Start:", new Point(50, 100), new Size(50, 22));
            Designn(form, "Delay:", new Point(50, 125), new Size(50, 22));
            Designn(form, "Repeat:", new Point(50, 150), new Size(50, 22));
            Designn(form, "Process:", new Point(50, 175), new Size(50, 22));
            Designn(form, "Speed:", new Point(50, 200), new Size(50, 22));
            Designn(form, "Window location:", new Point(5, 225), new Size(90, 22));
            //--------------
            //Buttons
            assign = new Button();
            assign = Designn(form, Button_Names("assign"),
                new Point(100, 47), -1, new Size(114, 22));            
            //--------------
            add = new Button();
            add = Designn(form, Button_Names("add"),
                new Point(100, 72), -1, new Size(114, 22));            
            //--------------
            start = new Button();
            start = Designn(form, Button_Names("start"),
                new Point(100, 97), -1, new Size(114, 22));            
            //---
            defaul = Designn(form, "Default", new Point(40, 250),
                -1, new Size(60, 22));            
            //---
            save = Designn(form, "Save", new Point(110, 250),
                -1, new Size(60, 22));            
            //---
            cancel = Designn(form, "Cancel", new Point(180, 250),
                -1, new Size(60, 22));
            //--------------
            //Textboxes
            d = Designn(form, new Point(100, 122), new Size(114, 22),
                Config.Config_settings("delay").ToString());
            c = Designn(form, new Point(100, 147), new Size(114, 22),
                Config.Config_settings("click").ToString());
            p = Designn(form, new Point(100, 172), new Size(114, 22),
                Config.Config_settings("process").ToString());
            s = Designn(form, new Point(100, 197), new Size(114, 22),
                Config.Config_settings("speed").ToString());
            oX = Designn(form, new Point(100, 222), new Size(50, 22),
                Config.Config_settings("oX").ToString());
            oY = Designn(form, new Point(160, 222), new Size(50, 22),
                Config.Config_settings("oY").ToString());
        }

        static public void Options_Default(Button assign, Button add, Button start,
            TextBox d, TextBox c, TextBox p, TextBox s, TextBox oX, TextBox oY)
        {
            assign.Text = Button_Names("assign");
            add.Text = Button_Names("add");
            start.Text = Button_Names("start");
            d.Text = Config.Config_settings("delay").ToString();
            c.Text = Config.Config_settings("click").ToString();
            p.Text = Config.Config_settings("process").ToString();
            s.Text = Config.Config_settings("speed").ToString();
            oX.Text = Config.Config_settings("oX").ToString();
            oY.Text = Config.Config_settings("oY").ToString();
        }

        static private string Button_Names(string which)
        {
            switch (which)
            {
                case "assign":
                    return ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("assign").ToString())).ToString();
                case "add":
                    return ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("add").ToString())).ToString();
                case "start":
                    return ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("start").ToString())).ToString();
                default:
                    return "";
            }
        }

        static private void Screen_check()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - 550;
            if (x != Config.Config_settings("oX"))
                Config.Config_Change("oX", x);
        }
    }
}
