using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace click
{
    static class Add_Del_Assign
    {
        static int elements = 0;
        static public void Add(TextBox x, TextBox y, TextBox delay, TextBox repeat,
            List<Click> click, RichTextBox rt)
        {
            int X = -1;
            int Y = -1;
            int d = -1;
            int r = -1;
            try
            {
                X = Convert.ToInt32(x.Text);
            }
            catch (FormatException) { }
            try
            {
                Y = Convert.ToInt32(y.Text);
            }
            catch (FormatException) { }
            try
            {
                d = Convert.ToInt32(delay.Text);
            }
            catch (FormatException) { }
            try
            {
                r = Convert.ToInt32(repeat.Text);
            }
            catch (FormatException) { }
            if (X != -1 && Y != -1 && d != -1 && r != -1)
            {
                //--------------------------------------------------- 
                click.Add(new Click((uint)X, (uint)Y, d, r));
                rt.Text = rt.Text + click[click.Count - 1].Click_Out(elements) + '\n';
                elements++;
                //--------------------------------------------------- 
                rt.SelectionStart = rt.Text.Length;
                rt.ScrollToCaret();
            }
        }

        static public void Del(TextBox del_lane, List<Click> click, RichTextBox rt)
        {
            int del = -1;
            try
            {
                del = Convert.ToInt32(del_lane.Text);
            }
            catch (FormatException)
            { }
            if (del > -1 && click.Count > del)
            {
                click.RemoveAt(del);
                rt.Text = "";
                for (int i = 0; i < click.Count; i++)
                    rt.Text = rt.Text + click[i].Click_Out(i) + '\n';
            }
        }

        static public void Assign(TextBox x, TextBox y)
        {
            x.Text = Cursor.Position.X.ToString();
            y.Text = Cursor.Position.Y.ToString();
        }
    }
}
