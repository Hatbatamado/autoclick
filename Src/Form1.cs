using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace click
{
    public partial class Form1 : Form
    {
        //---------------------------------------------------
        #region Mouse and Keys 
        
        //global keypress detection:
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        private GlobalKey assign_glob;
        private GlobalKey start_glob;
        #endregion
        //---------------------------------------------------

        public Form1()
        {
            InitializeComponent();            
            Alap();
        }

        TextBox x, y, repeat, delay, glob_repeat, del_lane;
        RichTextBox rt;
        private void Alap()
        {
            this.KeyPreview = true; //MUST HAVE for the buttons
            //---------------------------------------------------
            #region Layout
            this.Text = "Auto-clicker by Nakia";
            //---------------------------------------------------
            this.Location = new Point(Screen.GetWorkingArea(this).Width - 550, 150);
            this.Size = new Size(450, 500);
            //---------------------------------------------------
            Button assign = new Button();
            Controls.Add(assign);
            assign.Text = "Assign (F6)";
            assign.Location = new Point(140, 10);
            assign.Click += assign_Click;
            assign.TabIndex = 1;
            //---------------------------------------------------
            Button add = new Button();
            Controls.Add(add);
            add.Text = "Add";
            add.Location = new Point(140, 100);
            add.Click += add_Click;
            add.TabIndex = 0;
            //---------------------------------------------------
            Button start = new Button();
            Controls.Add(start);
            start.Text = "Start (F7)";
            start.Location = new Point(275, 100);
            start.TabIndex = 2;
            start.Click += start_Click;
            //---------------------------------------------------
            x = new TextBox();
            Controls.Add(x);
            x.Location = new Point(30, 12);
            //---------------------------------------------------
            y = new TextBox();
            Controls.Add(y);
            y.Location = new Point(30, 42);
            //---------------------------------------------------
            Label xx = new Label();
            Controls.Add(xx);
            xx.Text = "X:";
            xx.Location = new Point(10, 15);
            //---------------------------------------------------
            Label yy = new Label();
            Controls.Add(yy);
            yy.Text = "Y:";
            yy.Location = new Point(10, 45);
            //---------------------------------------------------
            Label del = new Label();
            Controls.Add(del);
            del.Text = "delay:";
            del.Location = new Point(10, 75);
            del.Size = new Size(36, 22);
            //---------------------------------------------------
            delay = new TextBox();
            Controls.Add(delay);
            delay.Location = new Point(55, 72);
            delay.Size = new Size(75, 22);
            delay.Text = "1000";
            //---------------------------------------------------
            Label rep = new Label();
            Controls.Add(rep);
            rep.Text = "Repeat:";
            rep.Location = new Point(10, 105);
            rep.Size = new Size(45, 22);
            //---------------------------------------------------
            repeat = new TextBox();
            Controls.Add(repeat);
            repeat.Location = new Point(55, 102);
            repeat.Size = new Size(75, 22);
            repeat.Text = "1";
            //---------------------------------------------------
            rt = new RichTextBox();
            Controls.Add(rt);
            rt.Location = new Point(50, 160);
            rt.Size = new Size(325, 200);
            //---------------------------------------------------
            Label coord = new Label();
            Controls.Add(coord);
            coord.Text = "Coordinates:";
            coord.Location = new Point(95, 144);
            coord.Size = new Size(75, 22);
            //---------------------------------------------------
            Label de = new Label();
            Controls.Add(de);
            de.Text = "delay (ms):";
            de.Location = new Point(185, 144);
            de.Size = new Size(60, 22);
            //---------------------------------------------------
            Label repe = new Label();
            Controls.Add(repe);
            repe.Text = "repeat:";
            repe.Location = new Point(280, 144);
            //---------------------------------------------------
            Label glob_rep = new Label();
            Controls.Add(glob_rep);
            glob_rep.Text = "Repeat full process:";
            glob_rep.Location = new Point(240, 45);
            glob_rep.Size = new Size(110, 22);
            //---------------------------------------------------
            glob_repeat = new TextBox();
            Controls.Add(glob_repeat);
            glob_repeat.Location = new Point(350, 42);
            glob_repeat.Size = new Size(50, 22);
            glob_repeat.Text = "0";
            //---------------------------------------------------
            Label n0 = new Label();
            Controls.Add(n0);
            n0.Text = "No.:";
            n0.Location = new Point(47, 144);
            //---------------------------------------------------
            Label delete = new Label();
            Controls.Add(delete);
            delete.Text = "Delete No.:";
            delete.Location = new Point(75, 375);
            delete.Size = new Size(62, 22);
            //---------------------------------------------------
            del_lane = new TextBox();
            Controls.Add(del_lane);
            del_lane.Location = new Point(140, 372);
            del_lane.Size = new Size(35, 22);
            //---------------------------------------------------
            Button del_l = new Button();
            Controls.Add(del_l);
            del_l.Text = "Delete";
            del_l.Location = new Point(180, 370);
            del_l.Size = new Size(50, 22);
            del_l.Click += del_l_Click;
            //---------------------------------------------------
            Button save = new Button();
            Controls.Add(save);
            save.Text = "Save";
            save.Location = new Point(315, 370);
            save.Size = new Size(50, 22);
            save.Click += save_Click;
            //---------------------------------------------------
            Button load = new Button();
            Controls.Add(load);
            load.Text = "Load";
            load.Location = new Point(315, 400);
            load.Size = new Size(50, 22);
            load.Click += load_Click;
            #endregion
            //---------------------------------------------------
            assign_glob = new GlobalKey(Keys.F6, this);
            start_glob = new GlobalKey(Keys.F7, this);
            assign_glob.Register();
            start_glob.Register();
        }

        #region Global key functions
        private Keys Getkey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
                switch (Getkey(m.LParam))
                {
                    case Keys.F6:
                        Add_Del_Assign.Assign(x, y);
                        break;
                    case Keys.F7:
                        Start_Tick.Start(click, glob_repeat);
                        break;
                }
            base.WndProc(ref m);
        }
        #endregion

        void start_Click(object sender, EventArgs e)
        {
            Start_Tick.Start(click, glob_repeat);
        }

        int elements = 0;
        void add_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Add(x, y, delay, repeat, click, rt, elements);
        }

        void assign_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Assign(x, y);
        }

        List<Click> click = new List<Click>();

        void del_l_Click(object sender, EventArgs e)
        {
            Add_Del_Assign.Del(del_lane, click, rt);
        }

        void save_Click(object sender, EventArgs e)
        {
            Load_Save.Save(click);
        }

        void load_Click(object sender, EventArgs e)
        {
            click = Load_Save.Load(click, rt);
        }
    }
}
