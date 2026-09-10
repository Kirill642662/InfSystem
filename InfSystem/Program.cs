using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InfSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Измерение температуры\nВведите свои параметры (дата, место измерения и значение)");
            string input = Console.ReadLine();
            Weather weather = new Weather();
            weather.FromStr(input);
            string[] lines = { $"{weather.Date}\n{weather.Place}\n{weather.TemperatureValue}" };
            File.WriteAllLines("file.txt", lines);
        }
    }
}
