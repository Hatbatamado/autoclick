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
                switch (Getkey(m.LParam))
                {
                    case Keys.F6:
                        Add_Del_Assign.Assign();
                        break;
                    case Keys.F7:
                        Start_Tick.Start();
                        break;
                    case Keys.F8:
                        Add_Del_Assign.Add();
                        break;
                }
            base.WndProc(ref m);
        }
        #endregion
    }
}
