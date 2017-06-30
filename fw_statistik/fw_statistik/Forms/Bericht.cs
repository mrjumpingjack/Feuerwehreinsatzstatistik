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
    public partial class Bericht : Form
    {
        public Einsatz einsatz { get; set; }


        public Bericht()
        {

            InitializeComponent();
            
            

        }


        public bool Changed { get; set; }


        private void Form2_Load(object sender, EventArgs e)
        {

            formSetup();

        }

        private void formSetup()
        {
            Changed = false;
            tb_ende.Text = einsatz.End_datum.ToString();
            tb_meldung.Text = einsatz.Art;
            tb_mzeit.Text = einsatz.Alarm_datum.ToString();
            tb_stichwort.Text = einsatz.Einsatzstichwort;
            tb_adresse.Text = einsatz.Adresse.Address;
            tb_distanz.Text = Convert.ToString(Math.Round(einsatz.Route.Distance, 2));
            tb_fehl.Text = einsatz.Fehl.ToString();
            tb_grp.Text = einsatz.Gruppen;

            listBox1.Items.Clear();
            foreach (Fahrzeug fz in einsatz.Fahrzeuge)
            {
                listBox1.Items.Add(fz.Name);
                //listBox1.Items.Add(fz.Gruppenführer);
                foreach (Feuerwehrmann b in fz.Besatzung)
                {
                    if (b.Is_gruppenführer == true)
                    {
                        listBox1.Items.Add(b.Name + "*");
                    }
                    else
                    {
                        listBox1.Items.Add(b.Name);
                    }
                }
                listBox1.Items.Add("____________");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ortsüberprüfung op = new Ortsüberprüfung();
            op.Einsatz = this.einsatz;
            op.Show();

            einsatz = op.Einsatz;
            Changed = true;
        }
    }
}

