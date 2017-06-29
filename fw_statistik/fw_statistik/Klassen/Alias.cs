using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_statistik
{
    public class Alias
    {
        public Alias(string Name, List<string> Aliase)
        {
            name = Name;
            aliase = Aliase;
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


        private List<string> aliase;
        public List<string> Aliase
        {
            get
            {
                return aliase;
            }
            set
            {
                aliase = value;
            }
        }



    }

}
