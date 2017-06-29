using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;

using GMap.NET.MapProviders;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace fw_statistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.ServerOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.", "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // config map

          
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.SetPositionByKeywords("Stadthagen,Deutschland");
            MainMap.MinZoom = 2;
            MainMap.MaxZoom = 100;
            MainMap.Zoom = 13;




            MainMap.ShowCenter = false;


            //{
            //    MainMap.OnPositionChanged += new PositionChanged(MainMap_OnPositionChanged);

            //}


        }


        #region Global_values



        GMapOverlay alle = new GMapOverlay("alle");
        GMapOverlay extra = new GMapOverlay("extra");
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        GMapOverlay th = new GMapOverlay("th");
        GMapOverlay brand = new GMapOverlay("brand");
        GMapOverlay andere = new GMapOverlay("andere");


        Dictionary<string, int> Orte = new Dictionary<string, int>();


        PointLatLng point_fwh = new PointLatLng();
        PointLatLng mousepoint = new PointLatLng();


        List<Einsatz> einsätze = new List<Einsatz>();
        List<double> distanzen = new List<double>();


        int error_count = 0;

        string import_result = "Yes";

        List<Einsatz> e_zum_nach_check = new List<Einsatz>();

        Import_file_msgbox ifmb = new Import_file_msgbox();

        int old_size = 0;

        public bool site_navigeted = false;
        public string checked_url = "";

        public Einsatz zu_checkender_einsatz;

        #endregion Global_values

      



        private void Form1_Shown(object sender, EventArgs e)
        {
            point_fwh = getpoint_byname("Enzerstraße 92a,Stadthagen");



            GMapOverlay markersOverlay = new GMapOverlay("markers");
            Bitmap b = (Bitmap)Bitmap.FromFile("ffl.png");
            b.MakeTransparent(Color.White);


            GMarkerGoogle marker = new GMarkerGoogle(point_fwh,b);

            //marker.Size = new Size(20,20);
            MainMap.Overlays.Add(extra);
            extra.Markers.Add(marker);


            

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // load_data_from_file(false);
        }

        private void fromLastImportToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Einsatzstatistik c = new Einsatzstatistik(einsätze);
            c.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMap.MapProvider = GMapProviders.GoogleMap;
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_data_from_csv_file(true);
        }

        private void layer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (alleToolStripMenuItem.CheckState == CheckState.Checked)
                {
                    MainMap.Overlays[MainMap.Overlays.IndexOf(alle)].IsVisibile = true;

                    MainMap.Overlays[MainMap.Overlays.IndexOf(th)].IsVisibile = false;
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brand)].IsVisibile = false;
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andere)].IsVisibile = false;

                    technischeHilfeleistungToolStripMenuItem.CheckState = CheckState.Unchecked;
                    brandeinsätzeToolStripMenuItem.CheckState = CheckState.Unchecked;
                    übungenToolStripMenuItem.CheckState = CheckState.Unchecked;

                }
                else
                {
                    MainMap.Overlays[MainMap.Overlays.IndexOf(alle)].IsVisibile = false;
                }


                if (technischeHilfeleistungToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(th)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(th)].IsVisibile = false;


                if (brandeinsätzeToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brand)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brand)].IsVisibile = false;


                if (übungenToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andere)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andere)].IsVisibile = false;


            }
            catch (Exception ex)
            { }

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMap.ShowExportDialog();

        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            double X = MainMap.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = MainMap.FromLocalToLatLng(e.X, e.Y).Lat;

            string longitude = X.ToString();
            string latitude = Y.ToString();

            mousepoint.Lat = Y;
            mousepoint.Lng = X;

            //GMapProviders.GoogleMap.GetTileImage(new GPoint(X, (long)Y),(int) MainMap.Zoom);
            // MainMap.ReloadMap();

        }

     

        private void MainMap_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                GeoCoderStatusCode g = new GeoCoderStatusCode();
                Placemark? point = GMapProviders.GoogleMap.GetPlacemark(mousepoint, out g);

                if (g == GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    Console.WriteLine(point.Value.Address);
                    Console.WriteLine(point.Value.DistrictName);

                }
            }
        }


        

        public void maps_marker(Einsatz einsatz)
        {
            
            MainMap.IgnoreMarkerOnMouseWheel = true;

            PointLatLng point_ = new PointLatLng();

            if (einsatz.Coor.Lat == 0 && einsatz.Coor.Lng == 0)
            {

                point_ = getpoint_byname(einsatz.Ges_addresse);



            }
            else
            {
                point_ = new PointLatLng(einsatz.Coor.Lat, einsatz.Coor.Lng);
            }


            if (point_.Lat == 0 && point_.Lng == 0)
            {
                //error_count++;
                e_zum_nach_check.Add(einsatz);
                if (point_.Lat == 0 && point_.Lng == 0)
                {
                    //if (import_result == "")
                    //{
                    //    ifmb.Einsatz = einsatz;
                    //    ifmb.ShowDialog();
                    //    import_result = ifmb.Result;
                    //}

                    if (import_result == "Yes"|| import_result == "No")
                    {
                        ifmb.Einsatz = einsatz;
                        ifmb.ShowDialog();
                        import_result = ifmb.Result;

                        if (import_result == "Yes")
                        {
                            Ortsüberprüfung nachcheck = new Ortsüberprüfung();
                            nachcheck.Einsatz = einsatz;

                            nachcheck.ShowDialog();

                            if (nachcheck.Changed == true)
                            {
                                einsatz = nachcheck.Einsatz;
                                maps_marker(einsatz);
                            }
                        }
                    }
                    else if(import_result=="YesAll")
                    {
                        Ortsüberprüfung nachcheck = new Ortsüberprüfung();
                        nachcheck.Einsatz = einsatz;

                        nachcheck.ShowDialog();

                        if (nachcheck.Changed == true)
                        {
                            einsatz = nachcheck.Einsatz;
                            maps_marker(einsatz);
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                einsatz.Coor = point_;
                GMarkerGoogleType farbe = new GMarkerGoogleType();
                bool create_new = true;

                if (alle.Markers.Count > 0)
                {
                    foreach (mymarker m in alle.Markers)
                    {
                        if (m.Einsatz.Ges_addresse.ToLower().Replace(" ", string.Empty) == einsatz.Ges_addresse.ToLower().Replace(" ", string.Empty))
                        {
                            m.ToolTipText = m.ToolTipText + Environment.NewLine + einsatz.Alarm_datum + "," + einsatz.Ges_addresse + "," + einsatz.Art + "," + einsatz.Einsatzstichwort;

                            create_new = false;
                        }
                    }
                    if (create_new == true)
                    {
                        createMarker(einsatz, farbe, point_);
                    }
                }
                else
                {
                    createMarker(einsatz, farbe, point_);
                }
            }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void createMarker(Einsatz einsatz, GMarkerGoogleType farbe, PointLatLng point_)
        {

            int SIZE = 0;

            einsatz.Einsatzstichwort = einsatz.Einsatzstichwort.Replace(" ", "");



            switch (einsatz.Einsatzstichwort)
            {
                case "B0":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin;
                    SIZE = 15;
                    break;
                case "B1":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin;
                    SIZE = 20;
                    break;
                case "B2":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin;
                    SIZE = 25;
                    break;
                case "B2-D":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin;
                    SIZE = 25;
                    break;
                case "B3":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_pushpin;
                    SIZE = 25;
                    break;

                case "FLB1":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red;
                    SIZE = 20;
                    break;
                case "FLB2":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red;
                    SIZE = 25;
                    break;

                case "DLK-A":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_dot;
                    SIZE = 20;
                    break;

                case "T0":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin;
                    SIZE = 15;
                    break;
                case "T1":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin;
                    SIZE = 20;
                    break;
                case "T2":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin;
                    SIZE = 25;
                    break;
                case "T3":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin;
                    SIZE = 30;
                    break;

                case "VU":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple;
                    SIZE = 20;
                    break;
                case "VUK":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.purple;
                    SIZE = 25;
                    break;


                case "G0":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin;
                    SIZE = 15;
                    break;
                case "G1":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin;
                    SIZE = 20;
                    break;
                case "G2":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin;
                    SIZE = 25;
                    break;
                case "G3":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin;
                    SIZE = 30;
                    break;

                case "BMA":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot;
                    SIZE = 20;
                    break;
                case "BMA1":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot;
                    SIZE = 20;
                    break;
                case "BMA2":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot;
                    SIZE = 25;
                    break;

                default:
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_pushpin;
                    SIZE = 20;
                    break;
            }


            mymarker marker = new mymarker(point_, farbe, einsatz);

            marker.Size = new System.Drawing.Size(10, 10);
            marker.ToolTipText = einsatz.Alarm_datum + "-" + einsatz.End_datum + "," + einsatz.Ges_addresse + "," + einsatz.Art + "," + einsatz.Einsatzstichwort;

            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new System.Drawing.Size(20, 20);
            marker.Size = new System.Drawing.Size(SIZE, SIZE);




            einsatz.Marker = marker;






            if (einsatz.Einsatzstichwort.Contains("B") && einsatz.Einsatzstichwort != "BSW")
            {
                alle.Markers.Add(marker);
                brand.Markers.Add(marker);
            }

            else if (einsatz.Einsatzstichwort.Contains("T"))
            {
                alle.Markers.Add(marker);
                th.Markers.Add(marker);
            }
            else
            {
                alle.Markers.Add(marker);
                andere.Markers.Add(marker);
            }





        }


        public PointLatLng getpoint_byname(String name)
        {
            PointLatLng point_ = new PointLatLng(0, 0);
            try
            {
                GeoCoderStatusCode gcsc = new GeoCoderStatusCode();

                PointLatLng? point = GMapProviders.GoogleMap.GetPoint(name, out gcsc);

                if (gcsc == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
                {
                    point_.Lat = point.Value.Lat;
                    point_.Lng = point.Value.Lng;
                }
                else
                {
                }

            }
            catch (Exception ex)
            {

            }
            return point_;
        }

       

      //  public List<WebKitBrowser> l_wkb = new List<WebKitBrowser>();

        private void createrouten_byeinsatz(Einsatz einsatz)
        {

            try
            {
                GDirections ss;
                var xx = GMapProviders.GoogleMap.GetDirections(out ss, (PointLatLng)point_fwh, (PointLatLng)getpoint_byname(einsatz.Ges_addresse), false, false, false, false, false);
                GMapRoute r = new GMapRoute(ss.Route, "My route");


                distanzen.Add(r.Distance);
                distanzen.Sort();
               //routesOverlay.Routes.Add(r);

               // einsatz.Distanz = r.Distance;
                einsatz.Route = r;
            }
            catch (Exception ex)
            {
                Console.WriteLine("fehler beim routen");
            }
        }

        private void load_data_from_csv_file(bool merge)
        {
            openFileDialog1.Filter = ".csv|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (merge == false)
                {
                    error_count = 0;
                    einsätze.Clear();
                    Orte.Clear();
                    distanzen.Clear();
                    MainMap.Overlays.Clear();


                    alle = new GMapOverlay("alle");
                    extra = new GMapOverlay("extra");
                    routesOverlay = new GMapOverlay("routes");

                    th = new GMapOverlay("th");
                    brand = new GMapOverlay("brand");
                    andere = new GMapOverlay("andere");

                    MainMap.Overlays.Add(th);
                    MainMap.Overlays.Add(brand);
                    MainMap.Overlays.Add(andere);
                    MainMap.Overlays.Add(alle);
                    MainMap.Overlays.Add(extra);
                }

                string lines = "";
                int ls = 0;

                foreach (string names in openFileDialog1.FileNames)
                {
                    using (StreamReader sr = new StreamReader(names, System.Text.Encoding.Default))
                    {
                        lines = sr.ReadToEnd();
                        ls += lines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;


                    }
                }

                toolStripProgressBar1.Maximum = ls;
                ls = 0;


                UseWaitCursor = true;
                foreach (string names in openFileDialog1.FileNames)
                {
                    using (StreamReader sr = new StreamReader(names, System.Text.Encoding.Default))
                    {

                        while (sr.Peek() >= 0)
                        {
                            string RAW_line = sr.ReadLine();
                            toolStripProgressBar1.Value += 1;
                            try
                            {
                                DateTime ALARM_DATUM, END_DATUM;
                                String einsatzstichwort, ort, straße, hausnummer, art, ges_addresse;


                                try
                                {


                                    ALARM_DATUM = Convert.ToDateTime(RAW_line.Split(';')[2]);
                                }
                                catch
                                {
                                    ALARM_DATUM = new DateTime(1, 1, 1);
                                }

                                try
                                {


                                    END_DATUM = Convert.ToDateTime(RAW_line.Split(';')[3]);
                                }
                                catch
                                {
                                    END_DATUM = new DateTime(1, 1, 1);
                                }



                                einsatzstichwort = RAW_line.Split(';')[0];
                                ges_addresse = RAW_line.Split(';')[1];


                                if (ges_addresse.Split(new char[] { ' ' }).Length >= 2)
                                {
                                    straße = ges_addresse.Split(new char[] { ' ' })[1];
                                }
                                else
                                {
                                    straße = "";
                                }

                                if (ges_addresse.Split(new char[] { ' ' }).Length >= 3)
                                {
                                    hausnummer = ges_addresse.Split(new char[] { ' ' })[2];
                                }
                                else
                                {
                                    hausnummer = "";
                                }

                                ort = ges_addresse.Split(new char[] { ' ' })[0];

                                art = RAW_line.Split(';')[4];

                                Einsatz einsatz = new Einsatz(names,ALARM_DATUM, END_DATUM, einsatzstichwort, ges_addresse, ort, straße, hausnummer, art);

                                try
                                {
                                    einsätze.Add(einsatz);
                                    maps_marker(einsatz);

                                    //   createrouten_byeinsatz(einsatz);

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(einsatz.Ges_addresse);
                                    continue;

                                }


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + ": " + RAW_line);

                            }
                        }



                        if (!merge)
                        {
                            MainMap.Overlays.Add(routesOverlay);
                        }

                    }

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


                    Console.WriteLine("Ort:anzahl der einsätze");

                    foreach (KeyValuePair<string, int> data in Orte)
                    {
                        Console.WriteLine(data.Key + ":" + data.Value);

                    }
                }




            }

            post();
        }



        private void load_data_from_xmf_file(String[] filenames, bool merge)
        {
            //openFileDialog1.Filter = ".xmf|*.xmf";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            if (merge == false)
            {
                error_count = 0;
                einsätze.Clear();
                Orte.Clear();
                distanzen.Clear();
                MainMap.Overlays.Clear();

                alle = new GMapOverlay("alle");
               // extra = new GMapOverlay("extra");
                routesOverlay = new GMapOverlay("routes");

                th = new GMapOverlay("th");
                brand = new GMapOverlay("brand");
                andere = new GMapOverlay("andere");

                MainMap.Overlays.Add(th);
                MainMap.Overlays.Add(brand);
                MainMap.Overlays.Add(andere);
                MainMap.Overlays.Add(alle);
                MainMap.Overlays.Add(extra);
            }

            string lines = "";
            int ls = 0;
            if (filenames.Length > 0)
            {
                foreach (string names in filenames)
                {
                    using (StreamReader sr = new StreamReader(names, System.Text.Encoding.Default))
                    {
                        lines = sr.ReadToEnd();
                        ls += lines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;


                    }
                }
            }

            toolStripProgressBar1.Maximum = ls;
            ls = 0;


            UseWaitCursor = true;
            foreach (string names in openFileDialog1.FileNames)
            {
                using (StreamReader sr = new StreamReader(names, System.Text.Encoding.UTF8))
                {

                    String[] raw = sr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                    raw = raw.Where(x => !string.IsNullOrEmpty(x)).ToArray();


                    String stichwort = raw[0].Split(new[] { '<', '>' })[2];
                    String addresse = raw[1].Split(new[] { '<', '>' })[2];
                    DateTime alarm_datum=DateTime.MaxValue;
                    DateTime end_datum=DateTime.MaxValue;

                    try
                    {
                        alarm_datum = DateTime.Parse(raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' '));
                        end_datum = DateTime.Parse(raw[3].Split(new[] { '<', '>' })[2]);
                    }
                    catch
                    {
                        try
                        {
                            alarm_datum = try_coorect_format(raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' '));
                            end_datum = try_coorect_format(raw[3].Split(new[] { '<', '>' })[2]);
                        }
                        catch
                        {
                            Alarmzeit_Editor AE = new Alarmzeit_Editor();
                           
                            AE.Alarmzeit = raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' ');
                            AE.Einsatzende = raw[3].Split(new[] { '<', '>' })[2];
                            AE.ShowDialog();

                            alarm_datum = DateTime.Parse(AE.Alarmzeit);
                            end_datum = DateTime.Parse(AE.Einsatzende);

                        }
                    }



                    String Art = raw[4].Split(new[] { '<', '>' })[2];
                    String[] Gruppen = raw[5].Split(new[] { '<', '>' })[2].Split(',');
                    bool fehl = false;

                    String Ort = "";
                    String Straße = "";
                    String Hausnummer = "";
                    try
                    {

                        if (addresse.Contains(','))
                        {
                            Ort = addresse.Split(',')[1];
                        }
                        else
                        {
                            Ort = "Stadthagen";
                        }

                        addresse = addresse + "," + Ort;


                        Straße = addresse.Split(',')[0].Split(' ')[0];
                        Hausnummer = addresse.Split(',')[0].Split(' ')[1];
                    }
                    catch (Exception ex)
                    {

                    }

                    List<Fahrzeug> Fahrzeuge = new List<Fahrzeug>();


                    foreach (string item in raw)
                    {
                        if (!(item.Contains("<stichwort>") || item.Contains("<addresse>") || item.Contains("<anfang>") ||
                            item.Contains("<ende>") || item.Contains("<art>") || item.Contains("<dme>") || item.Contains("<fehl>")))
                        {
                            String Name = item.Substring(1, item.IndexOf(">") - 1);

                            List<Feuerwehrmann> besatzung = new List<Feuerwehrmann>();

                            String raw_bes = item.Substring(item.IndexOf(">") + 1, (item.LastIndexOf("<") - item.IndexOf(">")) - 1);


                            //string GF = "";
                            foreach (string b in raw_bes.Split(';'))
                            {
                                if (b.Length > 0)
                                {
                                    string name = b/*.Replace(" ", "")*/;
                                    string name_="";

                                    if (name.StartsWith("Gf:"))
                                    {
                                        name_ = name.Substring(3, name.Length - 3);
                                    }
                                    else
                                    {
                                        name_ = name;
                                    }

                                        name_ = Regex.Replace(name_, "[^a-zA-Z.,üöä ]", "");

                                    if (name_.StartsWith("."))
                                    {
                                        name_ = name_.TrimStart('.');
                                    }

                                    if (name_.StartsWith(" "))
                                    {
                                        name_ = name_.TrimStart(' ');
                                    }

                                    if (name_.EndsWith(" "))
                                    {
                                        name_ = name_.TrimEnd(' ');
                                    }


                                    if (name_.EndsWith(","))
                                    {
                                        name_ = name_.TrimEnd(',');
                                    }

                                    if (name.StartsWith("Gf:"))
                                    {
                                        besatzung.Add(new Feuerwehrmann(name_, true));
                                    }
                                    else
                                    {
                                        besatzung.Add(new Feuerwehrmann(name_, false));
                                    }


                                }
                            }
                            if (besatzung.Count > 0)
                            {
                                if (besatzung.Count == 1)
                                {
                                    besatzung[0].Is_gruppenführer=true;
                                }

                                Fahrzeuge.Add(new Fahrzeug(Name, besatzung));
                            }
                        }
                        else
                        {
                            if (item.Contains("<fehl>"))
                            {
                                if (item.Split(new[] { '<', '>' })[1].ToLower() == "true")
                                {
                                    fehl = true;
                                }
                            }
                        }
                    }

                    Einsatz einsatz = new Einsatz(names, alarm_datum, end_datum, stichwort, addresse, Ort, Straße, Hausnummer, Art,fehl,String.Join(";",Gruppen))
                    {  
                        Fahrzeuge = Fahrzeuge
                    };

                    try
                    {
                        einsätze.Add(einsatz);
                        maps_marker(einsatz);

                        //   createrouten_byeinsatz(einsatz);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(einsatz.Ges_addresse);
                        continue;

                    }


                    createrouten_byeinsatz(einsatz);


                }



                if (!merge)
                {
                    MainMap.Overlays.Add(routesOverlay);
                }



            }

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


            Console.WriteLine("Ort:anzahl der einsätze");

            foreach (KeyValuePair<string, int> data in Orte)
            {
                Console.WriteLine(data.Key + ":" + data.Value);

            }



            post();

        }


        public DateTime try_coorect_format(String to_check)
        {
            DateTime corrected = DateTime.Now;
            try
            {
               

                string[] parts = to_check.Split(new[] { ' ' });

                char[] chars = new char[] { ' ', ';', ',', ':' };

                parts[0] = chars.Aggregate(parts[0], (c1, c2) => c1.Replace(c2, '.'));

                parts[1] = chars.Aggregate(parts[1], (c1, c2) => c1.Replace(c2, ':'));


                string joined = parts[0] + " " + parts[1];

                corrected = DateTime.Parse(joined);
            }
            catch
            {
                
                
            }


            return corrected;
        }


        void post()
        {
            double ave = 0;


            distanzen.Sort();
            foreach (double s in distanzen)
            {
                ave += s;
                Console.WriteLine(s);
            }
            ave = ave / distanzen.Count;

            l_fahrtweg.Text = Convert.ToString(Math.Round(ave, 2));


            l_einsätze_count.Text = Convert.ToString(einsätze.Count);

            l_th_count.Text = Convert.ToString(th.Markers.Count());
            l_brand_count.Text = Convert.ToString(brand.Markers.Count());
            l_ubungen.Text = Convert.ToString(andere.Markers.Count());

            l_load_error.Text = Convert.ToString(error_count);

            Console.WriteLine(alle.Markers.Count);




            Einsatzstatistik c = new Einsatzstatistik(einsätze);
           

            MainMap.Overlays[MainMap.Overlays.IndexOf(alle)].IsVisibile = false;

            toolStripProgressBar1.Value = 0;

            foreach (Einsatz einsatz in einsätze)
            {

                toolStripComboBox1.Items.Add(einsatz.Einsatzstichwort + "_" + einsatz.Ges_addresse + "_" + einsatz.Alarm_datum);
            }
            toolStripComboBox1.Sorted = true;


            List<PointLatLng> points = new List<PointLatLng>();
            foreach (GMapMarker m in alle.Markers)
            {
                points.Add(m.Position);
            }

            //hmo = new HeatMapOverlay("heat", MainMap, points.ToArray());


            //MainMap.Overlays.Add(hmo);



            UseWaitCursor = false;
            //  c.Show();
        }



       // HeatMapOverlay hmo;

        //private void heatmap(List<PointLatLng> points_)
        //{
        //    using (StreamWriter sw = new StreamWriter("points.txt"))
        //    {
        //        foreach (PointLatLng p in points_)
        //        {
        //            string lat = Convert.ToString(p.Lat, CultureInfo.InvariantCulture);
        //            string lng = Convert.ToString(p.Lng, CultureInfo.InvariantCulture);

        //            sw.WriteLine(lat + "," + lng);
        //        }
        //    }

        //}




        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Einsatzstatistik cha = new Einsatzstatistik(null);
            cha.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            Einsatz ein;

            foreach (Einsatz ei in einsätze)
            {
                string sw = toolStripComboBox1.Text.Split(new char[] { '_' })[0];
                string ga = toolStripComboBox1.Text.Split(new char[] { '_' })[1];
                DateTime az = Convert.ToDateTime(toolStripComboBox1.Text.Split(new char[] { '_' })[2]);

                if (ei.Einsatzstichwort == sw
                    && ei.Ges_addresse == ga
                    && ei.Alarm_datum == az)
                {
                    ein = ei;

                    routesOverlay.Routes.Add(ein.Route);

                    Bericht f2 = new Bericht(ref ein);
                    f2.ShowDialog();

                    if(f2.Changed==true)
                    {
                       
                        foreach (GMapOverlay o in MainMap.Overlays)
                        {
                            o.Markers.Remove(ei.Marker);
                        }
                          

                        GMarkerGoogleType farbe = new GMarkerGoogleType();


                        PointLatLng point_ = getpoint_byname(ein.Ges_addresse);
                        ein.Coor = point_;
                        createMarker(ein, farbe, point_);


                        toolStripComboBox1.Items.Clear();
                        foreach (Einsatz einsatz in einsätze)
                        {

                            toolStripComboBox1.Items.Add(einsatz.Einsatzstichwort + "_" + einsatz.Ges_addresse + "_" + einsatz.Alarm_datum);
                        }
                        toolStripComboBox1.Sorted = true;






                        createrouten_byeinsatz(ein);


                        save_einsatz_to_file(ein.Filepath, ein);

                    }
                    routesOverlay.Routes.Remove(ein.Route);

                    break;
                }

            }






        }

       

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainMap_Load(object sender, EventArgs e)
        {

        }

        private void MainMap_Click(object sender, EventArgs e)
        {



        }



        private void exportMarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<PointLatLng> points = new List<PointLatLng>();
            foreach (GMapMarker m in alle.Markers)
            {
                points.Add(m.Position);
            }
            new_heat_map(points);
        }

        private void MainMap_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void MainMap_OnMapZoomChanged()
        {
            Console.WriteLine(MainMap.Zoom);
        }

        private void heatmapLANGSAMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //List<PointLatLng> points = new List<PointLatLng>();
            //foreach (GMapMarker m in alle.Markers)
            //{
            //    points.Add(m.Position);
            //}
            //new_heat_map(points);
        }

    

        private void new_heat_map(List<PointLatLng> points)
        {
            //try
            //{
            //    MainMap.Overlays.Remove(hmo);
            //    hmo = new HeatMapOverlay("heat", MainMap, points);
            //    MainMap.Overlays.Add(hmo);
            //    hmo.Draw(MainMap.gxOff);

                


            //}
            //catch { }
        }

        private void xMFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".xmf|*.xmf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                load_data_from_xmf_file(openFileDialog1.FileNames, false);
            }
        }

        private void cSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_data_from_csv_file(false);
        }

        private void MainMap_OnMarkerClick_1(GMapMarker item, MouseEventArgs e)
        {
            foreach (Einsatz ein in einsätze)
            {
                if (ein.Coor == item.Position)
                {
                    Einsatz eins = einsätze[einsätze.IndexOf(ein)];
                    routesOverlay.Routes.Add(ein.Route);

                    Bericht f2 = new Bericht(ref eins);

                   
                   f2.ShowDialog();
                    if (f2.Changed == true)
                    {
                        f2.Changed = false;
                        foreach (GMapOverlay overlay in MainMap.Overlays)
                        {
                            if (overlay.Markers.Contains(ein.Marker))
                            {
                                overlay.Markers.Remove(ein.Marker);
                                overlay.Routes.Remove(ein.Route);
                            }

                        }




                        GMarkerGoogleType farbe = new GMarkerGoogleType();


                        PointLatLng point_ = getpoint_byname(ein.Ges_addresse);
                        ein.Coor = point_;
                        createMarker(ein, farbe, point_);


                        toolStripComboBox1.Items.Clear();
                        foreach (Einsatz einsatz in einsätze)
                        {

                            toolStripComboBox1.Items.Add(einsatz.Einsatzstichwort + "_" + einsatz.Ges_addresse + "_" + einsatz.Alarm_datum);
                        }
                        toolStripComboBox1.Sorted = true;




                       

                        createrouten_byeinsatz(ein);


                        save_einsatz_to_file(ein.Filepath, ein);
                    }
                    routesOverlay.Routes.Remove(ein.Route);
                }
            }
        }


        private void save_einsatz_to_file(string path, Einsatz einsatz)
        {
            if (File.Exists(path))
            {
                File.Copy(path, path + "_old",true);

            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("<stichwort>" + einsatz.Einsatzstichwort + "</stichwort>");
                sw.WriteLine("<addresse>" + einsatz.Ges_addresse + "</addresse>");
                sw.WriteLine("<anfang>" + einsatz.Alarm_datum + "</anfang>");
                sw.WriteLine("<ende>" + einsatz.End_datum + "</ende>");
                sw.WriteLine("<art>" + einsatz.Art + "</art>");
                sw.WriteLine("<dme>" + einsatz.Gruppen + "</dme>");
                sw.WriteLine("<fehl>" + einsatz.Fehl + "</fehl>");

                foreach (Fahrzeug fahrzeug in einsatz.Fahrzeuge)
                {
                    String bes = "";
                    foreach (Feuerwehrmann fwm in fahrzeug.Besatzung)
                    {
                        bes = bes + fwm.Name+";";
                    }

                    sw.WriteLine("<" + fahrzeug.Name + ">" + bes + "</" + fahrzeug.Name + ">");
                }



            }

        }


        private void addEinsatzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Einsatz_scraper.Scrapper sc = new Einsatz_scraper.Scrapper();
            sc.ShowDialog();
            load_data_from_xmf_file(new string[] { sc.New_file_path }, true);


        }

        private void mannschaftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manschaftsstatisik ms = new Manschaftsstatisik(einsätze);
            ms.ShowDialog();
        }

        private void MainMap_OnMapDrag()
        {
            //List<PointLatLng> points = new List<PointLatLng>();
            //foreach (GMapMarker m in alle.Markers)
            //{
            //    points.Add(m.Position);
            //}
            //new_heat_map(points);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
    }
}