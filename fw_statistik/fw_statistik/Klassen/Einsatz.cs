using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_statistik
{
    public class Einsatz
    {
        public Einsatz(string filepath,
            DateTime alarm_datum,
            DateTime end_datum,
            string einsatzstichwort = "",
            string ges_Adresse = "Stadthagen",
            string ort = "Stadthagen",
            string straße = "",
            string hausnummer = "",
            string art = "",
            bool fehl = false,
            string gruppen = "",
            PointLatLng coor_ = new PointLatLng()

            )
        {
            Filepath = filepath;
            Coor = coor_;
            Alarm_datum = alarm_datum;
            End_datum = end_datum;
            Einsatzstichwort = einsatzstichwort;
            Ort = ort;
            Art = art;
            Straße = straße;
            Hausnummer = hausnummer;
            Fehl = fehl;
            Gruppen = gruppen;
            Ges_addresse = ges_Adresse;

        }


        private PointLatLng coor;
        public PointLatLng Coor
        {
            get
            {
                return coor;
            }
            set
            {
                coor = value;
            }
        }

        private GMapMarker marker;
        public GMapMarker Marker
        {
            get
            {
                return marker;
            }
            set
            {
                marker = value;
            }
        }





        private GMapRoute route;
        public GMapRoute Route
        {
            get
            {
                return route;
            }
            set
            {
                route = value;
            }
        }


        private List<Fahrzeug> fahrzeuge;
        public List<Fahrzeug> Fahrzeuge
        {
            get
            {
                return fahrzeuge;
            }
            set
            {
                fahrzeuge = value;
            }
        }



        private DateTime alarm_datum;
        public DateTime Alarm_datum
        {
            get
            {
                return alarm_datum;
            }
            set
            {
                alarm_datum = value;
            }
        }

        private DateTime end_datum;
        public DateTime End_datum
        {
            get
            {
                return end_datum;
            }
            set
            {
                end_datum = value;
            }
        }


        private string einsatzstichwort;
        public string Einsatzstichwort
        {
            get
            {
                return einsatzstichwort;
            }
            set
            {
                einsatzstichwort = value;
            }
        }



        private string filepath;
        public string Filepath
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
            }
        }


        private string straße;
        public string Straße
        {
            get
            {
                return straße;
            }
            set
            {
                straße = value;
            }
        }

        private string hausnummer;
        public string Hausnummer
        {
            get
            {
                return hausnummer;
            }
            set
            {
                hausnummer = value;
            }
        }



        private string ort;
        public string Ort
        {
            get
            {
                return ort;
            }
            set
            {
                ort = value;
            }
        }

        private string ges_addresse;
        public string Ges_addresse
        {
            get
            {
                return ges_addresse;
            }
            set
            {
                ges_addresse = value;
            }
        }

        private string art;
        public string Art
        {
            get
            {
                return art;
            }
            set
            {
                art = value;
            }
        }


        private bool fehl;
        public bool Fehl
        {
            get
            {
                return fehl;
            }
            set
            {
                fehl = value;
            }
        }

        private string gruppen;
        public string Gruppen
        {
            get
            {
                return gruppen;
            }
            set
            {
                gruppen = value;
            }
        }
    }


}
