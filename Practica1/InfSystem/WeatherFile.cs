using System;
using System.Collections.Generic;
using System.IO;


namespace InfSystem
{
    public class WeatherFile
    {
        private readonly string _filePath;

        public WeatherFile(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(Weather weather)
        {
            try
            {
                string[] lines = CreateLines(weather);
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception ex)
            {
                throw new WeatherFileException("Ошибка записи файла:" + ex.Message);
            }
        }

        public Weather Read()
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(_filePath);
            }
            catch (Exception ex)
            {
                throw new WeatherFileException("Ошибка считывание файла:" + ex.Message);
            }

            if (lines.Length < 4)
                throw new NonCorrectFormatException("В файле мало строк");
            
            string type = lines[0].Trim();
            Weather weather = WeatherFactory.Create(type);
            weather.Type = type;
            weather.Date = Weather.ParseDate(lines[1]);
            weather.Place = lines[2].Trim();
            weather.TemperatureValue = Weather.ParseNumber(lines[3], "температура");

            if (weather is Humidaty h)
            {
                if (lines.Length < 5)
                    throw new NonCorrectFormatException("В файле нет влажности");
                h.HumidatyValue = Weather.ParseNumber(lines[4], "влажность");
            }

            else if (weather is Pressure p)
            {
                if (lines.Length < 5)
                    throw new NonCorrectFormatException("В файле нет давления");
                p.PressureValue = Weather.ParseNumber(lines[4], "давление");
            }

            return weather;
        }

        private string[] CreateLines(Weather weather) //принимает именно []
        {
            var lines = new List<string>
            {
                weather.Type,
                weather.Date.ToString("yyyy-MM-dd"),
                weather.Place,
                weather.TemperatureValue.ToString()
            };

            if (weather is Humidaty h)
                lines.Add(h.HumidatyValue.ToString());
            else if (weather is Pressure p)
                lines.Add(p.PressureValue.ToString());
            return lines.ToArray(); 
        }
    }
}
