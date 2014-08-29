using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace click
{
    public partial class Options : Form
    {
        //TODO: simplify this code and add missing buttons
        public Options()
        {
            InitializeComponent();
            Design();
        }

        Button assign, add, start;
        private void Design()
        {
            //TODO: simplify/change this code for the default button
            this.Location = new Point(Screen.GetWorkingArea(this).Width - 550, 150);
            this.KeyPreview = true;
            this.KeyDown += Options_KeyDown;
            //--------------
            Label options = new Label();
            options.Font = new Font("Arial", 12, FontStyle.Bold);
            options.Text = "Options";
            options.Location = new Point(100, 10);
            this.Controls.Add(options);
            //--------------
            //Labels
            Designn("Assign:", new Point(50, 50), new Size(50, 22));
            Designn("Add:", new Point(50, 75), new Size(50, 22));
            Designn("Start:", new Point(50, 100), new Size(50, 22));
            Designn("Delay:", new Point(50, 125), new Size(50, 22));
            Designn("Repeat:", new Point(50, 150), new Size(50, 22));
            Designn("Process:", new Point(50, 175), new Size(50, 22));
            Designn("Speed:", new Point(50, 200), new Size(50, 22));
            //--------------
            //Buttons
            assign = new Button();
            this.Controls.Add(assign);
            assign.Location = new Point(100, 47);
            assign.Text = ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("assign").ToString())).ToString();
            assign.Size = new Size(114, 22);
            assign.Click += assign_Click;
            //---
            add = new Button();
            this.Controls.Add(add);
            add.Location = new Point(100, 72);
            add.Text = ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("add").ToString())).ToString();
            add.Size = new Size(114, 22);
            add.Click += add_Click;
            //---
            start = new Button();
            this.Controls.Add(start);
            start.Location = new Point(100, 97);
            start.Text = ((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("start").ToString())).ToString();
            start.Size = new Size(114, 22);
            start.Click += start_Click;
            //---
            Button defaul = new Button();
            this.Controls.Add(defaul);
            defaul.Location = new Point(60, 225);
            defaul.Text = "Default";
            defaul.Size = new Size(60, 22);
            defaul.Click += defaul_Click;
            //--------------
            //Textboxes
            TextBox d = Designn(new Point(100, 122), new Size(114, 22),
                Config.Config_settings("delay").ToString());
            TextBox c = Designn(new Point(100, 147), new Size(114, 22),
                Config.Config_settings("click").ToString());
            TextBox p = Designn(new Point(100, 172), new Size(114, 22),
                Config.Config_settings("process").ToString());
            TextBox s = Designn(new Point(100, 197), new Size(114, 22),
                Config.Config_settings("speed").ToString());
        }

        void start_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = "push a button";
            setbutton = 2;
        }

        void add_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = "push a button";
            setbutton = 1;
        }

        int setbutton = -1;
        void assign_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = "push a button";
            setbutton = 0;
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
            Design();
        }

        //TODO: merge these with Design.cs ones
        private void Designn(string Text, Point Location, Size Size)
        {
            Label label = new Label();
            this.Controls.Add(label);
            label.Text = Text;
            label.Location = Location;
            if (Size != new Size(0, 0))
                label.Size = Size;
        }

        private TextBox Designn(Point Location, Size Size, string Text)
        {
            TextBox txt = new TextBox();
            this.Controls.Add(txt);
            txt.Location = Location;
            if (Size != new Size(0, 0))
                txt.Size = Size;
            if (Text != "")
                txt.Text = Text;

            return txt;
        }
    }
}
