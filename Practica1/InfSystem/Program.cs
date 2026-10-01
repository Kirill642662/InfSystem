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
        public static void MyReadFromFile()
        {
            string fileName = "C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\InfSystem\\ReadFromFile.txt";
            string[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding(1251));
            string type = lines[0].Trim();

            Weather weather;
            switch (type)
            {
                case "Влажность":
                    weather = new Humidaty();
                    break;
                case "Давление":
                    weather = new Pressure();
                    break;
                default:
                    weather = new Weather();
                    break;
            }

            weather.FromFile(lines, 1);

            Console.WriteLine($"Тип: {type}");
            Console.WriteLine($"Дата: {weather.Date:yyyy-MM-dd}");
            Console.WriteLine($"Место: {weather.Place}");
            if (weather.TemperatureValue < 0)
                Console.WriteLine($"Температура: {weather.TemperatureValue}°C");
            else
                Console.WriteLine($"Температура: +{weather.TemperatureValue}°C");

            if (weather is Humidaty h)
                Console.WriteLine($"Влажность: {h.HumidatyValue}%");
            else if (weather is Pressure p)
                Console.WriteLine($"Давление: {p.PressureValue}%");
        }

        public static Weather GetType(string str)
        {
            string[] strParse = str.Trim().Split(' ');
            Weather res = new Weather();
            switch (strParse[0])
            {
                case "Влажность":
                    res = new Humidaty();
                    return res;
                case "Давление":
                    res = new Pressure();
                    return res;
            }
            return res;

        }

        public static void PrintGraph()
        {
            var graph = new Dictionary<string, List<string>>();
            string[] separator = { "--|>", "0->" };

            foreach (var line in File.ReadAllLines("C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\InfSystem\\graph.txt"))
            {
                string[] parts = line.Split(separator, StringSplitOptions.None);

                string from = parts[0].Trim();
                string to = parts[1].Trim();

                if (!graph.ContainsKey(from))
                    graph[from] = new List<string>();
                if (!graph.ContainsKey(to))
                    graph[to] = new List<string>();

                graph[from].Add(to);
            }
            foreach (var kv in graph)
                Console.WriteLine($"{kv.Key}, [{string.Join(", ", kv.Value)}]");
        }
        static void Main(string[] args)
        {
            List<Weather> list = new List<Weather>();

            Console.WriteLine("Выберите действие, которое желаете выполнить:");
            while (true)
            {
                Console.WriteLine("1. Ввести данные о погоде");
                Console.WriteLine("2. Вывести данные о погоде, которые сохранили");
                Console.WriteLine("3. Загрузить данные о погоде с файла");
                Console.WriteLine("4. Показать ГРАФ");
                Console.WriteLine("0. Выйти с программы!");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        list.Clear();
                        Console.WriteLine("1. Пример: Погода 2026.08.09 Красноярск +24 70%");
                        string choose = Console.ReadLine();
                        Weather weather = GetType(choose);
                        weather.FromStr(choose);
                        list.Add(weather);
                        break;
                    case "2":
                        foreach (Weather p in list)
                        {
                            Console.WriteLine(p.ToString());
                        }
                        break;
                    case "3":
                        MyReadFromFile();
                        break;
                    case "4":
                        PrintGraph();
                        break;
                    case "0":
                        return;
                    default:
                        break;
                }
            }
        }
    } 
}
