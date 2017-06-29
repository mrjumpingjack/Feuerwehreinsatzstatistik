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
    public partial class Import_file_msgbox : Form
    {
        public Import_file_msgbox()
        {
            InitializeComponent();
        }


        private Einsatz einsatz;
        public Einsatz Einsatz
        {
            get
            {
                return einsatz;
            }
            set
            {
                einsatz = value;
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

        private void Import_file_msgbox_Load(object sender, EventArgs e)
        {
           textBox1.Text= einsatz.Ges_addresse + " konnte nicht gefunden werden. Wollen Sie jetzt per Hand danach suchen?";
            panel1.BackgroundImage = SystemIcons.Question.ToBitmap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            result = "YesAll";
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "Yes";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            result = "No";
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = "NoAll";
            Close();
        }
    }
}
