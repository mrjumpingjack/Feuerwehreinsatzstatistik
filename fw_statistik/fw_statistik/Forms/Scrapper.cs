using fw_statistik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Einsatz_scraper
{
    public partial class Scrapper : Form
    {
        public Scrapper()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string save_folder;
        bool Folder_is_set = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Folder_is_set)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    save_folder = folderBrowserDialog1.SelectedPath;
                    Folder_is_set = true;
                }
            }

            using (StreamWriter sw = new StreamWriter(save_folder + "/" + tbanfagszeit.Text.Replace(":", "_") + "_" + tbaddresse.Text.Replace(".", "_").Replace("/", "_") + "_" + tbstichwort.Text + ".XMF"))
            {
                sw.WriteLine(
                   "<stichwort>" + tbstichwort.Text.Replace(Environment.NewLine, ";") + "<stichwort>" + Environment.NewLine +
                   "<addresse>" + tbaddresse.Text.Replace(Environment.NewLine, ";") + "</addresse>" + Environment.NewLine +
                   "<anfang>" + tbanfagszeit.Text.Replace(Environment.NewLine, ";") + "</anfang>" + Environment.NewLine +
                   "<ende>" + tbendzeit.Text.Replace(Environment.NewLine, ";") + "</ende>" + Environment.NewLine +
                   "<art>" + tbart.Text.Replace(Environment.NewLine, ";") + "</art>" + Environment.NewLine +
                   "<dme>" + tbdme.Text.Replace(Environment.NewLine, ";") + "</dme>" + Environment.NewLine +

                   "<" + l1.Text + ">" + tb1.Text.Replace(Environment.NewLine, ";") + "</" + l1.Text + ">" + Environment.NewLine +
                   " < " + l2.Text + " > " + tb2.Text.Replace(Environment.NewLine, "; ") + "</" + l2.Text + ">" + Environment.NewLine +

                    "<" + l3.Text + ">" + tb3.Text.Replace(Environment.NewLine, ";") + "</" + l3.Text + ">" + Environment.NewLine +
                    "<" + l4.Text + ">" + tb4.Text.Replace(Environment.NewLine, ";") + "</" + l4.Text + ">" + Environment.NewLine +

                   "<" + l5.Text + ">" + tb5.Text.Replace(Environment.NewLine, ";") + "</" + l5.Text + ">" + Environment.NewLine +
                    "<" + l6.Text + ">" + tb6.Text.Replace(Environment.NewLine, ";") + "</" + l6.Text + ">" + Environment.NewLine +

                    "<" + l7.Text + ">" + tb7.Text.Replace(Environment.NewLine, ";") + "</" + l7.Text + ">" + Environment.NewLine +

                    "<" + l8.Text + ">" + tb8.Text.Replace(Environment.NewLine, ";") + "</" + l8.Text + ">" + Environment.NewLine +
                    "<" + l9.Text + ">" + tb9.Text.Replace(Environment.NewLine, ";") + "</" + l9.Text + ">" + Environment.NewLine +

                  "<" + l10.Text + ">" + tb10.Text.Replace(Environment.NewLine, ";") + "</" + l10.Text + ">" + Environment.NewLine +
                  "<" + l11.Text + ">" + tb11.Text.Replace(Environment.NewLine, ";") + "</" + l11.Text + ">" + Environment.NewLine +
                  "<" + l12.Text + ">" + tb12.Text.Replace(Environment.NewLine, ";") + "</" + l12.Text + ">" + Environment.NewLine +

                   "<" + l13.Text + ">" + tb13.Text.Replace(Environment.NewLine, ";") + "</" + l13.Text + ">" + Environment.NewLine +
                    "<" + l14.Text + ">" + tb14.Text.Replace(Environment.NewLine, ";") + "</" + l14.Text + ">" + Environment.NewLine +

                    "<Anmerkung>" + tb_anmerkung.Text + "</Anmerkung>" + Environment.NewLine +
                   "<fehl>" + cb_Fehl.Checked.ToString() + "</fehl>");

            }

            tbstichwort.Text = "";
            tbaddresse.Text = "";
            tbanfagszeit.Text = "";
            tbendzeit.Text = "";
            tbart.Text = "";
            tbdme.Text = "";

            tb1.Text = "";
            tb8.Text = "";

            tb3.Text = "";

            tb4.Text = "";
            tb11.Text = "";
            tb13.Text = "";
            tb6.Text = "";

            tb2.Text = "";
            tb9.Text = "";
            tb12.Text = "";
            tb10.Text = "";
            tb7.Text = "";
            tb5.Text = "";
            tb14.Text = "";
            cb_Fehl.Checked = false;




        }
        List<string> fahrzeugnamen = new List<string>();




        private String new_file_path;   
        public String New_file_path  
        {
            get
            {
                return new_file_path;
            }
            set
            {
                new_file_path = value;
            }
        }


        private void Scrapper_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("Fahrzeugnamen.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    fahrzeugnamen.Add(sr.ReadLine());
                }
            }

            l1.Text = fahrzeugnamen[0];
            l2.Text = fahrzeugnamen[1];
            l3.Text = fahrzeugnamen[2];
            l4.Text = fahrzeugnamen[3];
            l5.Text = fahrzeugnamen[4];
            l6.Text = fahrzeugnamen[5];
            l7.Text = fahrzeugnamen[6];
            l8.Text = fahrzeugnamen[7];
            l9.Text = fahrzeugnamen[8];
            l10.Text = fahrzeugnamen[9];
            l11.Text = fahrzeugnamen[10];
            l12.Text = fahrzeugnamen[11];
            l13.Text = fahrzeugnamen[12];
            l14.Text = fahrzeugnamen[13];
        }

        private void laodProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
