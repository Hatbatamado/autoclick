using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace click
{
    static class Start_Tick
    {
        //mouse click:
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        //---------------------------------------------------
        static Timer time = new Timer();
        static bool run = false;
        static int step_r;
        static int step;
        static int step_glob_r;
        static List<Click> autoclick;
        static TextBox glo_re;

        static public void Start(List<Click> click, TextBox glob_repeat)
        {
            autoclick = click;
            if (autoclick.Count > 0)
            {
                glo_re = glob_repeat;
                time.Tick += time_Tick;
                step = 0;
                step_r = 0;
                step_glob_r = 0;
                //---------------------------------------------------
                if (!run)
                    run = true;
                else
                    run = false;
                //---------------------------------------------------  
                time.Interval = click[step].Delay;
                time.Start();
            }
        }

        static void time_Tick(object sender, EventArgs e)
        {
            if (!run || step == autoclick.Count)
            {
                if (run)
                    run = false;
                time.Stop();
            }
            else
            {
                Cursor.Position = new Point((int)autoclick[step].X, (int)autoclick[step].Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, autoclick[step].X, autoclick[step].Y, 0, 0);
                if (autoclick[step].Repeat > -1)
                {
                    if (autoclick[step].Repeat - 1 == step_r)
                    {
                        step++;
                        step_r = 0;
                        if (step != autoclick.Count)
                        {
                            time.Interval = autoclick[step].Delay;
                            time.Start();
                        }
                        else
                        {
                            if (glo_re.Text == "0")
                            {
                                step = 0;
                                step_r = 0;
                            }
                            else
                            {
                                if (Convert.ToInt32(glo_re.Text) > step_glob_r)
                                {
                                    step = 0;
                                    step_r = 0;
                                    step_glob_r++;
                                }
                                else
                                    step = autoclick.Count;
                            }
                        }
                    }
                    else
                        step_r++;
                }
            }
        }
    }
}
