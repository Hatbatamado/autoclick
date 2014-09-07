using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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
            if (!File.Exists(conf))
                File.Create(conf).Dispose();
            //---
            XmlWriter xw = XmlWriter.Create(conf);

            xw.WriteStartDocument();
            xw.WriteStartElement("Settings");

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", assign.ToString());
            xw.WriteString("Assign");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", assign.ToString());
            xw.WriteString("Add");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", start.ToString());
            xw.WriteString("Start");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", delay.ToString());
            xw.WriteString("Delay");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", click.ToString());
            xw.WriteString("Cick");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", process.ToString());
            xw.WriteString("Process");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", speed.ToString());
            xw.WriteString("Speed");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", oX.ToString());
            xw.WriteString("oX");
            xw.WriteEndElement();

            xw.WriteStartElement("setting");
            xw.WriteStartAttribute("value", oY.ToString());
            xw.WriteString("oY");
            xw.WriteEndElement();

            xw.WriteEndDocument();
            xw.Close();
        }

        static private void Config_Read()
        {
            if (!File.Exists(conf))
                Default();
            else
            {
                XmlReader xmlReader = XmlReader.Create(conf);
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "setting"))
                    {
                        if (xmlReader.HasAttributes)
                        {
                            switch (xmlReader.ReadInnerXml())
                            {
                                case "Assign":
                                    assign = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Add":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Start":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Delay":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Click":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Process":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "Speed":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "oX":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                                case "oY":
                                    add = Convert.ToInt32(xmlReader.GetAttribute("value"));
                                    break;
                            }
                        }
                    }
                }
                xmlReader.Close();
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
    }
}
