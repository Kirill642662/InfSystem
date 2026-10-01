using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfSystem
{
    internal class Humidaty: Weather
    {
        public decimal HumidatyValue { get; set; }
        public override void FromStr(string text)
        {
            base.FromStr(text);
            string [] entry = text.Trim().Split(' ');
            HumidatyValue = decimal.Parse(entry[4]);
        }
        public override void InFile()
        {
            string[] lines = {
                "Humidaty",
                Date.ToString("yyyy-MM-dd"),
                Place,
                TemperatureValue.ToString(),
                HumidatyValue.ToString()
            };
            File.WriteAllLines("C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\InfSystem\\file.txt", lines);
        }
        public override void FromFile(string[] lines, int startIndex = 0)
        {
            base.FromFile(lines, startIndex);
            HumidatyValue = decimal.Parse(lines[startIndex +3]);
        }

        public override string ToString()
        {
            return $"{Type}, {Date.ToString("yyyy: MM: dd")}, {Place}, {TemperatureValue}, {HumidatyValue}";
        }
    }
}
