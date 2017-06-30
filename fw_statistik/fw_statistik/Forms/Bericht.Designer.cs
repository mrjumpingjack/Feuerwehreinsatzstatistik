namespace fw_statistik
{
    partial class Bericht
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tb_adresse = new System.Windows.Forms.TextBox();
            this.tb_stichwort = new System.Windows.Forms.TextBox();
            this.tb_mzeit = new System.Windows.Forms.TextBox();
            this.tb_meldung = new System.Windows.Forms.TextBox();
            this.tb_ende = new System.Windows.Forms.TextBox();
            this.tb_distanz = new System.Windows.Forms.TextBox();
            this.l_distanz = new System.Windows.Forms.Label();
            this.tb_fehl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_grp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Einsatzstichwort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Einsatzort:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Meldezeit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Einsatzende:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Meldung:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(433, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 277);
            this.listBox1.TabIndex = 11;
            // 
            // tb_adresse
            // 
            this.tb_adresse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_adresse.Location = new System.Drawing.Point(110, 13);
            this.tb_adresse.Name = "tb_adresse";
            this.tb_adresse.ReadOnly = true;
            this.tb_adresse.Size = new System.Drawing.Size(317, 13);
            this.tb_adresse.TabIndex = 12;

            // 
            // tb_stichwort
            // 
            this.tb_stichwort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_stichwort.Location = new System.Drawing.Point(110, 41);
            this.tb_stichwort.Name = "tb_stichwort";
            this.tb_stichwort.ReadOnly = true;
            this.tb_stichwort.Size = new System.Drawing.Size(317, 13);
            this.tb_stichwort.TabIndex = 13;
            // 
            // tb_mzeit
            // 
            this.tb_mzeit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_mzeit.Location = new System.Drawing.Point(110, 73);
            this.tb_mzeit.Name = "tb_mzeit";
            this.tb_mzeit.ReadOnly = true;
            this.tb_mzeit.Size = new System.Drawing.Size(317, 13);
            this.tb_mzeit.TabIndex = 14;

            // 
            // tb_meldung
            // 
            this.tb_meldung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_meldung.Location = new System.Drawing.Point(110, 104);
            this.tb_meldung.Name = "tb_meldung";
            this.tb_meldung.ReadOnly = true;
            this.tb_meldung.Size = new System.Drawing.Size(317, 13);
            this.tb_meldung.TabIndex = 15;

            // 
            // tb_ende
            // 
            this.tb_ende.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ende.Location = new System.Drawing.Point(110, 134);
            this.tb_ende.Name = "tb_ende";
            this.tb_ende.ReadOnly = true;
            this.tb_ende.Size = new System.Drawing.Size(317, 13);
            this.tb_ende.TabIndex = 16;

            // 
            // tb_distanz
            // 
            this.tb_distanz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_distanz.Location = new System.Drawing.Point(110, 181);
            this.tb_distanz.Name = "tb_distanz";
            this.tb_distanz.ReadOnly = true;
            this.tb_distanz.Size = new System.Drawing.Size(317, 13);
            this.tb_distanz.TabIndex = 18;
            // 
            // l_distanz
            // 
            this.l_distanz.AutoSize = true;
            this.l_distanz.Location = new System.Drawing.Point(12, 181);
            this.l_distanz.Name = "l_distanz";
            this.l_distanz.Size = new System.Drawing.Size(45, 13);
            this.l_distanz.TabIndex = 17;
            this.l_distanz.Text = "Distanz:";
            // 
            // tb_fehl
            // 
            this.tb_fehl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_fehl.Location = new System.Drawing.Point(110, 158);
            this.tb_fehl.Name = "tb_fehl";
            this.tb_fehl.ReadOnly = true;
            this.tb_fehl.Size = new System.Drawing.Size(317, 13);
            this.tb_fehl.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Fehl:";
            // 
            // tb_grp
            // 
            this.tb_grp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_grp.Location = new System.Drawing.Point(110, 209);
            this.tb_grp.Name = "tb_grp";
            this.tb_grp.ReadOnly = true;
            this.tb_grp.Size = new System.Drawing.Size(317, 13);
            this.tb_grp.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Gruppen:";
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Location = new System.Drawing.Point(15, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bericht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 328);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb_grp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_fehl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_distanz);
            this.Controls.Add(this.l_distanz);
            this.Controls.Add(this.tb_ende);
            this.Controls.Add(this.tb_meldung);
            this.Controls.Add(this.tb_mzeit);
            this.Controls.Add(this.tb_stichwort);
            this.Controls.Add(this.tb_adresse);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Bericht";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einsatz";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox tb_adresse;
        private System.Windows.Forms.TextBox tb_stichwort;
        private System.Windows.Forms.TextBox tb_mzeit;
        private System.Windows.Forms.TextBox tb_meldung;
        private System.Windows.Forms.TextBox tb_ende;
        private System.Windows.Forms.TextBox tb_distanz;
        private System.Windows.Forms.Label l_distanz;
        private System.Windows.Forms.TextBox tb_fehl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_grp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
    }
}