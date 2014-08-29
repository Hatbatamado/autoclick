using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace click
{
    static class Add_Del_Assign
    {
        static public void Add()
        {
            int X = -1;
            int Y = -1;
            int d = -1;
            int r = -1;
            try
            {
                X = Convert.ToInt32(Design.X.Text);
            }
            catch (FormatException) { }
            try
            {
                Y = Convert.ToInt32(Design.Y.Text);
            }
            catch (FormatException) { }
            try
            {
                d = Convert.ToInt32(Design.Delay.Text);
            }
            catch (FormatException) { }
            try
            {
                r = Convert.ToInt32(Design.Repeat.Text);
            }
            catch (FormatException) { }
            if (X != -1 && Y != -1 && d != -1 && r != -1)
            {
                //--------------------------------------------------- 
                Design.Click.Add(new Click((uint)X, (uint)Y, d, r));
                if (Design.Click.Count == 1)
                    Enable_Disable(0);
                Design.Rt.Text = Design.Rt.Text + Design.Click[Design.Click.Count - 1].Click_Out(Design.Click.Count - 1) + '\n';
                //--------------------------------------------------- 
                Design.Rt.SelectionStart = Design.Rt.Text.Length;
                Design.Rt.ScrollToCaret();
            }
        }

        static public void Del(TextBox del_lane)
        {
            if (del_lane.Text != "*")
            {
                int del = -1;
                try
                {
                    del = Convert.ToInt32(del_lane.Text);
                }
                catch (FormatException)
                { }
                if (del > -1 && Design.Click.Count > del)
                {
                    Design.Click.RemoveAt(del);
                    Design.Rt.Text = "";
                    for (int i = 0; i < Design.Click.Count; i++)
                        Design.Rt.Text = Design.Rt.Text + Design.Click[i].Click_Out(i) + '\n';
                }
            }
            else
            {
                Design.Click.Clear();
                Design.Rt.Text = "";
            }
            if (Design.Rt.Text == "")
                del_lane.Text = "";
            if (Design.Click.Count == 0)
                Enable_Disable(1);
        }

        static public void Assign()
        {
            Design.X.Text = Cursor.Position.X.ToString();
            Design.Y.Text = Cursor.Position.Y.ToString();
        }

        static private void Enable_Disable(int what)
        {
            if (what == 0) // enable
            {
                foreach (Object obj in Design.Mainform.Controls)
                {
                    if (obj is Button && (obj as Button).Name == "Start")
                        (obj as Button).Enabled = true;
                }
            }
            if (what == 1) // disabel
            {
                foreach (Object obj in Design.Mainform.Controls)
                {
                    if (obj is Button && (obj as Button).Name == "Start")
                        (obj as Button).Enabled = false;
                }
            }
        }
    }
}
