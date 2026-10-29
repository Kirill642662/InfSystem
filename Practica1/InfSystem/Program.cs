using System;
using System.Collections.Generic;


namespace InfSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Win10\\Desktop\\InfSystem\\Practica1\\InfSystem\\file.txt";
            var myFile = new WeatherFile(filePath);
            var list = new List<Weather>();

            while (true)
            {
                PrintMenu();
                string choose = Console.ReadLine();

                try
                {
                    switch (choose)
                    {
                        case "1":
                            list.Clear();
                            Console.WriteLine("Пример: Влажность 1111.01.01 Простоквашино 26 70");
                            AddWeatherFromConsole(list);
                            break;
                        case "2":
                            if (list.Count == 0)
                            {
                                Console.WriteLine("Список пуст!");
                                break;
                            }
                            foreach (Weather weather in list)
                                PrintWeather(weather);
                            break;
                        case "3":
                            Weather fromFile = myFile.Read();
                            PrintWeather(fromFile);
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Не знаю такую команду");
                            break;
                    }
                }
                catch (WeatherException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1. Ввести данные");
            Console.WriteLine("2. Показать данные");
            Console.WriteLine("3. Загрузить из файла");
            Console.WriteLine("0. выйти");
        }
        private static void AddWeatherFromConsole(List<Weather> list)
        {
            string input = Console.ReadLine();
            string[] line = input.Trim().Split(' ');
            Weather w = WeatherFactory.Create(line[0]);
            w.FromStr(input);
            list.Add(w);
        }
        private static void PrintWeather(Weather weather)
        {
            Console.WriteLine($"Тип:  {weather.Type}");
            Console.WriteLine($"Дата: {weather.Date:yyyy:MM:dd}");
            Console.WriteLine($"Место:  {weather.Place}");
            Console.WriteLine($"Температура:  {weather.TemperatureValue}");

            if (weather is Humidaty h)
                Console.WriteLine($"Влажность: { h.HumidatyValue}%");
            else if (weather is Pressure p)
                Console.WriteLine($"Давление: {p.PressureValue}%");
        }
    } 
}
