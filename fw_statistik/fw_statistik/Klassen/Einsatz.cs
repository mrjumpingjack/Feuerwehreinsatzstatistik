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
        public Einsatz()
        {
          
        }


        public Placemark Adresse { get; set; }


        public PointLatLng Koordinaten { get; set; }

        public GMapMarker Marker { get; set; }

        public GMapRoute Route { get; set; }


        public List<Fahrzeug> Fahrzeuge { get; set; }


        public DateTime Alarm_datum { get; set; }

        public DateTime End_datum { get; set; }

        public String Einsatzstichwort { get; set; }

        public string Filepath { get; set; }

        public string Art { get; set; }

        public bool Fehl { get; set; }

        public string Gruppen { get; set; }


    }
}
