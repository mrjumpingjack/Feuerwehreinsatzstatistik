using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fw_statistik.Forms
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string adresse;
        public string Adresse
        {
            get
            {
                return adresse;
            }
            set
            {
                adresse = value;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = adresse;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adresse = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adresse = null;
            Close();
        }
    }
}
