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
        }

        static public void INIT(Form form)
        {
            #region design
            form.KeyPreview = true; //MUST HAVE for the buttons
            form.Text = "Auto-clicker by Nakia";
            //---------------------------------------------------
            //---------------------------------------------------
            form.Location = new Point(Screen.GetWorkingArea(form).Width - 550, 150);
            form.Size = new Size(450, 500);
            //---------------------------------------------------
            Button assign = new Button();
            form.Controls.Add(assign);
            assign.Text = "Assign (F6)";
            assign.Location = new Point(140, 10);
            assign.Click += assign_Click;
            assign.TabIndex = 1;
            //---------------------------------------------------
            Button add = new Button();
            form.Controls.Add(add);
            add.Text = "Add";
            add.Location = new Point(140, 100);
            add.Click += add_Click;
            add.TabIndex = 0;
            //---------------------------------------------------
            Button start = new Button();
            form.Controls.Add(start);
            start.Text = "Start (F7)";
            start.Location = new Point(275, 100);
            start.TabIndex = 2;
            start.Click += start_Click;
            //---------------------------------------------------
            x = new TextBox();
            form.Controls.Add(x);
            x.Location = new Point(30, 12);
            //---------------------------------------------------
            y = new TextBox();
            form.Controls.Add(y);
            y.Location = new Point(30, 42);
            //---------------------------------------------------
            Label xx = new Label();
            form.Controls.Add(xx);
            xx.Text = "X:";
            xx.Location = new Point(10, 15);
            //---------------------------------------------------
            Label yy = new Label();
            form.Controls.Add(yy);
            yy.Text = "Y:";
            yy.Location = new Point(10, 45);
            //---------------------------------------------------
            Label del = new Label();
            form.Controls.Add(del);
            del.Text = "delay:";
            del.Location = new Point(10, 75);
            del.Size = new Size(36, 22);
            //---------------------------------------------------
            delay = new TextBox();
            form.Controls.Add(delay);
            delay.Location = new Point(55, 72);
            delay.Size = new Size(75, 22);
            delay.Text = "1000";
            //---------------------------------------------------
            Label rep = new Label();
            form.Controls.Add(rep);
            rep.Text = "Repeat:";
            rep.Location = new Point(10, 105);
            rep.Size = new Size(45, 22);
            //---------------------------------------------------
            repeat = new TextBox();
            form.Controls.Add(repeat);
            repeat.Location = new Point(55, 102);
            repeat.Size = new Size(75, 22);
            repeat.Text = "1";
            //---------------------------------------------------
            rt = new RichTextBox();
            form.Controls.Add(rt);
            rt.Location = new Point(50, 160);
            rt.Size = new Size(325, 200);
            //---------------------------------------------------
            Label coord = new Label();
            form.Controls.Add(coord);
            coord.Text = "Coordinates:";
            coord.Location = new Point(95, 144);
            coord.Size = new Size(75, 22);
            //---------------------------------------------------
            Label de = new Label();
            form.Controls.Add(de);
            de.Text = "delay (ms):";
            de.Location = new Point(185, 144);
            de.Size = new Size(60, 22);
            //---------------------------------------------------
            Label repe = new Label();
            form.Controls.Add(repe);
            repe.Text = "repeat:";
            repe.Location = new Point(280, 144);
            //---------------------------------------------------
            Label glob_rep = new Label();
            form.Controls.Add(glob_rep);
            glob_rep.Text = "Repeat full process:";
            glob_rep.Location = new Point(240, 45);
            glob_rep.Size = new Size(110, 22);
            //---------------------------------------------------
            glob_repeat = new TextBox();
            form.Controls.Add(glob_repeat);
            glob_repeat.Location = new Point(350, 42);
            glob_repeat.Size = new Size(50, 22);
            glob_repeat.Text = "0";
            //---------------------------------------------------
            Label n0 = new Label();
            form.Controls.Add(n0);
            n0.Text = "No.:";
            n0.Location = new Point(47, 144);
            //---------------------------------------------------
            Label delete = new Label();
            form.Controls.Add(delete);
            delete.Text = "Delete No.:";
            delete.Location = new Point(75, 375);
            delete.Size = new Size(62, 22);
            //---------------------------------------------------
            del_lane = new TextBox();
            form.Controls.Add(del_lane);
            del_lane.Location = new Point(140, 372);
            del_lane.Size = new Size(35, 22);
            //---------------------------------------------------
            Button del_l = new Button();
            form.Controls.Add(del_l);
            del_l.Text = "Delete";
            del_l.Location = new Point(180, 370);
            del_l.Size = new Size(50, 22);
            del_l.Click += del_l_Click;
            //---------------------------------------------------
            Button save = new Button();
            form.Controls.Add(save);
            save.Text = "Save";
            save.Location = new Point(315, 370);
            save.Size = new Size(50, 22);
            save.Click += save_Click;
            //---------------------------------------------------
            Button load = new Button();
            form.Controls.Add(load);
            load.Text = "Load";
            load.Location = new Point(315, 400);
            load.Size = new Size(50, 22);
            load.Click += load_Click;
            //---------------------------------------------------
            GlobalKeys.Detect(form);
            #endregion
        }

        static void add_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Add(x, y, delay, repeat, click, rt);
        }

        static void del_l_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Del(del_lane, click, rt);
        }

        static void assign_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Assign(x, y);
        }

        static void save_Click(object sender, EventArgs e)
        {
            Load_Save.Save(click);
        }

        static void load_Click(object sender, EventArgs e)
        {
            Load_Save.Load(click, rt);
        }

        static void start_Click(object sender, EventArgs e)
        {
            Start_Tick.Start(click, glob_repeat);
        }
    }
}
