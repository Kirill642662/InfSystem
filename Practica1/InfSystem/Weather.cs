using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfSystem
{
    internal class Weather
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal TemperatureValue {  get; set; }


        public virtual void FromStr(string text)
        {
            string[] entry = text.Trim().Split(' ');
            Date = DateTime.Parse(entry[0]);
            Place = entry[1];
            TemperatureValue = decimal.Parse(entry[2]);
        }
        public void InFile()
        {
            string[] lines = { $"{Date.ToString("yyyy-MM-dd")}\n{Place}\n{TemperatureValue}" };
            File.WriteAllLines("file.txt", lines);
        }


    }
}
