using System;

namespace fw_statistik
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd_main = new System.Windows.Forms.OpenFileDialog();
            this.ms_main = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addEinsatzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromLastImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mannschaftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brandeinsätzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.technischeHilfeleistungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.übungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCBEinsätze = new System.Windows.Forms.ToolStripComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.l_einsätze_count = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.l_load_error = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_fahrtweg = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_ubungen = new System.Windows.Forms.Label();
            this.l_th_count = new System.Windows.Forms.Label();
            this.l_brand_count = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sstrip_main = new System.Windows.Forms.StatusStrip();
            this.tsPbImportFortschritt = new System.Windows.Forms.ToolStripProgressBar();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.l_ddauer = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.l_dkrafte = new System.Windows.Forms.Label();
            this.l_dkrafte_title = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.l_proTag = new System.Windows.Forms.Label();
            this.ms_main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sstrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofd_main
            // 
            this.ofd_main.Multiselect = true;
            // 
            // ms_main
            // 
            this.ms_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.loadStatsToolStripMenuItem,
            this.ansichtToolStripMenuItem,
            this.tsCBEinsätze});
            this.ms_main.Location = new System.Drawing.Point(0, 0);
            this.ms_main.Name = "ms_main";
            this.ms_main.Size = new System.Drawing.Size(1084, 27);
            this.ms_main.TabIndex = 2;
            this.ms_main.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.addEinsatzToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
            this.openToolStripMenuItem.Text = "Datei";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.openToolStripMenuItem1.Text = "Öffnen";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // addEinsatzToolStripMenuItem
            // 
            this.addEinsatzToolStripMenuItem.Name = "addEinsatzToolStripMenuItem";
            this.addEinsatzToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.addEinsatzToolStripMenuItem.Text = "Einsatz hinzufügen";
            this.addEinsatzToolStripMenuItem.Click += new System.EventHandler(this.addEinsatzToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exportToolStripMenuItem.Text = "Exportieren";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Schließen";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // loadStatsToolStripMenuItem
            // 
            this.loadStatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromLastImportToolStripMenuItem,
            this.mannschaftToolStripMenuItem});
            this.loadStatsToolStripMenuItem.Name = "loadStatsToolStripMenuItem";
            this.loadStatsToolStripMenuItem.Size = new System.Drawing.Size(105, 23);
            this.loadStatsToolStripMenuItem.Text = "Statistiken laden";
            // 
            // fromLastImportToolStripMenuItem
            // 
            this.fromLastImportToolStripMenuItem.Name = "fromLastImportToolStripMenuItem";
            this.fromLastImportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fromLastImportToolStripMenuItem.Text = "Einsätze";
            this.fromLastImportToolStripMenuItem.Click += new System.EventHandler(this.fromLastImportToolStripMenuItem_Click);
            // 
            // mannschaftToolStripMenuItem
            // 
            this.mannschaftToolStripMenuItem.Name = "mannschaftToolStripMenuItem";
            this.mannschaftToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mannschaftToolStripMenuItem.Text = "Mannschaft";
            this.mannschaftToolStripMenuItem.Click += new System.EventHandler(this.mannschaftToolStripMenuItem_Click);
            // 
            // ansichtToolStripMenuItem
            // 
            this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brandeinsätzeToolStripMenuItem,
            this.technischeHilfeleistungToolStripMenuItem,
            this.übungenToolStripMenuItem,
            this.alleToolStripMenuItem});
            this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
            this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.ansichtToolStripMenuItem.Text = "Ansicht";
            // 
            // brandeinsätzeToolStripMenuItem
            // 
            this.brandeinsätzeToolStripMenuItem.Checked = true;
            this.brandeinsätzeToolStripMenuItem.CheckOnClick = true;
            this.brandeinsätzeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.brandeinsätzeToolStripMenuItem.Name = "brandeinsätzeToolStripMenuItem";
            this.brandeinsätzeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.brandeinsätzeToolStripMenuItem.Text = "Brandeinsätze";
            this.brandeinsätzeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.layer_CheckedChanged);
            // 
            // technischeHilfeleistungToolStripMenuItem
            // 
            this.technischeHilfeleistungToolStripMenuItem.Checked = true;
            this.technischeHilfeleistungToolStripMenuItem.CheckOnClick = true;
            this.technischeHilfeleistungToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.technischeHilfeleistungToolStripMenuItem.Name = "technischeHilfeleistungToolStripMenuItem";
            this.technischeHilfeleistungToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.technischeHilfeleistungToolStripMenuItem.Text = "Technische Hilfeleistung";
            this.technischeHilfeleistungToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.layer_CheckedChanged);
            // 
            // übungenToolStripMenuItem
            // 
            this.übungenToolStripMenuItem.Checked = true;
            this.übungenToolStripMenuItem.CheckOnClick = true;
            this.übungenToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.übungenToolStripMenuItem.Name = "übungenToolStripMenuItem";
            this.übungenToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.übungenToolStripMenuItem.Text = "Andere";
            this.übungenToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.layer_CheckedChanged);
            // 
            // alleToolStripMenuItem
            // 
            this.alleToolStripMenuItem.CheckOnClick = true;
            this.alleToolStripMenuItem.Name = "alleToolStripMenuItem";
            this.alleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.alleToolStripMenuItem.Text = "Alle";
            this.alleToolStripMenuItem.Click += new System.EventHandler(this.layer_CheckedChanged);
            // 
            // tsCBEinsätze
            // 
            this.tsCBEinsätze.Name = "tsCBEinsätze";
            this.tsCBEinsätze.Size = new System.Drawing.Size(300, 23);
            this.tsCBEinsätze.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            this.tsCBEinsätze.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(983, 662);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 78);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(56, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "K";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "S";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // l_einsätze_count
            // 
            this.l_einsätze_count.AutoSize = true;
            this.l_einsätze_count.ForeColor = System.Drawing.SystemColors.Control;
            this.l_einsätze_count.Location = new System.Drawing.Point(85, 16);
            this.l_einsätze_count.Name = "l_einsätze_count";
            this.l_einsätze_count.Size = new System.Drawing.Size(10, 13);
            this.l_einsätze_count.TabIndex = 6;
            this.l_einsätze_count.Text = "-";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.l_proTag);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.l_dkrafte);
            this.panel2.Controls.Add(this.l_dkrafte_title);
            this.panel2.Controls.Add(this.l_ddauer);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.l_load_error);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.l_fahrtweg);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.l_ubungen);
            this.panel2.Controls.Add(this.l_th_count);
            this.panel2.Controls.Add(this.l_brand_count);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.l_einsätze_count);
            this.panel2.Location = new System.Drawing.Point(958, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(126, 262);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // l_load_error
            // 
            this.l_load_error.AutoSize = true;
            this.l_load_error.ForeColor = System.Drawing.SystemColors.Control;
            this.l_load_error.Location = new System.Drawing.Point(87, 224);
            this.l_load_error.Name = "l_load_error";
            this.l_load_error.Size = new System.Drawing.Size(10, 13);
            this.l_load_error.TabIndex = 17;
            this.l_load_error.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(5, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nicht geladen:";
            // 
            // l_fahrtweg
            // 
            this.l_fahrtweg.AutoSize = true;
            this.l_fahrtweg.ForeColor = System.Drawing.SystemColors.Control;
            this.l_fahrtweg.Location = new System.Drawing.Point(85, 172);
            this.l_fahrtweg.Name = "l_fahrtweg";
            this.l_fahrtweg.Size = new System.Drawing.Size(10, 13);
            this.l_fahrtweg.TabIndex = 15;
            this.l_fahrtweg.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(3, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ø fahrtweg";
            // 
            // l_ubungen
            // 
            this.l_ubungen.AutoSize = true;
            this.l_ubungen.ForeColor = System.Drawing.SystemColors.Control;
            this.l_ubungen.Location = new System.Drawing.Point(85, 94);
            this.l_ubungen.Name = "l_ubungen";
            this.l_ubungen.Size = new System.Drawing.Size(10, 13);
            this.l_ubungen.TabIndex = 13;
            this.l_ubungen.Text = "-";
            // 
            // l_th_count
            // 
            this.l_th_count.AutoSize = true;
            this.l_th_count.ForeColor = System.Drawing.SystemColors.Control;
            this.l_th_count.Location = new System.Drawing.Point(85, 68);
            this.l_th_count.Name = "l_th_count";
            this.l_th_count.Size = new System.Drawing.Size(10, 13);
            this.l_th_count.TabIndex = 12;
            this.l_th_count.Text = "-";
            // 
            // l_brand_count
            // 
            this.l_brand_count.AutoSize = true;
            this.l_brand_count.ForeColor = System.Drawing.SystemColors.Control;
            this.l_brand_count.Location = new System.Drawing.Point(85, 42);
            this.l_brand_count.Name = "l_brand_count";
            this.l_brand_count.Size = new System.Drawing.Size(10, 13);
            this.l_brand_count.TabIndex = 11;
            this.l_brand_count.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Andere:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Techhilfeleis.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Brandeinsätze";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Einsätze:";
            // 
            // sstrip_main
            // 
            this.sstrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPbImportFortschritt});
            this.sstrip_main.Location = new System.Drawing.Point(0, 740);
            this.sstrip_main.Name = "sstrip_main";
            this.sstrip_main.Size = new System.Drawing.Size(1084, 22);
            this.sstrip_main.TabIndex = 8;
            this.sstrip_main.Text = "statusStrip1";
            // 
            // tsPbImportFortschritt
            // 
            this.tsPbImportFortschritt.Name = "tsPbImportFortschritt";
            this.tsPbImportFortschritt.Size = new System.Drawing.Size(100, 16);
            // 
            // MainMap
            // 
            this.MainMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 30);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomEnabled = true;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(1084, 707);
            this.MainMap.TabIndex = 9;
            this.MainMap.Zoom = 0D;
            this.MainMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.MainMap_OnMarkerClick_1);
            // 
            // l_ddauer
            // 
            this.l_ddauer.AutoSize = true;
            this.l_ddauer.ForeColor = System.Drawing.SystemColors.Control;
            this.l_ddauer.Location = new System.Drawing.Point(85, 120);
            this.l_ddauer.Name = "l_ddauer";
            this.l_ddauer.Size = new System.Drawing.Size(10, 13);
            this.l_ddauer.TabIndex = 21;
            this.l_ddauer.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(3, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ø Dauer";
            // 
            // l_dkrafte
            // 
            this.l_dkrafte.AutoSize = true;
            this.l_dkrafte.ForeColor = System.Drawing.SystemColors.Control;
            this.l_dkrafte.Location = new System.Drawing.Point(85, 146);
            this.l_dkrafte.Name = "l_dkrafte";
            this.l_dkrafte.Size = new System.Drawing.Size(10, 13);
            this.l_dkrafte.TabIndex = 23;
            this.l_dkrafte.Text = "-";
            // 
            // l_dkrafte_title
            // 
            this.l_dkrafte_title.AutoSize = true;
            this.l_dkrafte_title.ForeColor = System.Drawing.SystemColors.Control;
            this.l_dkrafte_title.Location = new System.Drawing.Point(3, 146);
            this.l_dkrafte_title.Name = "l_dkrafte_title";
            this.l_dkrafte_title.Size = new System.Drawing.Size(70, 13);
            this.l_dkrafte_title.TabIndex = 22;
            this.l_dkrafte_title.Text = "Ø Anz. Kräfte";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(5, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pro Tag:";
            // 
            // l_proTag
            // 
            this.l_proTag.AutoSize = true;
            this.l_proTag.ForeColor = System.Drawing.SystemColors.Control;
            this.l_proTag.Location = new System.Drawing.Point(87, 198);
            this.l_proTag.Name = "l_proTag";
            this.l_proTag.Size = new System.Drawing.Size(10, 13);
            this.l_proTag.TabIndex = 25;
            this.l_proTag.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 762);
            this.Controls.Add(this.sstrip_main);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ms_main);
            this.Controls.Add(this.MainMap);
            this.MainMenuStrip = this.ms_main;
            this.MinimumSize = new System.Drawing.Size(1100, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einsatzstatistik";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ms_main.ResumeLayout(false);
            this.ms_main.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sstrip_main.ResumeLayout(false);
            this.sstrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      

        #endregion
        private System.Windows.Forms.OpenFileDialog ofd_main;
        private System.Windows.Forms.MenuStrip ms_main;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromLastImportToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brandeinsätzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem technischeHilfeleistungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem übungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alleToolStripMenuItem;
        private System.Windows.Forms.Label l_einsätze_count;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_ubungen;
        private System.Windows.Forms.Label l_th_count;
        private System.Windows.Forms.Label l_brand_count;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_fahrtweg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_load_error;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip sstrip_main;
        private System.Windows.Forms.ToolStripProgressBar tsPbImportFortschritt;
        private System.Windows.Forms.ToolStripComboBox tsCBEinsätze;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.ToolStripMenuItem addEinsatzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mannschaftToolStripMenuItem;
        private System.Windows.Forms.Label l_dkrafte;
        private System.Windows.Forms.Label l_dkrafte_title;
        private System.Windows.Forms.Label l_ddauer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label l_proTag;
        private System.Windows.Forms.Label label5;
    }
}

