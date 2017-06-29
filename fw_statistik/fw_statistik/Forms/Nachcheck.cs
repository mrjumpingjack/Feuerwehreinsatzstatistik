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
    public partial class Ortsüberprüfung : Form
    {
        public Ortsüberprüfung()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            changed = false;
            Close();
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



  



        //private string addresse; 
        //public string Adresse        
        //{
        //    get
        //    {
        //        return addresse;
        //    }
        //    set
        //    {
        //        addresse = value;
        //    }
        //}

        private bool changed;
        public bool Changed
        {
            get
            {
                return changed;
            }
            set
            {
                changed = value;
            }
        }



        private void Nachcheck_Load(object sender, EventArgs e)
        {
            try
            {
                tbOrt.Text = einsatz.Ges_addresse.Split(',')[1];
            }
            catch
            {

            }
            try
            {
                tbStraße.Text = einsatz.Ges_addresse.Split(',')[0];
            }
            catch
            {

            }
            try
            {
                tbHausnummer.Text = tbStraße.Text.Split(' ')[1];
            }
            catch
            {

            }

            try
            {
                tb_alarmzeit.Text = einsatz.Alarm_datum.ToString();
            }
            catch
            {

            }
            try
            {
                tb_einsatzende.Text = einsatz.End_datum.ToString();
            }
            catch
            {

            }

            
           


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Einsatz.Ges_addresse = tbStraße.Text + " " + tbHausnummer.Text + "," + tbOrt.Text;
            Einsatz.End_datum = DateTime.Parse(tb_einsatzende.Text);
            Einsatz.Alarm_datum = DateTime.Parse(tb_alarmzeit.Text);
            changed = true;
            Close();
        }
    }
}
