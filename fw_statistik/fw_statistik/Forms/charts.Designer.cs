namespace fw_statistik
{
    partial class Einsatzstatistik
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chart1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einsatzOrteGesammtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einsatzorteNachJahrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einsatzstichwortNachMonatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einsatzstichwortNachTageszeitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1036, 652);
            this.splitContainer1.SplitterDistance = 516;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chart4);
            this.splitContainer3.Size = new System.Drawing.Size(516, 652);
            this.splitContainer3.SplitterDistance = 327;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer3_SplitterMoved);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(516, 327);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // chart4
            // 
            chartArea2.Name = "ChartArea1";
            this.chart4.ChartAreas.Add(chartArea2);
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart4.Legends.Add(legend2);
            this.chart4.Location = new System.Drawing.Point(0, 0);
            this.chart4.Name = "chart4";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart4.Series.Add(series1);
            this.chart4.Size = new System.Drawing.Size(516, 321);
            this.chart4.TabIndex = 4;
            this.chart4.Text = "chart4";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chart2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chart3);
            this.splitContainer2.Size = new System.Drawing.Size(516, 652);
            this.splitContainer2.SplitterDistance = 329;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart2.Legends.Add(legend3);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(516, 329);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea4.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea4);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chart3.Legends.Add(legend4);
            this.chart3.Location = new System.Drawing.Point(0, 0);
            this.chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(516, 319);
            this.chart3.TabIndex = 4;
            this.chart3.Text = "chart3";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chart1ToolStripMenuItem,
            this.chart2ToolStripMenuItem,
            this.chart3ToolStripMenuItem,
            this.chart4ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chart1ToolStripMenuItem
            // 
            this.chart1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einsatzOrteGesammtToolStripMenuItem,
            this.einsatzorteNachJahrenToolStripMenuItem,
            this.einsatzstichwortNachMonatenToolStripMenuItem,
            this.einsatzstichwortNachTageszeitToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.chart1ToolStripMenuItem.Name = "chart1ToolStripMenuItem";
            this.chart1ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.chart1ToolStripMenuItem.Text = "Chart 1";
            // 
            // einsatzOrteGesammtToolStripMenuItem
            // 
            this.einsatzOrteGesammtToolStripMenuItem.Name = "einsatzOrteGesammtToolStripMenuItem";
            this.einsatzOrteGesammtToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.einsatzOrteGesammtToolStripMenuItem.Text = "Einsätze pro Ort gesammt";
            this.einsatzOrteGesammtToolStripMenuItem.Click += new System.EventHandler(this.einsatzOrteGesammtToolStripMenuItem_Click);
            // 
            // einsatzorteNachJahrenToolStripMenuItem
            // 
            this.einsatzorteNachJahrenToolStripMenuItem.Name = "einsatzorteNachJahrenToolStripMenuItem";
            this.einsatzorteNachJahrenToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.einsatzorteNachJahrenToolStripMenuItem.Text = "Einsatzstichwort nach Jahren";
            this.einsatzorteNachJahrenToolStripMenuItem.Click += new System.EventHandler(this.einsatzorteNachJahrenToolStripMenuItem_Click);
            // 
            // einsatzstichwortNachMonatenToolStripMenuItem
            // 
            this.einsatzstichwortNachMonatenToolStripMenuItem.Name = "einsatzstichwortNachMonatenToolStripMenuItem";
            this.einsatzstichwortNachMonatenToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.einsatzstichwortNachMonatenToolStripMenuItem.Text = "Einsatzstichwort nach Monaten";
            this.einsatzstichwortNachMonatenToolStripMenuItem.Click += new System.EventHandler(this.einsatzstichwortNachMonatenToolStripMenuItem_Click);
            // 
            // einsatzstichwortNachTageszeitToolStripMenuItem
            // 
            this.einsatzstichwortNachTageszeitToolStripMenuItem.Name = "einsatzstichwortNachTageszeitToolStripMenuItem";
            this.einsatzstichwortNachTageszeitToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.einsatzstichwortNachTageszeitToolStripMenuItem.Text = "Einsatzstichwort nach Tageszeit";
            this.einsatzstichwortNachTageszeitToolStripMenuItem.Click += new System.EventHandler(this.einsatzstichwortNachTageszeitToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // chart2ToolStripMenuItem
            // 
            this.chart2ToolStripMenuItem.Name = "chart2ToolStripMenuItem";
            this.chart2ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.chart2ToolStripMenuItem.Text = "Chart 2";
            // 
            // chart3ToolStripMenuItem
            // 
            this.chart3ToolStripMenuItem.Name = "chart3ToolStripMenuItem";
            this.chart3ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.chart3ToolStripMenuItem.Text = "Chart 3";
            // 
            // chart4ToolStripMenuItem
            // 
            this.chart4ToolStripMenuItem.Name = "chart4ToolStripMenuItem";
            this.chart4ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.chart4ToolStripMenuItem.Text = "Chart 4";
            // 
            // Einsatzstatistik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 676);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Einsatzstatistik";
            this.Text = "Einsatzstatistik";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.charts_Load);
            this.Resize += new System.EventHandler(this.charts_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart4)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chart1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einsatzOrteGesammtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einsatzorteNachJahrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chart4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einsatzstichwortNachMonatenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einsatzstichwortNachTageszeitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}