namespace InfSystem
{
    public class Humidaty: Weather
    {
        public decimal HumidatyValue { get; set; }
        public override void FromStr(string text)
        {
            base.FromStr(text);
            string [] entry = text.Trim().Split(' ');
            if (entry.Length < 5)
                throw new NonCorrectFormatException("Нет значения влажности");
            HumidatyValue = ParseNumber(entry[4], "влажность");
        }
        
        public override string ToString()
        {
            return $"{Type}, {Date:yyyy: MM: dd}, {Place}, {TemperatureValue}, {HumidatyValue}";
        }
    }
}
