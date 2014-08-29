using System;
using System.Windows.Forms;

namespace click
{
    public partial class Form1 : Form
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public Form1()
        {
            InitializeComponent();
            Design.INIT(this, 0);
        }        

        #region Global key functions
        private Keys Getkey(IntPtr LParam)
        {
            return (Keys)((LParam.ToInt32()) >> 16);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
                if ((Getkey(m.LParam)) == Config_Keys("assign"))
                {
                    if (Start_Tick.Run == false)
                        Add_Del_Assign.Assign();
                }
                else if ((Getkey(m.LParam)) == Config_Keys("start"))
                {
                    Start_Tick.Start();
                }
                else if ((Getkey(m.LParam)) == Config_Keys("add"))
                {
                    if (Start_Tick.Run == false)
                        Add_Del_Assign.Add();
                }
            base.WndProc(ref m);
        }

        private Keys Config_Keys(string which)
        {
            switch (which)
            {
                case "assign":
                    return (Keys)Enum.Parse(typeof(Keys), Config.Config_settings("assign").ToString());
                case "start":
                    return (Keys)Enum.Parse(typeof(Keys), Config.Config_settings("start").ToString());
                case "add":
                    return (Keys)Enum.Parse(typeof(Keys), Config.Config_settings("add").ToString());
                default: //placeholder for return
                    return Keys.D0;
            }
        }
        #endregion
    }
}
