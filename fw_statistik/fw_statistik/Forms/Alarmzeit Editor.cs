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


        public string Alarmzeit { get; set; }

        public string Einsatzende { get; set; }





        private void button1_Click(object sender, EventArgs e)
        {

            SetTimes();


        }

        private void SetTimes()
        {
            DateTime dateValue = default(DateTime);

            if (DateTime.TryParse(tb_alarmzeit.Text, out dateValue) && DateTime.TryParse(tb_einsatzende.Text, out dateValue))
            {
                Alarmzeit = tb_alarmzeit.Text;
                Einsatzende = tb_einsatzende.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Die eingegebenen Werte sind nicht im gültigen Datumsformat (dd.MM.yyyy hh:mm");

            }
        }

        private void Alarmzeit_Editor_Load(object sender, EventArgs e)
        {
            tb_alarmzeit.Text = Alarmzeit;
            tb_einsatzende.Text = Einsatzende;

        }
    }
}
