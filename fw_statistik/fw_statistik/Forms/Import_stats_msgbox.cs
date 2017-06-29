using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fw_statistik
{
    public partial class Import_stats_msgbox : Form
    {
        public Import_stats_msgbox()
        {
            InitializeComponent();
        }

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }


        private void Import_stats_msgbox_Load(object sender, EventArgs e)
        {
            panel1.BackgroundImage = SystemIcons.Asterisk.ToBitmap();
            textBox1.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = "AllYes";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Result = "Yes";
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result = "No";
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result = "AllNo";
            Close();
        }
    }
}
