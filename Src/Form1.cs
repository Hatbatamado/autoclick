using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace click
{
    public partial class Form1 : Form
    {
        public const int WM_HOTKEY_MSG_ID = 0x0312;

        public Form1()
        {
            InitializeComponent();
            Design.INIT(this);
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
                        Add_Del_Assign.Assign(Design.X, Design.Y);
                        break;
                    case Keys.F7:
                        Start_Tick.Start(Design.Click, Design.Glob_repeat);
                        break;
                }
            base.WndProc(ref m);
        }
        #endregion
    }
}
