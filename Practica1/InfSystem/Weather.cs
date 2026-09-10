using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfSystem
{
    internal class Weather
    {
        public DateTime Date {  get; set; }
        public string Place {  get; set; }
        public float TemperatureValue {  get; set; }

        public Weather()
        {

        }
        public void FromStr(string f)
        {
            string[] entry = f.Trim().Split(' ');
            Date = DateTime.Parse(entry[0]);
            Place = entry[1];
            TemperatureValue = float.Parse(entry[2]);
        }
    }
}
