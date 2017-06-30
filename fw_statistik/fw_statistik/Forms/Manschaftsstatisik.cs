using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace fw_statistik
{
    public partial class Manschaftsstatisik : Form
    {
        public List<Einsatz> Einsätze { get; set; }
        public List<Alias> Aliase { get; set; }

    

        public Manschaftsstatisik()
        {
            InitializeComponent();
        }


        private void find_aliase()
        {
            try
            {
                bool aliasExists = false;
                bool nameIsInAlias = false;

                string xml_alias_filename = "aliase.xml";

                XmlDocument load_xml_doc = new XmlDocument();
                if (File.Exists(xml_alias_filename))
                {
                    load_xml_doc.Load(xml_alias_filename);

                    foreach (XmlNode node in load_xml_doc.DocumentElement)
                    {
                        try
                        {
                            Alias newalias = new Alias(node.Name.Replace("_", ", "), node.InnerText.Split(';').ToList<String>());
                            Aliase.Add(newalias);
                        }
                        catch(Exception ex)
                        {

                        }
                    }

                }
            
            string dialogresult = "Yes";


            foreach (Einsatz einsatz in Einsätze)
            {
                foreach (Fahrzeug fahrzeug in einsatz.Fahrzeuge)
                {
                    List<String> alle = new List<string>();
            
                    foreach (Feuerwehrmann FWM in fahrzeug.Besatzung)
                    {
                        aliasExists = false;
                        nameIsInAlias = false;

                        foreach (Alias alias in Aliase)
                        {
                            if (alias.Name == FWM.Name)
                            {
                                nameIsInAlias = true;
                            }
                            else
                            {
                                if (alias.Aliase.Contains(FWM.Name))
                                {
                                    aliasExists = true;
                                }
                            }
                        }

                        if (nameIsInAlias == false && aliasExists == false)
                        {
                            if (dialogresult == "Yes" || dialogresult == "No")
                            {
                                Import_stats_msgbox ism = new Import_stats_msgbox();
                                ism.Message = "Wollen Sie für " + FWM.Name + " einen Alias erstellen?";
                                ism.ShowDialog();
                                
                                dialogresult = ism.Result;

                                if (dialogresult == "Yes")
                                {
                                    Alias_Editor ae = new Alias_Editor(Aliase, FWM.Name);
                                    ism.Message = "Wollen Sie für " + FWM.Name + " einen Alias erstellen?";
                                    ae.ShowDialog();
                                   
                                    Aliase = ae.aliase;
                                 
                                }

                            }
                            else if (dialogresult == "AllYes")
                            {
                                Alias_Editor ae = new Alias_Editor(Aliase, FWM.Name);
                                ae.ShowDialog();
                              
                                Aliase = ae.aliase;
                               
                            }

                        }

                    }
                }

                try
                {
                    XmlDocument xml_doc = new XmlDocument();

                    XmlNode rootNode = xml_doc.CreateElement("Aliase");
                    xml_doc.AppendChild(rootNode);

                    foreach (Alias alias in Aliase)
                    {
                        string aan = alias.Name.Replace(",", "_").Replace(" ", "");
                        XmlNode userNode = xml_doc.CreateElement(aan);
                        String al_ = "";
                        foreach (string a in alias.Aliase)
                        {
                            if (al_.Length > 0)
                            {
                                al_ = al_ + ";";
                            }
                            al_ += a;
                        }
                        userNode.InnerText = al_;
                        rootNode.AppendChild(userNode);
                    }

                    xml_doc.Save(xml_alias_filename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            }
            catch (Exception ex)
            {

            }
        }
        Dictionary<string, int> name_anwesenheit = new Dictionary<string, int>();


        private void Manschaftsstatisik_Load(object sender, EventArgs e)
        {
            Aliase = new List<Alias>();
            find_aliase();

           

            loadEinsätzeToListBox();
            TeilnehmerStatistik();
            FahrzeugbesatzungStatistik();
            AlarmgruppenStatistik();

        }



        private void loadEinsätzeToListBox()
        {
            //füllen der listbox
            try
            {
                foreach (Einsatz einsatz in Einsätze)
                {
                    foreach (Fahrzeug fahrzeug in einsatz.Fahrzeuge)
                    {
                        foreach (Feuerwehrmann FWM in fahrzeug.Besatzung)
                        {
                            foreach (Alias alias in Aliase)
                            {
                                if (alias.Aliase.Contains(FWM.Name))
                                {
                                    if (name_anwesenheit.Keys.Contains(alias.Name))
                                    {
                                        name_anwesenheit[alias.Name]++;
                                    }
                                    else
                                    {
                                        name_anwesenheit.Add(alias.Name, 1);
                                    }
                                }
                            }
                        }
                    }
                }


                foreach (KeyValuePair<string, int> na_ in name_anwesenheit)
                {
                    listBox1.Items.Add(na_.Key + ": " + na_.Value);
                }

                listBox1.Sorted = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        private void TeilnehmerStatistik()
        {
            //chart füllen (page1)
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            foreach (KeyValuePair<string, int> person in name_anwesenheit)
            {
                chart1.Series[0].Points.AddXY(person.Key, person.Value);

            }

            chart1.Series[0].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending);
        }
        
        private void FahrzeugbesatzungStatistik()
        {
            //page 2

            int xChartPoint = 0;
            int yChartPoint = 0;

            Dictionary<string, Dictionary<string, int>> zuordnung = new Dictionary<string, Dictionary<string, int>>();


            foreach (Einsatz einsatz in Einsätze)
            {
                foreach (Fahrzeug fahrzeug in einsatz.Fahrzeuge)
                {
                    Chart chart_ = tabPage2.Controls.Find(fahrzeug.Name, true).FirstOrDefault() as Chart;

                    if (!tabPage2.Controls.Contains(chart_))
                    {
                        Chart chart = new Chart();
                        chart.Name = fahrzeug.Name;
                        chart.Size = new Size(tabPage2.Width, 660);
                        chart.Location = new Point(xChartPoint, yChartPoint);
                        chart.ChartAreas.Add(fahrzeug.Name);
                        chart.Series.Add(fahrzeug.Name);

                        chart.ChartAreas[0].AxisX.Interval = 1;

                        chart.Titles.Add(fahrzeug.Name);
                        chart.Titles[0].Text = fahrzeug.Name;

                        yChartPoint += chart.Height;

                        tabPage2.Controls.Add(chart);
                    }
                    else
                    {

                    }

                    foreach (Feuerwehrmann man in fahrzeug.Besatzung)
                    {
                        foreach (Alias alias in Aliase)
                        {
                            if (alias.Aliase.Contains(man.Name))
                            {


                                if (zuordnung.Keys.Contains(fahrzeug.Name))
                                {
                                    int anzahl = 0;

                                    if (zuordnung[fahrzeug.Name].TryGetValue(alias.Name, out anzahl))
                                    {
                                        zuordnung[fahrzeug.Name][alias.Name]++;
                                    }
                                    else
                                    {
                                        zuordnung[fahrzeug.Name].Add(alias.Name, 1);
                                    }
                                }
                                else
                                {
                                    Dictionary<string, int> personal = new Dictionary<string, int>();
                                    personal.Add(alias.Name, 1);
                                    zuordnung.Add(fahrzeug.Name, personal);
                                }
                            }
                        }
                    }
                }
            }

            try
            {
                foreach (KeyValuePair<string, Dictionary<string, int>> item in zuordnung)
                {

                    var sortedDict = from entry in item.Value orderby entry.Value descending select entry;

                    Dictionary<string, int> dic = sortedDict.ToDictionary(r => r.Key, r => r.Value);

                    var topX = (from entry in dic orderby entry.Value descending select entry).Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);

                    dic = topX.ToDictionary(r => r.Key, r => r.Value);


                    Chart chart = tabPage2.Controls.Find(item.Key, true).FirstOrDefault() as Chart;


                    foreach (KeyValuePair<string, int> item_ in dic)
                    {
                        chart.Series[0].Points.AddXY(item_.Key, item_.Value);

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void AlarmgruppenStatistik()
        {
            try
            {
                Dictionary<string, Dictionary<String, int>> es_grp_anz = new Dictionary<string, Dictionary<string, int>>();
                foreach (Einsatz e in Einsätze)
                {

                    string stichwort = e.Einsatzstichwort.ToUpper().Replace("-", "").Replace(" ", "");


                    if (es_grp_anz.Keys.Contains(stichwort))
                    {
                        foreach (String grp in e.Gruppen.Split(';'))
                        {
                            string grp_ = grp.ToUpper().Replace("-", "").Replace(" ", "");
                            if (es_grp_anz[stichwort].Keys.Contains(grp_))
                            {
                                es_grp_anz[stichwort][grp_]++;
                            }
                            else
                            {
                                es_grp_anz[stichwort].Add(grp_, 1);
                            }
                        }
                    }
                    else
                    {
                        Dictionary<string, int> grp_anz = new Dictionary<string, int>();
                        
                        foreach (String grp in e.Gruppen.Split(';'))
                        {
                            string grp_ = grp.ToUpper().Replace("-", "").Replace(" ", "");
                            if (grp_anz.Keys.Contains(grp_))
                            {
                                grp_anz[grp_]++;
                            }
                            else
                            {
                                grp_anz.Add(grp_, 1);
                            }
                        }

                        es_grp_anz.Add(stichwort, grp_anz);
                    }

                }
                int x_chart_point = 0;
                int y_chart_point = 0;

                foreach (KeyValuePair<string, Dictionary<string, int>> es_grp_anz_ in es_grp_anz)
                {
                    //if (chart2.Series.FindByName(es_grp_anz_.Key)==null)
                    //{
                    Chart chart_ = tabPage3.Controls.Find(es_grp_anz_.Key, true).FirstOrDefault() as Chart;

                    Chart chart = new Chart();

                    var sortedDict = from entry in es_grp_anz_.Value orderby entry.Value descending select entry;

                    Dictionary<string, int> dic = sortedDict.ToDictionary(r => r.Key, r => r.Value);

                    var topX = (from entry in dic orderby entry.Value descending select entry).Take(10).ToDictionary(pair => pair.Key, pair => pair.Value);

                    dic = topX.ToDictionary(r => r.Key, r => r.Value);



                    if (!tabPage3.Controls.Contains(chart_))
                    {

                        chart.Name = es_grp_anz_.Key;
                        chart.Size = new Size(tabPage2.Width, 660);
                        chart.Location = new Point(x_chart_point, y_chart_point);
                        chart.ChartAreas.Add(es_grp_anz_.Key);
                        chart.Series.Add(es_grp_anz_.Key);

                        chart.ChartAreas[0].AxisX.Interval = 1;

                        chart.Titles.Add(es_grp_anz_.Key);
                        chart.Titles[0].Text = es_grp_anz_.Key;

                        y_chart_point += chart.Height;

                        tabPage3.Controls.Add(chart);

                        foreach (KeyValuePair<string, int> grp_anz in dic)
                        {

                            chart.Series[es_grp_anz_.Key].Points.AddXY(grp_anz.Key, grp_anz.Value);
                        }

                        chart.Series[es_grp_anz_.Key].Sort(PointSortOrder.Ascending, "X");
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> grp_anz in dic)
                        {

                            chart.Series[es_grp_anz_.Key].Points.AddXY(grp_anz.Key, grp_anz.Value);
                        }

                        chart.Series[es_grp_anz_.Key].Sort(PointSortOrder.Ascending, "X");
                    }
                }        
            }
            catch(Exception ex)
            {

            }

        }
        
        private void teilgenommenToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void meistBesetztVonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
