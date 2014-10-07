using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace click
{
    class Config
    {
        static int assign;
        static int add;
        static int start;
        static int delay;
        static int click;
        static int process;
        static int speed;
        static int oX, oY;
        const string conf = "config.xml";
        //TODO: simplify codes here

        static public int Config_settings(string what)
        {
            Config_Read(); //all time reading, since it can be modified while running
            switch (what)
            {
                case "assign":
                    return assign;
                case "add":
                    return add;
                case "start":
                    return start;
                case "delay":
                    return delay;
                case "click":
                    return click;
                case "process":
                    return process;
                case "speed":
                    return speed;
                case "oX":
                    return oX;
                case "oY":
                    return oY;
                default:
                    return -1;
            }
        }

        static public void Default()
        {
            //Default settings:
            assign = (int)Keys.F6;
            add = (int)Keys.F8;
            start = (int)Keys.F7;
            delay = 1000;
            click = 1;
            process = 0;
            speed = 100;
            oX = oX = Screen.PrimaryScreen.WorkingArea.Width - 550;
            oY = 150;
            Config_Write();
        }

        static private void Config_Write()
        {           
             XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Settings",

                    new XElement("Setting",
                        new XElement("Name", "Assign"),
                        new XElement("Value", assign)),

                    new XElement("Setting",
                        new XElement("Name", "Add"),
                        new XElement("Value", add)),

                    new XElement("Setting",
                        new XElement("Name", "Start"),
                        new XElement("Value", start)),

                    new XElement("Setting",
                        new XElement("Name", "Delay"),
                        new XElement("Value", delay)),

                    new XElement("Setting",
                        new XElement("Name", "Click"),
                        new XElement("Value", click)),

                        new XElement("Setting",
                        new XElement("Name", "Process"),
                        new XElement("Value", process)),

                    new XElement("Setting",
                        new XElement("Name", "Speed"),
                        new XElement("Value", speed)),

                    new XElement("Setting",
                        new XElement("Name", "oX"),
                        new XElement("Value", oX)),

                    new XElement("Setting",
                        new XElement("Name", "oY"),
                        new XElement("Value", oY))
                    )
                );
             doc.Save(conf);
        }

        static private void Config_Read()
        {
            if (!File.Exists(conf))
                Default();
            else
            {
                XDocument doc = XDocument.Load(conf);
                foreach (XElement element in doc.Descendants("Setting"))
                {
                    switch (element.Element("Name").Value)
                    {
                        case "Assign":
                            assign = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Add":
                            add = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Start":
                            start = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Delay":
                            delay = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Click":
                            click = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Process":
                            process = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "Speed":
                            speed = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "oX":
                            oX = Convert.ToInt32(element.Element("Value").Value);
                            break;
                        case "oY":
                            oY = Convert.ToInt32(element.Element("Value").Value);
                            break;
                    }
                }
            }
        }

        static public void Config_Change(Keys assign1, Keys add1, Keys start1,
            string delay1, string click1, string process1, string speed1, string oX1, string oY1)
        {
            assign = (int)assign1;
            add = (int)add1;
            start = (int)start1;
            delay = Convert.ToInt32(delay1);
            click = Convert.ToInt32(click1);
            process = Convert.ToInt32(process1);
            speed = Convert.ToInt32(speed1);
            oX = Convert.ToInt32(oX1);
            oY = Convert.ToInt32(oY1);
            Config_Write();
        }

        static public void Config_Change(string which, object what)
        {
            switch (which)
            {
                case "assign":
                    assign = (int)what;
                    break;
                case "add":
                    add = (int)what;
                    break;
                case "start":
                    start = (int)what;
                    break;
                case "delay":
                    delay = (int)what;
                    break;
                case "click":
                    click = (int)what;
                    break;
                case "process":
                    process = (int)what;
                    break;
                case "speed":
                    speed = (int)what;
                    break;
                case "oX":
                    oX = (int)what;
                    break;
                case "oY":
                    oY = (int)what;
                    break;
            }
            Config_Write();
        }
    }
}
