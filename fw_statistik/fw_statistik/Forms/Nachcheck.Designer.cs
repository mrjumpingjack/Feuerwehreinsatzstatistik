namespace fw_statistik
{
    partial class Ortsüberprüfung
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
            this.btnOK = new System.Windows.Forms.Button();
            this.tbOrt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStraße = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHausnummer = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.l_alarmzeit = new System.Windows.Forms.Label();
            this.tb_alarmzeit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_einsatzende = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(306, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbOrt
            // 
            this.tbOrt.Location = new System.Drawing.Point(12, 25);
            this.tbOrt.Name = "tbOrt";
            this.tbOrt.Size = new System.Drawing.Size(367, 20);
            this.tbOrt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ort";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Straße";
            // 
            // tbStraße
            // 
            this.tbStraße.Location = new System.Drawing.Point(12, 62);
            this.tbStraße.Name = "tbStraße";
            this.tbStraße.Size = new System.Drawing.Size(367, 20);
            this.tbStraße.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hausnummer";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbHausnummer
            // 
            this.tbHausnummer.Location = new System.Drawing.Point(12, 97);
            this.tbHausnummer.Name = "tbHausnummer";
            this.tbHausnummer.Size = new System.Drawing.Size(367, 20);
            this.tbHausnummer.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(225, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // l_alarmzeit
            // 
            this.l_alarmzeit.AutoSize = true;
            this.l_alarmzeit.Location = new System.Drawing.Point(12, 120);
            this.l_alarmzeit.Name = "l_alarmzeit";
            this.l_alarmzeit.Size = new System.Drawing.Size(49, 13);
            this.l_alarmzeit.TabIndex = 9;
            this.l_alarmzeit.Text = "Alarmzeit";
            // 
            // tb_alarmzeit
            // 
            this.tb_alarmzeit.Location = new System.Drawing.Point(12, 136);
            this.tb_alarmzeit.Name = "tb_alarmzeit";
            this.tb_alarmzeit.Size = new System.Drawing.Size(182, 20);
            this.tb_alarmzeit.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Einsatzende";
            // 
            // tb_einsatzende
            // 
            this.tb_einsatzende.Location = new System.Drawing.Point(200, 136);
            this.tb_einsatzende.Name = "tb_einsatzende";
            this.tb_einsatzende.Size = new System.Drawing.Size(179, 20);
            this.tb_einsatzende.TabIndex = 10;
            // 
            // Ortsüberprüfung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 264);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_einsatzende);
            this.Controls.Add(this.l_alarmzeit);
            this.Controls.Add(this.tb_alarmzeit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHausnummer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStraße);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOrt);
            this.Controls.Add(this.btnOK);
            this.Name = "Ortsüberprüfung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ortsüberprüfung";
            this.Load += new System.EventHandler(this.Nachcheck_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbOrt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStraße;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHausnummer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label l_alarmzeit;
        private System.Windows.Forms.TextBox tb_alarmzeit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_einsatzende;
    }
}