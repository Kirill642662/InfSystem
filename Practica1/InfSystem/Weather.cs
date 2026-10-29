using System;


namespace InfSystem
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal TemperatureValue { get; set; }
        public string Type {  get; set; }


        public virtual void FromStr(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new NonCorrectFormatException("Пустая строка");

            string[] entry = text.Trim().Split(' ');
            if (entry.Length < 4)
                throw new NonCorrectFormatException("Нужно минимум 4 параметра");

            Type = entry[0];
            Date = ParseDate(entry[1]);
            Place = entry[2];
            TemperatureValue = ParseNumber(entry[3], "температура");
        }

        public static DateTime ParseDate(string date)
        {
            if(DateTime.TryParse(date, out var result))
                return result;
            throw new NonCorrectFormatException("Неверная дата");
        }
        public static decimal ParseNumber(string num, string type)
        {
            if(decimal.TryParse(num, out var result)) return result;
            throw new NonCorrectFormatException($"Неверное число {type}");
        }

        public override string ToString()
        {
            return $"{Type}, {Date:yyyy:MM:dd}, {Place}, {TemperatureValue}";
        }
    }
}
