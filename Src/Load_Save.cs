using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace click
{
    static class Load_Save
    {
        static public void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files | *.txt";
            sfd.DefaultExt = ".txt";
            sfd.ShowDialog();

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(sfd.FileName);
            }
            catch (ArgumentException) { }
            if (sw != null)
            {
                for (int i = 0; i < Design.Click.Count; i++)
                    sw.WriteLine(Design.Click[i].Click_Out(i));
                sw.Close();
            }
        }

        static public void Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files | *.txt";
            ofd.DefaultExt = ".txt";
            ofd.ShowDialog();

            Design.Click = new List<Click>();
            Design.Rt.Text = "";
            int a = 0;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(ofd.FileName);
            }
            catch (ArgumentException) { }
            if (sr != null)
            {
                while (!sr.EndOfStream)
                {
                    Design.Click.Add(Text_convert(sr.ReadLine()));
                    Design.Rt.Text = Design.Rt.Text + Design.Click[Design.Click.Count - 1].Click_Out(a++) + '\n';
                }
                sr.Close();
            }
        }

        static private Click Text_convert(string a)
        {
            //--------X
            a = a.Substring(a.IndexOf('\t') + 1);
            uint X = Convert.ToUInt32(a.Substring(0, a.IndexOf('-')));
            //--------Y
            string b = a.Substring(a.IndexOf('-') + 1);
            uint Y = Convert.ToUInt32(b.Substring(0, b.IndexOf('\t')));
            //--------d
            a = b.Substring(b.IndexOf("\t\t") + 2);
            int d = Convert.ToInt32(a.Substring(0, a.IndexOf('\t')));
            //--------r
            int r = Convert.ToInt32(a.Substring(a.IndexOf("\t\t")));

            return new Click(X, Y, d, r);
        }
    }
}
