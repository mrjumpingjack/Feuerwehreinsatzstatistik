using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fw_statistik
{
    public class mymarker : GMarkerGoogle
    {

        public mymarker(PointLatLng pos_, GMarkerGoogleType type, Einsatz einsatz_) : base(pos_, type)
        {
            pos = pos_;
            einsatz = einsatz_;

        }

        private PointLatLng pos;   // the name field
        public PointLatLng Pos   // the Name property
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }



        private Einsatz einsatz;   // the name field
        public Einsatz Einsatz   // the Name property
        {
            get
            {
                return einsatz;
            }
            set
            {
                einsatz = value;
            }
        }


    }

}
