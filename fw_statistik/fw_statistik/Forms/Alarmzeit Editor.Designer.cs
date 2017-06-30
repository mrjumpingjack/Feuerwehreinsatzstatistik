namespace fw_statistik
{
    partial class Alarmzeit_Editor
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.l_Alamzeit = new System.Windows.Forms.Label();
            this.tb_alarmzeit = new System.Windows.Forms.TextBox();
            this.tb_einsatzende = new System.Windows.Forms.TextBox();
            this.l_Einsatzende = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(137, 121);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // l_Alamzeit
            // 
            this.l_Alamzeit.AutoSize = true;
            this.l_Alamzeit.Location = new System.Drawing.Point(12, 9);
            this.l_Alamzeit.Name = "l_Alamzeit";
            this.l_Alamzeit.Size = new System.Drawing.Size(49, 13);
            this.l_Alamzeit.TabIndex = 1;
            this.l_Alamzeit.Text = "Alarmzeit";
            // 
            // tb_alarmzeit
            // 
            this.tb_alarmzeit.Location = new System.Drawing.Point(15, 25);
            this.tb_alarmzeit.Name = "tb_alarmzeit";
            this.tb_alarmzeit.Size = new System.Drawing.Size(197, 20);
            this.tb_alarmzeit.TabIndex = 2;
            // 
            // tb_einsatzende
            // 
            this.tb_einsatzende.Location = new System.Drawing.Point(15, 84);
            this.tb_einsatzende.Name = "tb_einsatzende";
            this.tb_einsatzende.Size = new System.Drawing.Size(197, 20);
            this.tb_einsatzende.TabIndex = 4;
            // 
            // l_Einsatzende
            // 
            this.l_Einsatzende.AutoSize = true;
            this.l_Einsatzende.Location = new System.Drawing.Point(12, 68);
            this.l_Einsatzende.Name = "l_Einsatzende";
            this.l_Einsatzende.Size = new System.Drawing.Size(65, 13);
            this.l_Einsatzende.TabIndex = 3;
            this.l_Einsatzende.Text = "Einsatzende";
            // 
            // Alarmzeit_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 156);
            this.Controls.Add(this.tb_einsatzende);
            this.Controls.Add(this.l_Einsatzende);
            this.Controls.Add(this.tb_alarmzeit);
            this.Controls.Add(this.l_Alamzeit);
            this.Controls.Add(this.btn_ok);
            this.Name = "Alarmzeit_Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alarmzeit_Editor";
            this.Load += new System.EventHandler(this.Alarmzeit_Editor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label l_Alamzeit;
        private System.Windows.Forms.TextBox tb_alarmzeit;
        private System.Windows.Forms.TextBox tb_einsatzende;
        private System.Windows.Forms.Label l_Einsatzende;
    }
}