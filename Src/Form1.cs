using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace click
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public Form1()
        {
            InitializeComponent();
            
            Alap();
        }

        TextBox x, y, repeat;
        private void Alap()
        {
            this.KeyPreview = true; //MUST HAVE for the buttons
            this.Location = new Point(Screen.GetWorkingArea(this).Width / 2 + 600 / 3, 150);
            this.Size = new Size(600, 500);
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
            add.Location = new Point(140, 40);
            add.Click += add_Click;
            add.TabIndex = 0;
            //---------------------------------------------------
            Button start = new Button();
            Controls.Add(start);
            start.Text = "Start (F7)";
            start.Location = new Point(300, 10);
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
            Label rep = new Label();
            Controls.Add(rep);
            rep.Text = "Repeat:";
            rep.Location = new Point(450, 45);
            rep.Size = new Size(45, 22);
            //---------------------------------------------------
            repeat = new TextBox();
            Controls.Add(repeat);
            repeat.Location = new Point(500, 42);
            repeat.Size = new Size(50, 22);
            repeat.Text = "0";
            //---------------------------------------------------
            this.KeyDown += Form1_KeyDown;
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                Assign();
            else if (e.KeyCode == Keys.F7)
                Start();
        }

        void start_Click(object sender, EventArgs e)
        {
            Start();
        }

        void add_Click(object sender, EventArgs e)
        {
            Add();
        }

        void assign_Click(object sender, EventArgs e)
        {
            Assign();
        }

        private void Assign()
        {
            x.Text = Cursor.Position.X.ToString();
            y.Text = Cursor.Position.Y.ToString();
        }

        private void Start()
        {
            //TODO: forever loop
            //TODO: stop the event
            int db = Convert.ToInt32(repeat.Text);
            do
            {
                Cursor.Position = new Point(Convert.ToInt32(x.Text), Convert.ToInt32(y.Text));
                uint X = (uint)Cursor.Position.X;
                uint Y = (uint)Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
                db--;
                Thread.Sleep(1500);
            } while (db > 0);
            
        }

        private void Add()
        {
            //TODO: ADD table & delay
        }
    }
}
