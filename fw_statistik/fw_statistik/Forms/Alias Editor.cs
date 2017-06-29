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
    public partial class Alias_Editor : Form
    {

        public String check_name;

        public List<Alias> aliase;

        Alias curr_alias;

        public Alias_Editor(List<Alias> Aliase,String Name)
        {
            check_name = Name;
            aliase = Aliase;
            InitializeComponent();
        }


        private void Alias_Editor_Load(object sender, EventArgs e)
        {
            l_new.Text = check_name;
            comboBox1.SelectedItem = comboBox1.Items[0];
           
            textBox1.Text = check_name;
            foreach (Alias alias in aliase)
            {
                comboBox1.Items.Add(alias.Name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(curr_alias==null)
            {
                curr_alias = new Alias(comboBox1.Text, new List<string>());
            }
            foreach(String new_alias in textBox1.Text.Split(new[] { Environment.NewLine },StringSplitOptions.None))
            {
                if (new_alias.Length > 1)
                {
                    if (!curr_alias.Aliase.Contains(new_alias))
                    {
                        curr_alias.Aliase.Add(new_alias);
                    }
                }
            }


            if (!aliase.Contains(curr_alias))
            {
                aliase.Add(curr_alias);
            }
            comboBox1.Enabled = true;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            curr_alias = null;
            foreach (Alias a in aliase)
            {
                if (a.Name == comboBox1.Text)
                {
                    curr_alias = a;
                }
            }

            if (curr_alias != null)
            {
                foreach (String al_ in curr_alias.Aliase)
                {
                   
                        textBox1.Text = textBox1.Text + Environment.NewLine + al_;
                   
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
        //   // textBox1.Text = "";
        //    foreach (Manschaftsstatisik.Alias a in aliase)
        //    {
        //        if (a.Name == comboBox1.Name)
        //        {
        //            curr_alias = a;
        //            aliase.Remove(curr_alias);
        //            comboBox1.Enabled = false;
        //            foreach (String al_ in a.Aliase)
        //            {
        //                textBox1.Text = textBox1.Text + Environment.NewLine + al_;
        //            }
        //        }
        //    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + l_new.Text;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Sorted = true;
        }
    }
}
