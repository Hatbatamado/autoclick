using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
        const string conf = "config.conf";

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
            Config_Write();
        }

        static private void Config_Write()
        {           
            if (!File.Exists(conf))
                File.Create(conf).Dispose();
            //---
            StreamWriter sw = new StreamWriter(conf, false);
            sw.WriteLine("Assign:" + assign);
            sw.WriteLine("Add:" + add);
            sw.WriteLine("Start" + start);
            sw.WriteLine("Delay:" + delay);
            sw.WriteLine("Click:" + click);
            sw.WriteLine("Process:" + process);
            sw.WriteLine("Speed:" + speed);
            sw.Close();
        }

        static private void Config_Read()
        {
            string line;
            if (!File.Exists(conf))
                Default();
            else
            {
                StreamReader sr = new StreamReader(conf);
                for (int i = 0; i < 7; i++)
                {
                    line = sr.ReadLine();
                    line = line.Substring(line.IndexOf(':') + 1);
                    try
                    {
                        switch(i)
                        {
                            case 0:
                                assign = Convert.ToInt32(line);
                                break;
                            case 1:
                                add = Convert.ToInt32(line);
                                break;
                            case 2:
                                start = Convert.ToInt32(line);
                                break;
                            case 3:
                                delay = Convert.ToInt32(line);
                                break;
                            case 4:
                                click = Convert.ToInt32(line);
                                break;
                            case 5:
                                process = Convert.ToInt32(line);
                                break;
                            case 6:
                                speed = Convert.ToInt32(line);
                                break;
                        }
                        
                    }
                    catch (FormatException)
                    {
                        switch(i)
                        {
                            case 0:
                                assign = (int)Keys.F6;
                                break;
                            case 1:
                                add = (int)Keys.F8;
                                break;
                            case 2:
                                start = (int)Keys.F7;
                                break;
                            case 3:
                                delay = 1000;
                                break;
                            case 4:
                                click = 1;
                                break;
                            case 5:
                                process = 0;
                                break;
                            case 6:
                                speed = 100;
                                break;                                
                        }
                    }
                }
                sr.Close();
            }
        }
    }
}
