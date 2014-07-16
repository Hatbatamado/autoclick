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
        static private TextBox repeat;
        static private TextBox glob_repeat;
        public static TextBox Glob_repeat
        {
            get { return Design.glob_repeat; }
        }
        static private TextBox del_lane;
        static private RichTextBox rt;
        static private List<Click> click = new List<Click>();
        internal static List<Click> Click
        {
            get { return Design.click; }
            set { Design.click = value; }
        }
        static Form mainform;

        static public void INIT(Form form)
        {
            #region design
            mainform = form;
            //---------------------------------------------------
            //
            //Form:
            //
            form.KeyPreview = true; //MUST HAVE for the buttons
            form.Text = "Auto-clicker by Nakia";
            //---------------------------------------------------
            form.Location = new Point(Screen.GetWorkingArea(form).Width - 550, 150);
            form.Size = new Size(450, 500);
            //---------------------------------------------------
            //
            //Buttons:
            //
            Button assign = new Button();
            assign = Designn("Assign (F6)", new Point(140, 10), 1, new Size(0, 0));
            assign.Click += assign_Click; 
            //---------------------------------------------------
            Button add = new Button();
            add = Designn("Add", new Point(140, 100), 0, new Size(0,0));
            add.Click += add_Click;
            //---------------------------------------------------
            Button start = new Button();
            start = Designn("Start (F7)", new Point(275, 100), 2, new Size(0,0));
            start.Click += start_Click;
            //---------------------------------------------------
            Button del_l = new Button();
            del_l = Designn("Delete", new Point(180, 370), -1, new Size(50, 22));
            del_l.Click += del_l_Click;
            //---------------------------------------------------
            Button save = new Button();
            save = Designn("Save", new Point(315, 370), -1, new Size(50, 22));
            save.Click += save_Click;
            //---------------------------------------------------
            Button load = new Button();
            load = Designn("Load", new Point(315, 400), -1, new Size(50, 22));
            load.Click += load_Click;
            //---------------------------------------------------
            //
            //Textboxes:
            //
            x = Designn(new Point(30, 12), new Size(0,0), "");
            //---------------------------------------------------
            y = Designn(new Point(30, 42), new Size(0,0), "");
            //---------------------------------------------------
            delay = Designn(new Point(55, 72), new Size(75, 22), "1000");
            //---------------------------------------------------
            repeat = Designn(new Point(55, 102), new Size(75, 22), "1");
            //---------------------------------------------------
            glob_repeat = Designn(new Point(350, 42), new Size(50, 22), "0");
            //---------------------------------------------------
            del_lane = Designn(new Point(140, 372), new Size(35, 22), "");
            //---------------------------------------------------
            //
            //Lablels:
            //
            Designn("X:", new Point(10, 15), new Size(0,0));
            //---------------------------------------------------
            Designn("Y:", new Point(10, 45), new Size(0, 0));
            //---------------------------------------------------
            Designn("delay:", new Point(10, 75), new Size(36, 22));           
            //---------------------------------------------------
            Designn("Repeat", new Point(10, 105), new Size(45, 22));
            //---------------------------------------------------
            Designn("Coordinates:", new Point(95, 144), new Size(75, 16));
            //---------------------------------------------------
            Designn("delay (ms):", new Point(185, 144), new Size(60, 16));
            //---------------------------------------------------
            Designn("repeat:", new Point(280, 144), new Size(42, 16));
            //---------------------------------------------------
            Designn("Repeat full process:", new Point(240, 45), new Size(110, 22));
            //---------------------------------------------------
            Designn("No.:", new Point(47, 144), new Size(28, 16));
            //---------------------------------------------------
            Designn("Delete No.:", new Point(75, 375), new Size(62, 22));
            //---------------------------------------------------
            //
            //RichTextBox:
            //
            rt = new RichTextBox();
            form.Controls.Add(rt);
            rt.Location = new Point(50, 160);
            rt.Size = new Size(325, 200);  
            //---------------------------------------------------
            GlobalKeys.Detect(form);
            #endregion
        }

        #region Button clicks
        static void add_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Add(delay, repeat, rt);
        }

        static void del_l_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Del(del_lane, rt);
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
            Load_Save.Load(rt);
        }

        static void start_Click(object sender, EventArgs e)
        {
            Start_Tick.Start();
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
    }
}
