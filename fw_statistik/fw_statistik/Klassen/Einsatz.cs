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
            string einsatzstichwort,
            Placemark adresse,
            //string ges_Adresse = "Stadthagen",
            //string ort = "Stadthagen",
            //string straße = "",
            //string hausnummer = "",
            string art,
            bool fehl,
            string gruppen,
            PointLatLng coor_

            )
        {
            Adresse = adresse;
            Filepath = filepath;
            Coor = coor_;
            Alarm_datum = alarm_datum;
            End_datum = end_datum;
            Einsatzstichwort = einsatzstichwort;
          //  Ort = ort;
            Art = art;
          //  Straße = straße;
           // Hausnummer = hausnummer;
            Fehl = fehl;
            Gruppen = gruppen;
           // .Adresse.LocalityName = ges_Adresse;

        }



        private Placemark adresse;
        public Placemark Adresse
        {
            get
            {
                return adresse;
            }
            set
            {
                adresse = value;
            }
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


        //private string straße;
        //public string Straße
        //{
        //    get
        //    {
        //        return straße;
        //    }
        //    set
        //    {
        //        straße = value;
        //    }
        //}

        //private string hausnummer;
        //public string Hausnummer
        //{
        //    get
        //    {
        //        return hausnummer;
        //    }
        //    set
        //    {
        //        hausnummer = value;
        //    }
        //}



        //private string ort;
        //public string Ort
        //{
        //    get
        //    {
        //        return ort;
        //    }
        //    set
        //    {
        //        ort = value;
        //    }
        //}

        //private string .Adresse.LocalityName;
        //public string .Adresse.LocalityName
        //{
        //    get
        //    {
        //        return .Adresse.LocalityName;
        //    }
        //    set
        //    {
        //        .Adresse.LocalityName = value;
        //    }
        //}

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
