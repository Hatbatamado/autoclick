using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace click
{
    class GlobalKeys
    {
        //TODO: find a way to make this sh*t working
        static private GlobalKey assign_glob;

        internal static GlobalKey Assign_glob
        {
            get { return GlobalKeys.assign_glob; }
        }

        static private GlobalKey start_glob;

        internal static GlobalKey Start_glob
        {
            get { return GlobalKeys.start_glob; }
        }
        static private GlobalKey add_glob;

        internal static GlobalKey Add_glob
        {
            get { return GlobalKeys.add_glob; }
        }

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
