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

        public string Message { get; set; }

        public string Result { get; set; }


        private void Import_stats_msgbox_Load(object sender, EventArgs e)
        {
            panel1.BackgroundImage = SystemIcons.Asterisk.ToBitmap();
            textBox1.Text = Message;
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
