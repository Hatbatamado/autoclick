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
        static Timer time_le;
        static bool run;
        static int step_r;
        static int step;
        static int step_glob_r;
        static int clicks;
        static int timel;
        static bool init = false;
        static Label current;
        static Label timeleft;

        static public void Start()
        {
            if (!init)
            {
                time = new Timer();
                time.Tick += time_Tick;
                time_le = new Timer();
                time_le.Interval = 100;
                time_le.Tick += time_le_Tick;
                init = true;
                run = false;
                current = new Label();
                current.Location = new Point(70, 420);
                current.Size = new Size(120, 24);
                timeleft = new Label();
                timeleft.Location = new Point(70, 446);
                timeleft.Size = new Size(150, 22);
                Design.Mainform.Controls.Add(current);
                Design.Mainform.Controls.Add(timeleft);
            }
            if (Design.Click.Count > 0)
            {
                Design.INIT(Design.Mainform, 1);
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
                if (run)
                {
                    int check = Design.Click[step].Delay;
                    if (check > 0)
                        time.Interval = check;
                    GlobalKeys.Stop_Detect(false);
                    time.Start();
                    Time_Left();
                }
                else
                {
                    Run_over();
                }
            }
        }

        static void Run_over()
        {
            time.Stop();
            time_le.Stop();
            Design.INIT(Design.Mainform, 2);
            current.Text = "";
            timeleft.Text = "";
            GlobalKeys.Stop_Detect(false);
        }

        static void time_Tick(object sender, EventArgs e)
        {
            if (step == Design.Click.Count)
            {
                Run_over();
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
                        Time_Left();
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
                            Time_Left();
                        }
                        else if (temp > step_glob_r)
                        {
                            step = 0;
                            step_r = 0;
                            step_glob_r++;
                            time.Interval = Design.Click[step].Delay;
                            time.Start();
                            Time_Left();
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

        static void Time_Left()
        {
            if (run)
            {
                timel = Design.Click[step].Delay;
                time_le.Start();
            }
        }

        static void time_le_Tick(object sender, EventArgs e)
        {
            if (run && timel >= 0)
            {
                timeleft.Text = "Time left: " + timel + " ms";
                timel -= 100;
            }
            else
            {
                time_le.Stop();
            }
        }
    }
}
