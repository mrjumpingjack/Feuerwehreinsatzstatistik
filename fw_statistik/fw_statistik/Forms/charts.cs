﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace fw_statistik
{
    public partial class Einsatzstatistik : Form
    {
        List<Einsatz> einsätze = new List<Einsatz>();

        public Einsatzstatistik(List<Einsatz> einsätze_)
        {
            einsätze = einsätze_;
            InitializeComponent();
        }

        private void charts_Load(object sender, EventArgs e)
        {

        }




        public void charting1_gesammt(List<Einsatz> einsätze)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            Dictionary<string, int> Orte = new Dictionary<string, int>();

            foreach (Einsatz einsatz in einsätze)
            {
                if (Orte.ContainsKey(einsatz.Ges_addresse.ToLower()))
                {
                    Orte[einsatz.Ges_addresse.ToLower()] = Orte[einsatz.Ges_addresse.ToLower()] + 1;
                }
                else
                {
                    Orte.Add(einsatz.Ges_addresse.ToLower(), 1);
                }

            }
            Orte = Orte.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);



            int i = 0;

            chart1.Series.Clear();
            chart1.Series.Add("Orte");
            chart1.Series[0].XValueType = ChartValueType.String;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;


            foreach (KeyValuePair<string, int> d in Orte)
            {

                chart1.Series[0].Points.AddXY(i, d.Value);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(i, i + 0.5, d.Key.Substring(d.Key.IndexOf(',') + 1, d.Key.Length - (d.Key.IndexOf(',') + 1)));
                i++;
            }
            chart1.Invalidate();
            chart1.Update();

        }

        public void charting1_nach_jahren_stichwort(List<Einsatz> einsätze)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            Dictionary<string, int> Ges_adressen = new Dictionary<string, int>();
            List<int> jahre = new List<int>();



            DataTable dt = new DataTable();
            dt.Columns.Add("Jahr", Type.GetType("System.String"));
            dt.Columns.Add("Brand", Type.GetType("System.Int32"));
            dt.Columns.Add("Th", Type.GetType("System.Int32"));
            dt.Columns.Add("Andere", Type.GetType("System.Int32"));


            foreach (Einsatz einsatz in einsätze)
            {
                if (!jahre.Contains(einsatz.Alarm_datum.Year))
                {
                    jahre.Add(einsatz.Alarm_datum.Year);
                }
            }



            foreach (int jahr in jahre)
            {
                int brände = 0, th = 0, andere = 0;


                foreach (Einsatz einsatz in einsätze)
                {
                    if (Convert.ToString(einsatz.Alarm_datum.Year) == Convert.ToString(jahr))
                    {
                        if (einsatz.Einsatzstichwort.Contains("B"))
                        {
                            brände++;
                        }
                        else if (einsatz.Einsatzstichwort.Contains("T"))

                        {
                            th++;
                        }
                        else
                        {
                            andere++;
                        }
                    }
                }

                DataRow dr1 = dt.NewRow();
                dr1["Jahr"] = Convert.ToString(jahr);
                dr1["Brand"] = brände;
                dr1["Th"] = th;
                dr1["Andere"] = andere;
                dt.Rows.Add(dr1);

            }

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series series = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    int y = (int)dr[i];
                    series.Points.AddXY(dr["Jahr"].ToString(), y);
                    series.Name = dt.Columns[i].ColumnName;

                    if (series.Name == "Brand")
                    {
                        series.Color = Color.Tomato;
                    }
                    if (series.Name == "Th")
                    {
                        series.Color = Color.LightBlue;
                    }
                    if (series.Name == "Andere")
                    {
                        series.Color = Color.Orange;
                    }

                }
                chart1.Series.Add(series);
            }



            chart1.Invalidate();
            chart1.Update();






        }





        public void charting_nach_Monaten_stichwort(List<Einsatz> einsätze)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            Dictionary<string, int> Ges_adressen = new Dictionary<string, int>();
            List<int> monate = new List<int>();



            DataTable dt = new DataTable();
            dt.Columns.Add("Monat", Type.GetType("System.String"));
            dt.Columns.Add("Brand", Type.GetType("System.Int32"));
            dt.Columns.Add("Th", Type.GetType("System.Int32"));
            dt.Columns.Add("Andere", Type.GetType("System.Int32"));


            foreach (Einsatz einsatz in einsätze)
            {
                if (!monate.Contains(einsatz.Alarm_datum.Month))
                {
                    monate.Add(einsatz.Alarm_datum.Month);
                }
            }

            monate.Sort();

            foreach (int monat in monate)
            {
                int brände = 0, th = 0, andere = 0;


                foreach (Einsatz einsatz in einsätze)
                {
                    if (Convert.ToString(einsatz.Alarm_datum.Month) == Convert.ToString(monat))
                    {
                        if (einsatz.Einsatzstichwort.Contains("B"))
                        {
                            brände++;
                        }
                        else if (einsatz.Einsatzstichwort.Contains("T"))

                        {
                            th++;
                        }
                        else
                        {
                            andere++;
                        }
                    }
                }

                DataRow dr1 = dt.NewRow();
                dr1["Monat"] = Convert.ToString(monat);
                dr1["Brand"] = brände;
                dr1["Th"] = th;
                dr1["Andere"] = andere;
                dt.Rows.Add(dr1);

            }

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series series = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    int y = (int)dr[i];
                    series.Points.AddXY(dr["Monat"].ToString(), y);
                    series.Name = dt.Columns[i].ColumnName;

                    if (series.Name == "Brand")
                    {
                        series.Color = Color.Tomato;
                    }
                    if (series.Name == "Th")
                    {
                        series.Color = Color.LightBlue;
                    }
                    if (series.Name == "Andere")
                    {
                        series.Color = Color.Orange;
                    }

                }

                chart1.Series.Add(series);
            }


            chart1.Invalidate();
            chart1.Update();

        }


        public void charting_nach_tageszeit_stichwort(List<Einsatz> einsätze)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

            Dictionary<string, int> Ges_adressen = new Dictionary<string, int>();
            List<int> stunden = new List<int>();



            DataTable dt = new DataTable();
            dt.Columns.Add("Stunde", Type.GetType("System.String"));
            dt.Columns.Add("Brand", Type.GetType("System.Int32"));
            dt.Columns.Add("Th", Type.GetType("System.Int32"));
            dt.Columns.Add("Andere", Type.GetType("System.Int32"));


            foreach (Einsatz einsatz in einsätze)
            {
                if (!stunden.Contains(einsatz.Alarm_datum.Hour))
                {
                    stunden.Add(einsatz.Alarm_datum.Hour);
                }
            }

            stunden.Sort();

            foreach (int stunde in stunden)
            {
                int brände = 0, th = 0, andere = 0;


                foreach (Einsatz einsatz in einsätze)
                {
                    if (Convert.ToString(einsatz.Alarm_datum.Hour) == Convert.ToString(stunde))
                    {
                        if (einsatz.Einsatzstichwort.Contains("B"))
                        {
                            brände++;
                        }
                        else if (einsatz.Einsatzstichwort.Contains("T"))

                        {
                            th++;
                        }
                        else
                        {
                            andere++;
                        }
                    }
                }

                DataRow dr1 = dt.NewRow();
                dr1["Stunde"] = Convert.ToString(stunde);
                dr1["Brand"] = brände;
                dr1["Th"] = th;
                dr1["Andere"] = andere;
                dt.Rows.Add(dr1);

            }

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                Series series = new Series();

                foreach (DataRow dr in dt.Rows)
                {
                    int y = (int)dr[i];
                    series.Points.AddXY(dr["Stunde"].ToString(), y);
                    series.Name = dt.Columns[i].ColumnName;

                    if (series.Name == "Brand")
                    {
                        series.Color = Color.Tomato;
                    }
                    if (series.Name == "Th")
                    {
                        series.Color = Color.LightBlue;
                    }
                    if (series.Name == "Andere")
                    {
                        series.Color = Color.Orange;
                    }

                }

                chart1.Series.Add(series);
            }


            chart1.Invalidate();
            chart1.Update();

        }








        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer3.SplitterDistance;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer3.SplitterDistance = splitContainer2.SplitterDistance;
        }





        private void einsatzOrteGesammtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            charting1_gesammt(einsätze);
        }

        private void einsatzorteNachJahrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            charting1_nach_jahren_stichwort(einsätze);
        }

        private void charts_Resize(object sender, EventArgs e)
        {

        }

        private void einsatzstichwortNachMonatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            charting_nach_Monaten_stichwort(einsätze);
        }

        private void einsatzstichwortNachTageszeitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            charting_nach_tageszeit_stichwort(einsätze);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
            }
        }
    }
}
