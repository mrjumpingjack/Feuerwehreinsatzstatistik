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
    public partial class Alarmzeit_Editor : Form
    {
        public Alarmzeit_Editor()
        {
            InitializeComponent();
        }

        private string alarmzeit;
        public string Alarmzeit
        {
            get
            {
                return alarmzeit;
            }
            set
            {
                alarmzeit = value;
            }
        }

        private string einsatzende;
        public string Einsatzende
        {
            get
            {
                return einsatzende;
            }
            set
            {
                einsatzende = value;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateValue = default(DateTime);

            if (DateTime.TryParse(textBox1.Text, out dateValue)&& DateTime.TryParse(textBox2.Text, out dateValue))
            {
                alarmzeit = textBox1.Text;
                einsatzende = textBox2.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Die eingegebenen Werte sind nicht im gültigen Datumsformat (dd.MM.yyyy hh:mm");

            }
              

              
        }

        private void Alarmzeit_Editor_Load(object sender, EventArgs e)
        {
            textBox1.Text = alarmzeit;
            textBox2.Text = einsatzende;
            
        }
    }
}
