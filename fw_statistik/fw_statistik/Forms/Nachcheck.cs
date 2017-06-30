using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fw_statistik
{
    public partial class Ortsüberprüfung : Form
    {
        public Ortsüberprüfung()
        {
            InitializeComponent();
        }

        public Einsatz Einsatz { get; set; }

        public bool Changed { get; set; }


        private void button2_Click(object sender, EventArgs e)
        {
            Changed = false;
            Close();
        }


        private void Nachcheck_Load(object sender, EventArgs e)
        {
            try
            {
                tbOrt.Text = Einsatz.Adresse.LocalityName;
            }
            catch
            {

            }
            try
            {
                tbStraße.Text = Einsatz.Adresse.ThoroughfareName;
            }
            catch
            {

            }
            try
            {
                tbHausnummer.Text = Einsatz.Adresse.HouseNo;
            }
            catch
            {

            }

            try
            {
                tb_alarmzeit.Text = Einsatz.Alarm_datum.ToString();
            }
            catch
            {

            }
            try
            {
                tb_einsatzende.Text = Einsatz.End_datum.ToString();
            }
            catch
            {

            }

            
           


        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Einsatz.Adresse= getname_bypoint(getpoint_byname(tbStraße.Text + " " + tbHausnummer.Text + "," + tbOrt.Text));
            Einsatz.End_datum = DateTime.Parse(tb_einsatzende.Text);
            Einsatz.Alarm_datum = DateTime.Parse(tb_alarmzeit.Text);
            Changed = true;
            Close();
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
            Placemark adress_ = new Placemark();
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

    }
}
