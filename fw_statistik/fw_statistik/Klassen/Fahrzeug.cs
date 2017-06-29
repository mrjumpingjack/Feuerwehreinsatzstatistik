using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_statistik
{
    public class Fahrzeug
    {
        public Fahrzeug(String Name, List<Feuerwehrmann> Besatzung)
        {
            name = Name;
            besatzung = Besatzung;
        }

        private String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }



        private List<Feuerwehrmann> besatzung;
        public List<Feuerwehrmann> Besatzung
        {
            get
            {
                return besatzung;
            }
            set
            {
                besatzung = value;
            }
        }

    }


}
