using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace click
{
    class GlobalKeys
    {
        static private GlobalKey assign_glob;
        static private GlobalKey start_glob;
        static private GlobalKey add_glob;

        static public void Detect()
        {
            assign_glob = new GlobalKey(Keys.F6, Design.Mainform);
            start_glob = new GlobalKey(Keys.F7, Design.Mainform);
            add_glob = new GlobalKey(Keys.F8, Design.Mainform);
            assign_glob.Register();
            start_glob.Register();
            add_glob.Register();
        }
    }
}
