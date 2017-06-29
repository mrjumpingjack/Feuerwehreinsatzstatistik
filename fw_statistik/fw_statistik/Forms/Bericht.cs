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
        private Einsatz ein;


        public Bericht(ref Einsatz ein)
        {

            InitializeComponent();
            this.ein = ein;
        }


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


        private void Form2_Load(object sender, EventArgs e)
        {
            Changed =false;
            tb_ende.Text = ein.End_datum.ToString();
            tb_meldung.Text = ein.Art;
            tb_mzeit.Text = ein.Alarm_datum.ToString();
            tb_stichwort.Text = ein.Einsatzstichwort;
            tb_ort.Text = ein.Ges_addresse;
            tb_distanz.Text = Convert.ToString(Math.Round(ein.Route.Distance,2));
            tb_fehl.Text = ein.Fehl.ToString();
            tb_grp.Text = ein.Gruppen;

            listBox1.Items.Clear();
            foreach (Fahrzeug fz in ein.Fahrzeuge)
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

        private void tb_mzeit_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_meldung_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_ort_DoubleClick(object sender, EventArgs e)
        {
            
            

        }

        private void tb_ende_DoubleClick(object sender, EventArgs e)
        {
           // tb_ende.Enabled = true;
        }

        private void tb_mzeit_DoubleClick(object sender, EventArgs e)
        {
           // tb_ende.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ortsüberprüfung op = new Ortsüberprüfung();
            op.Einsatz = this.ein;
            op.Show();

            ein = op.Einsatz;
            changed = true;
        }
    }
}

