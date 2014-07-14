using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace click
{
    class GlobalKeys
    {
        static private GlobalKey assign_glob;
        static private GlobalKey start_glob;

        static public void Detect(Form form)
        {
            assign_glob = new GlobalKey(Keys.F6, form);
            start_glob = new GlobalKey(Keys.F7, form);
            assign_glob.Register();
            start_glob.Register();
        }
    }
}
