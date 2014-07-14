using System;
using System.Collections.Generic;
using System.Windows.Forms; 
using System.Runtime.InteropServices;

namespace click
{
    class GlobalKey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        private int modifier = 0x0000;
        private int key;
        private IntPtr hWnd;
        private int id;

        public GlobalKey(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public bool Register()
        {
            return RegisterHotKey(hWnd, id, modifier, key);
        }
    }
}
