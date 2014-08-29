using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace click
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            Design();
        }

        private void Design()
        {
            this.Location = new Point(Screen.GetWorkingArea(this).Width - 550, 150);
            //-------
            Label options = new Label();
            options.Font = new Font("Arial", 12, FontStyle.Bold);
            options.Text = "Options";
            options.Location = new Point(100, 10);
            this.Controls.Add(options);
            //-------
            Config.Default();
        }
    }
}
