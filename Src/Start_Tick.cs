using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace click
{
    class Start_Tick
    {
        //mouse click:
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        //---------------------------------------------------
        static Timer time;
        static bool run;
        static int step_r;
        static int step;
        static int step_glob_r;
        static bool init = false;
        static Label current;
        static int clicks;

        static public void Start()
        {
            Design.INIT(Design.Mainform, 1);
            if (!init)
            {
                time = new Timer();
                time.Tick += time_Tick;
                init = true;
                run = false;
                current = new Label();
                current.Location = new Point(70, 415);
                current.Size = new Size(75, 30);
                Design.Mainform.Controls.Add(current);
            }
            if (Design.Click.Count > 0)
            {                
                step = 0;
                step_r = 0;
                clicks = 0;
                step_glob_r = 1;
                //---------------------------------------------------
                if (!run)
                    run = true;
                else
                    run = false;
                //---------------------------------------------------  
                time.Interval = Design.Click[step].Delay;
                time.Start();
            }
        }

        static void time_Tick(object sender, EventArgs e)
        {
            if (!run || step == Design.Click.Count)
            {
                if (run)
                    run = false;
                time.Stop();
                Design.INIT(Design.Mainform, 2);
                current.Text = "";
            }
            else
            {
                Cursor.Position = new Point((int)Design.Click[step].X, (int)Design.Click[step].Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Design.Click[step].X, Design.Click[step].Y, 0, 0);
                step_r++;
                Current();
                if (Design.Click[step].Repeat == step_r)
                {
                    step++;
                    if (Design.Click.Count > step)
                    {
                        step_r = 0;
                        time.Interval = Design.Click[step].Delay;
                        time.Start();
                    }
                    else
                    {
                        int temp = Convert.ToInt32(Design.Glob_repeat.Text);
                        if (temp == 0)
                        {
                            step = 0;
                            step_r = 0;
                            time.Interval = Design.Click[step].Delay;
                            time.Start();
                        }
                        else if (temp > step_glob_r)
                        {
                            step = 0;
                            step_r = 0;
                            step_glob_r++;
                            time.Interval = Design.Click[step].Delay;
                            time.Start();
                        }
                        else
                            run = false;
                    }
                }
            }
        }

        static void Current()
        {
            clicks++;
            current.Text = "Current: " + (step_glob_r - 1).ToString() + '/' + step + '/' +
                step_r + "\nAll: " + clicks;
        }
    }
}
