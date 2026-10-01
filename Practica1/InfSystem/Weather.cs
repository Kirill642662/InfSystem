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
        public decimal TemperatureValue { get; set; }
        public string Type {  get; set; }
        public virtual void FromStr(string text)
        {
            string[] entry = text.Trim().Split(' ');
            Type = entry[0];
            Date = DateTime.Parse(entry[1]);
            Place = entry[2];
            TemperatureValue = decimal.Parse(entry[3]);
        }
        public virtual void InFile()
        {
            string[] lines = {
                "Weather",
                Date.ToString("yyyy-MM-dd"),
                Place,
                TemperatureValue.ToString()
            };
            File.WriteAllLines("C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\InfSystem\\file.txt", lines);
        }

        public virtual void FromFile(string[] lines, int startIndex = 0)
        {
            Date = DateTime.Parse(lines[startIndex]);
            Place = lines[startIndex + 1];
            TemperatureValue = decimal.Parse(lines[startIndex + 2]);
        }

        public virtual string ToString()
        {
            return $"{Type}, {Date.ToString("yyyy:MM:dd")}, {Place}, {TemperatureValue}";
        }
    }
}
