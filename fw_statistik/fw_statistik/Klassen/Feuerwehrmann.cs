using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_statistik
{
    public class Feuerwehrmann
    {
        public Feuerwehrmann(String Name, bool Is_grpf)
        {
            name = Name;
            is_gruppenführer = Is_grpf;
        }



        private string name;   // the name field
        public string Name   // the Name property
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

        private bool is_gruppenführer;   // the name field
        public bool Is_gruppenführer   // the Name property
        {
            get
            {
                return is_gruppenführer;
            }
            set
            {
                is_gruppenführer = value;
            }
        }
    }
}
