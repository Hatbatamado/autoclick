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
            assign_glob = new GlobalKey((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("assign").ToString()), Design.Mainform);
            start_glob = new GlobalKey((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("start").ToString()), Design.Mainform);
            add_glob = new GlobalKey((Keys)Enum.Parse(typeof(Keys),
                Config.Config_settings("add").ToString()), Design.Mainform);
            assign_glob.Register();
            start_glob.Register();
            add_glob.Register();
        }
    }
}
