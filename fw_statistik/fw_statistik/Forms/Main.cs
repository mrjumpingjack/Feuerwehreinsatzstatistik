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
using fw_statistik.Forms;
using System.Xml;

namespace fw_statistik
{
    public partial class Form1 : Form
    {


    

        public Form1()
        {
            InitializeComponent();

            CheckInternetConnection();



            SetUpMainMap();





        }
        
        private void SetUpMainMap()
        {

            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.SetPositionByKeywords("Stadthagen,Deutschland");
            MainMap.MinZoom = 2;
            MainMap.MaxZoom = 100;
            MainMap.Zoom = 13;
           
            MainMap.ShowCenter = false;

            feuerwehrhausLocation = getpoint_byname("Enzerstraße 92a,Stadthagen");

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            Bitmap b = (Bitmap)Bitmap.FromFile("ffl.png");
            b.MakeTransparent(Color.White);


            GMarkerGoogle marker = new GMarkerGoogle(feuerwehrhausLocation, b);

            //marker.Size = new Size(20,20);
            MainMap.Overlays.Add(extraOverlay);
            extraOverlay.Markers.Add(marker);


        }

        private void CheckInternetConnection()
        {
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.ServerOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.", "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        #region Global_values



        GMapOverlay alleOverlay = new GMapOverlay("alle");
        GMapOverlay extraOverlay = new GMapOverlay("extra");
        GMapOverlay routesOverlay = new GMapOverlay("routes");
        GMapOverlay thOverlay = new GMapOverlay("th");
        GMapOverlay brandOverlay = new GMapOverlay("brand");
        GMapOverlay andereOverlay = new GMapOverlay("andere");


        Dictionary<string, int> Orte = new Dictionary<string, int>();


        PointLatLng feuerwehrhausLocation = new PointLatLng();
        PointLatLng mousePoint = new PointLatLng();


        List<Einsatz> einsätze = new List<Einsatz>();
        List<double> distanzen = new List<double>();


        int error_count = 0;

       

        List<Einsatz> einsatzZumNachchecken = new List<Einsatz>();

        PointLatLng MousePoint;



        #endregion Global_values

      

        private void Form1_Shown(object sender, EventArgs e)
        {
           
            

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ofd_main.Filter = ".xmf|*.xmf";
            if (ofd_main.ShowDialog() == DialogResult.OK)
            {
                LoadDataFromFile(ofd_main.FileNames, false);
            }
        }

        private void fromLastImportToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Einsatzstatistik c = new Einsatzstatistik(einsätze);
            c.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
        }

        

        private void layer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (alleToolStripMenuItem.CheckState == CheckState.Checked)
                {
                    MainMap.Overlays[MainMap.Overlays.IndexOf(alleOverlay)].IsVisibile = true;

                    MainMap.Overlays[MainMap.Overlays.IndexOf(thOverlay)].IsVisibile = false;
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brandOverlay)].IsVisibile = false;
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andereOverlay)].IsVisibile = false;

                    technischeHilfeleistungToolStripMenuItem.CheckState = CheckState.Unchecked;
                    brandeinsätzeToolStripMenuItem.CheckState = CheckState.Unchecked;
                    übungenToolStripMenuItem.CheckState = CheckState.Unchecked;

                }
                else
                {
                    MainMap.Overlays[MainMap.Overlays.IndexOf(alleOverlay)].IsVisibile = false;
                }


                if (technischeHilfeleistungToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(thOverlay)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(thOverlay)].IsVisibile = false;


                if (brandeinsätzeToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brandOverlay)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(brandOverlay)].IsVisibile = false;


                if (übungenToolStripMenuItem.CheckState == CheckState.Checked)
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andereOverlay)].IsVisibile = true;
                else
                    MainMap.Overlays[MainMap.Overlays.IndexOf(andereOverlay)].IsVisibile = false;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

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

            MousePoint.Lat = Y;
            MousePoint.Lng = X;

        }

     

        private void MainMap_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                GeoCoderStatusCode g = new GeoCoderStatusCode();
                Placemark? point = GMapProviders.GoogleMap.GetPlacemark(MousePoint, out g);

                if (g == GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    Console.WriteLine(point.Value.Address);
                    Console.WriteLine(point.Value.DistrictName);

                }
            }
        }


        

        public void addMarkerToMap(Einsatz einsatz)
        {
            MainMap.IgnoreMarkerOnMouseWheel = true;
            PointLatLng Point = new PointLatLng();



            if (einsatz.Koordinaten.Lat == 0 && einsatz.Koordinaten.Lng == 0)
            {
                Point = getpoint_byname(einsatz.Adresse.Address);
            }
            else
            {
                Point = new PointLatLng(einsatz.Koordinaten.Lat, einsatz.Koordinaten.Lng);
            }

            Import_file_msgbox ifmb = new Import_file_msgbox();

            Ortsüberprüfung nachcheck = new Ortsüberprüfung();
            nachcheck.Einsatz = einsatz;

            string import_result = "Yes";

            if (Point.Lat == 0 && Point.Lng == 0)
            {
                einsatzZumNachchecken.Add(einsatz);
                if (Point.Lat == 0 && Point.Lng == 0)
                {
                    if (import_result == "Yes"|| import_result == "No")
                    {
                        ifmb.ShowDialog();
                        import_result = ifmb.Result;
                        if (import_result == "Yes")
                        {
                            nachcheck.ShowDialog();
                            if (nachcheck.Changed == true)
                            {
                                einsatz = nachcheck.Einsatz;
                                addMarkerToMap(einsatz);
                            }
                        }
                    }
                    else if(import_result=="YesAll")
                    {
                        nachcheck.ShowDialog();
                        if (nachcheck.Changed == true)
                        {
                            einsatz = nachcheck.Einsatz;
                            addMarkerToMap(einsatz);
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                einsatz.Koordinaten = Point;
                GMarkerGoogleType farbe = new GMarkerGoogleType();
                bool createNewMarker= true;

                if (alleOverlay.Markers.Count > 0)
                {
                    foreach (mymarker m in alleOverlay.Markers)
                    {
                        if (m.Einsatz.Adresse.Address == einsatz.Adresse.Address)
                        {
                            m.ToolTipText = m.ToolTipText + Environment.NewLine + einsatz.Alarm_datum + "," + einsatz.Adresse.Address+"," + einsatz.Art + "," + einsatz.Einsatzstichwort;

                            createNewMarker = false;
                        }
                    }
                    if (createNewMarker == true)
                    {
                        createMarker(einsatz, farbe, Point);
                    }
                }
                else
                {
                    createMarker(einsatz, farbe, Point);
                }
            }
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
                case "RWM":
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot;
                    SIZE = 20;
                    break;


                default:
                    farbe = GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow_pushpin;
                    SIZE = 20;
                    break;
            }


            mymarker marker = new mymarker(point_, farbe, einsatz);

            marker.Size = new System.Drawing.Size(10, 10);
            marker.ToolTipText =einsatz.Alarm_datum + "," + einsatz.Adresse.Address + "," + einsatz.Art + "," + einsatz.Einsatzstichwort;

            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new System.Drawing.Size(20, 20);
            marker.Size = new System.Drawing.Size(SIZE, SIZE);

            einsatz.Marker = marker;


            if (einsatz.Einsatzstichwort.Contains("B") && einsatz.Einsatzstichwort != "BSW")
            {
                alleOverlay.Markers.Add(marker);
                brandOverlay.Markers.Add(marker);
            }

            else if (einsatz.Einsatzstichwort.Contains("T"))
            {
                alleOverlay.Markers.Add(marker);
                thOverlay.Markers.Add(marker);
            }
            else
            {
                alleOverlay.Markers.Add(marker);
                andereOverlay.Markers.Add(marker);
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


        public Placemark getname_bypoint(PointLatLng point)
        {
            Placemark adress_= new Placemark();
            try
            {
                GeoCoderStatusCode gcsc = new GeoCoderStatusCode();

                Placemark? name_p = GMapProviders.GoogleMap.GetPlacemark(point, out gcsc);

                if (gcsc == GeoCoderStatusCode.G_GEO_SUCCESS && point != null)
                {
                    adress_ = name_p.Value;
                }
                else
                {
                }

            }
            catch (Exception ex)
            {

            }
            return adress_;
        }

        
        

        private void createrouten_byeinsatz(Einsatz einsatz)
        {
            try
            {
                GDirections directions;
                var xx = GMapProviders.GoogleMap.GetDirections(out directions, (PointLatLng)feuerwehrhausLocation, (PointLatLng)getpoint_byname(einsatz.Adresse.Address), false, false, false, false, false);
                GMapRoute gMapsRoute = new GMapRoute(directions.Route, "My route");
                distanzen.Add(gMapsRoute.Distance);
                distanzen.Sort();
                einsatz.Route = gMapsRoute;
            }
            catch (Exception ex)
            {
                Console.WriteLine("fehler beim routen");
            }
        }

     

        private void LoadDataFromFile(String[] filenames, bool mergeFiles)
        {

            if (mergeFiles == false)
            {
                error_count = 0;
                einsätze.Clear();
                Orte.Clear();
                distanzen.Clear();
                MainMap.Overlays.Clear();

                alleOverlay = new GMapOverlay("alle");
                routesOverlay = new GMapOverlay("routes");

                thOverlay = new GMapOverlay("th");
                brandOverlay = new GMapOverlay("brand");
                andereOverlay = new GMapOverlay("andere");

                MainMap.Overlays.Add(thOverlay);
                MainMap.Overlays.Add(brandOverlay);
                MainMap.Overlays.Add(andereOverlay);
                MainMap.Overlays.Add(alleOverlay);
                MainMap.Overlays.Add(extraOverlay);
            }

            tsPbImportFortschritt.Maximum = filenames.Length;

            UseWaitCursor = true;

            String stichwort;
            String addresse;
            String art;
            String[] Gruppen;

            DateTime alarm_datum;
            DateTime end_datum;

            String[] raw;

            foreach (string names in ofd_main.FileNames)
            {
                tsPbImportFortschritt.Value++;
                using (StreamReader sr = new StreamReader(names, System.Text.Encoding.UTF8))
                {
                    raw = sr.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    raw = raw.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }

                    stichwort = raw[0].Split(new[] { '<', '>' })[2];
                    addresse = raw[1].Split(new[] { '<', '>' })[2];
                    art = raw[4].Split(new[] { '<', '>' })[2];
                    Gruppen = raw[5].Split(new[] { '<', '>' })[2].Split(',');
                
                try
                {
                    alarm_datum = TryCorrectFormat(raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' '));
                    end_datum = TryCorrectFormat(raw[3].Split(new[] { '<', '>' })[2]);
                }
                catch
                {
                    Alarmzeit_Editor AlarmzeitEditor = new Alarmzeit_Editor()
                    {
                        Alarmzeit = raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' '),
                        Einsatzende = raw[3].Split(new[] { '<', '>' })[2]
                    };

                    AlarmzeitEditor.ShowDialog();

                    alarm_datum = DateTime.Parse(AlarmzeitEditor.Alarmzeit);
                    end_datum = DateTime.Parse(AlarmzeitEditor.Einsatzende);

                }
                TimeSpan einsatzDauer = end_datum - alarm_datum;

                if (einsatzDauer.TotalDays>3)
                {
                    Alarmzeit_Editor AlarmzeitEditor = new Alarmzeit_Editor()
                    {
                        Alarmzeit = raw[2].Split(new[] { '<', '>' })[2].TrimEnd(' '),
                        Einsatzende = raw[3].Split(new[] { '<', '>' })[2]
                    };

                    AlarmzeitEditor.ShowDialog();

                    alarm_datum = DateTime.Parse(AlarmzeitEditor.Alarmzeit);
                    end_datum = DateTime.Parse(AlarmzeitEditor.Einsatzende);
                }

                
                bool fehl = false;

                Placemark Adresse = new Placemark();

                try
                {
                    Adresse = TryToGetAddress(addresse);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                List<Fahrzeug> Fahrzeuge = new List<Fahrzeug>();


                foreach (string item in raw)
                {
                    if (!(item.Contains("<stichwort>") || item.Contains("<addresse>") || item.Contains("<anfang>") ||
                        item.Contains("<ende>") || item.Contains("<art>") || item.Contains("<dme>") || item.Contains("<fehl>")))
                    {
                        String Name = item.Substring(1, item.IndexOf(">") - 1);

                        List<Feuerwehrmann> besatzung = new List<Feuerwehrmann>();

                        String BesatzungStringRAW = item.Substring(item.IndexOf(">") + 1, (item.LastIndexOf("<") - item.IndexOf(">")) - 1);


                        foreach (string besatzungsteil in BesatzungStringRAW.Split(';'))
                        {
                            if (besatzungsteil.Length > 0&& besatzungsteil.Length<30)
                            {
                                string name = besatzungsteil;
                                bool isGrf = false;

                                if (name.StartsWith("Gf:"))
                                {
                                    isGrf = true;
                                    name = name.Substring(3, name.Length - 3);
                                }


                                name = Regex.Replace(name, "[^a-zA-Z.,üöä ]", "");

                                if (name.StartsWith("."))
                                {
                                    name = name.TrimStart('.');
                                }

                                if (name.StartsWith(" "))
                                {
                                    name = name.TrimStart(' ');
                                }

                                if (name.EndsWith(" "))
                                {
                                    name = name.TrimEnd(' ');
                                }


                                if (name.EndsWith(","))
                                {
                                    name = name.TrimEnd(',');
                                }

                                besatzung.Add(new Feuerwehrmann(name, isGrf));
                            }
                        }
                        if (besatzung.Count > 0)
                        {
                            if (besatzung.Count == 1)
                            {
                                besatzung[0].Is_gruppenführer = true;
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

                Einsatz einsatz = new Einsatz()
                {
                    Alarm_datum = alarm_datum,
                    End_datum = end_datum,
                    Einsatzstichwort = stichwort,
                    Adresse = Adresse,
                    Art = art,
                    Fehl = fehl,
                    Gruppen = String.Join(";", Gruppen),
                    Koordinaten = getpoint_byname(Adresse.Address),
                    Fahrzeuge=Fahrzeuge
                };
                

                try
                {
                    einsätze.Add(einsatz);

                    if (Adresse.Address != null)
                    {
                        addMarkerToMap(einsatz);
                        createrouten_byeinsatz(einsatz);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex+" "+einsatz.Adresse.LocalityName);
                    continue;

                }
                

                if (!mergeFiles)
                {
                    MainMap.Overlays.Add(routesOverlay);
                }
                
            }

            foreach (Einsatz einsatz in einsätze)
            {
                if (einsatz.Adresse.LocalityName != null)
                {
                    if (Orte.ContainsKey(einsatz.Adresse.LocalityName.ToLower()))
                    {
                        Orte[einsatz.Adresse.LocalityName.ToLower()] = Orte[einsatz.Adresse.LocalityName.ToLower()] + 1;
                    }
                    else
                    {
                        Orte.Add(einsatz.Adresse.LocalityName.ToLower(), 1);
                    }

                }
            }
            Orte = Orte.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            Console.WriteLine("Ort:anzahl der einsätze");

            foreach (KeyValuePair<string, int> data in Orte)
            {
                Console.WriteLine(data.Key + ":" + data.Value);

            }
            PostImportLogic();

        }

        private Placemark TryToGetAddress(String addresse)
        {
            Placemark Address = new Placemark();
            if (addresse.Contains(','))
            {
                if (getpoint_byname(addresse) != PointLatLng.Empty)
                {

                    Address = getname_bypoint(getpoint_byname(addresse));
                }
            }
            else
            {
                if (getpoint_byname(addresse+", Stadthagen") != PointLatLng.Empty)
                {

                    Address = getname_bypoint(getpoint_byname(addresse + ", Stadthagen"));
                }
            }

            if(String.IsNullOrEmpty(Address.Address))
            {
                Correct_Address form2 = new Correct_Address();
                form2.Adresse = addresse;
                form2.ShowDialog();
                addresse = form2.Adresse;

                TryToGetAddress(addresse);


            }


            return Address;
        }




        public DateTime TryCorrectFormat(String to_check)
        {
            DateTime correctedDateTime = DateTime.Now;
            try
            {
                string[] parts = to_check.Split(new[] { ' ' });

                char[] splitChars = new char[] { ' ', ';', ',', ':' };

                parts[0] = splitChars.Aggregate(parts[0], (c1, c2) => c1.Replace(c2, '.'));

                parts[1] = splitChars.Aggregate(parts[1], (c1, c2) => c1.Replace(c2, ':'));


                string joinedString = parts[0] + " " + parts[1];

                correctedDateTime = DateTime.Parse(joinedString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return correctedDateTime;
        }



        private double getaveDistance()
        {
            double durchschnittlicheDistanz = 0;


            distanzen.Sort();
            foreach (double strecke in distanzen)
            {
                durchschnittlicheDistanz += strecke;
                Console.WriteLine(strecke);
            }
            durchschnittlicheDistanz = durchschnittlicheDistanz / distanzen.Count;

            return durchschnittlicheDistanz;
        }


        private double getAveTime()
        {
            double totalTimeInMinutes = 0;

            foreach (Einsatz einsatz in einsätze)
            {
                if ((einsatz.End_datum > einsatz.Alarm_datum)&&(einsatz.End_datum.TimeOfDay.ToString()!="00:00:00"))
                {
                    TimeSpan span = einsatz.End_datum - einsatz.Alarm_datum;

                    totalTimeInMinutes += span.TotalMinutes;
                }
                else
                {

                }
            }

            double aveTime = (totalTimeInMinutes/60)/einsätze.Count;

            return aveTime;
        }



        private double getAvePersonal()
        {
            double totalPersonal = 0;

            foreach (Einsatz einsatz in einsätze)
            {
              foreach(Fahrzeug fahrzeug in einsatz.Fahrzeuge)
                {
                    foreach(Feuerwehrmann feuerwehrmann in fahrzeug.Besatzung)
                    {
                        totalPersonal++;
                    }
                }
            }

            double avePersonal = totalPersonal/einsätze.Count ;

            return avePersonal;
        }




        private void PostImportLogic()
        {
            


            l_proTag.Text =Convert.ToString(Math.Round(((double)einsätze.Count / (double)365), 2));

            l_fahrtweg.Text = Convert.ToString(Math.Round(getaveDistance(), 2));


            l_einsätze_count.Text = Convert.ToString(einsätze.Count);

            l_th_count.Text = Convert.ToString(thOverlay.Markers.Count());
            l_brand_count.Text = Convert.ToString(brandOverlay.Markers.Count());
            l_ubungen.Text = Convert.ToString(andereOverlay.Markers.Count());

            l_ddauer.Text = Convert.ToString(Math.Round(getAveTime(),2));

            l_dkrafte.Text = Convert.ToString(Math.Round(getAvePersonal(),2));

            l_load_error.Text = Convert.ToString(error_count);

            Console.WriteLine(alleOverlay.Markers.Count);


            if (MainMap.Overlays.Contains(alleOverlay))
            {
                MainMap.Overlays[MainMap.Overlays.IndexOf(alleOverlay)].IsVisibile = false;
            }

            tsPbImportFortschritt.Value = 0;

            foreach (Einsatz einsatz in einsätze)
            {
                tsCBEinsätze.Items.Add(einsatz.Einsatzstichwort + "_" + einsatz.Adresse.Address + "_" + einsatz.Alarm_datum);
            }
            tsCBEinsätze.Sorted = true;


            List<PointLatLng> points = new List<PointLatLng>();
            foreach (GMapMarker marker in alleOverlay.Markers)
            {
                points.Add(marker.Position);
            }
            
            UseWaitCursor = false;
        }



     



        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Einsatzstatistik statistikForm = new Einsatzstatistik(einsätze);
            statistikForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            tsCBEinsätze.Sorted = true;

            foreach (Einsatz einsatz in einsätze)
            {
                string stichwort = tsCBEinsätze.Text.Split(new char[] { '_' })[0];
                string adresse = tsCBEinsätze.Text.Split(new char[] { '_' })[1];
                DateTime alarmZeit = Convert.ToDateTime(tsCBEinsätze.Text.Split(new char[] { '_' })[2]);

                if (einsatz.Einsatzstichwort == stichwort
                    && einsatz.Adresse.Address == adresse
                    && einsatz.Alarm_datum == alarmZeit)
                {


                    routesOverlay.Routes.Add(einsatz.Route);

                    Bericht bericht = new Bericht() { einsatz = einsatz };
                    bericht.ShowDialog();

                    if (bericht.Changed == true)
                    {

                        foreach (GMapOverlay overlay in MainMap.Overlays)
                        {
                            overlay.Markers.Remove(einsatz.Marker);
                        }


                        GMarkerGoogleType farbe = new GMarkerGoogleType();


                        PointLatLng point_ = getpoint_byname(einsatz.Adresse.LocalityName);
                        einsatz.Koordinaten = point_;
                        createMarker(einsatz, farbe, point_);


                        //tsCBEinsätze.Items.Clear();
                        //foreach (Einsatz einsatz in einsätze)
                        //{

                        tsCBEinsätze.Items.Add(einsatz.Einsatzstichwort + "_" + einsatz.Adresse.Address + "_" + einsatz.Alarm_datum);
                        //}

                        createrouten_byeinsatz(einsatz);


                        SaveEinsatzToFile(einsatz.Filepath, einsatz);

                    }
                    routesOverlay.Routes.Remove(einsatz.Route);

                    break;
                }
            }
        }
        
        private void MainMap_OnMarkerClick_1(GMapMarker MarkerOnMap, MouseEventArgs e)
        {
            foreach (Einsatz einsatz in einsätze)
            {
                if (einsatz.Koordinaten == MarkerOnMap.Position)
                {
                    Einsatz indexedEinsatz = einsätze[einsätze.IndexOf(einsatz)];
                    routesOverlay.Routes.Add(indexedEinsatz.Route);

                    Bericht bericht = new Bericht() { einsatz = einsatz };

                   
                   bericht.ShowDialog();
                    if (bericht.Changed == true)
                    {
                        bericht.Changed = false;
                        foreach (GMapOverlay overlay in MainMap.Overlays)
                        {
                            if (overlay.Markers.Contains(einsatz.Marker))
                            {
                                overlay.Markers.Remove(einsatz.Marker);
                                overlay.Routes.Remove(einsatz.Route);
                            }

                        }
                        
                        GMarkerGoogleType farbe = new GMarkerGoogleType();


                        PointLatLng point_ = getpoint_byname(einsatz.Adresse.Address);
                        einsatz.Koordinaten = point_;
                        createMarker(einsatz, farbe, point_);


                        tsCBEinsätze.Items.Clear();
                        foreach (Einsatz ein in einsätze)
                        {

                            tsCBEinsätze.Items.Add(ein.Einsatzstichwort + "_" + ein.Adresse.LocalityName + "_" + ein.Alarm_datum);
                        }
                        tsCBEinsätze.Sorted = true;
                        
                        createrouten_byeinsatz(einsatz);


                        SaveEinsatzToFile(einsatz.Filepath, einsatz);
                    }
                    routesOverlay.Routes.Remove(einsatz.Route);
                }
            }
        }


        private void SaveEinsatzToFile(string path, Einsatz einsatz)
        {
            if (File.Exists(path))
            {
                File.Copy(path, path + "_old",true);

            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("<stichwort>" + einsatz.Einsatzstichwort + "</stichwort>");
                sw.WriteLine("<addresse>" + einsatz.Adresse.LocalityName + "</addresse>");
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
            LoadDataFromFile(new string[] { sc.New_file_path }, true);


        }

        private void mannschaftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manschaftsstatisik ms = new Manschaftsstatisik() { Einsätze = einsätze };
            ms.ShowDialog();
        }

       

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void showConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}