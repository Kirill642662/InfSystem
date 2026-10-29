namespace InfSystem
{
    public class Pressure: Weather
    {
        public decimal PressureValue { get; set; }
        public override void FromStr(string text)
        {
            base.FromStr(text);
            string[] entry = text.Trim().Split(' ');
            if (entry.Length < 5)
                throw new NonCorrectFormatException("Нет значения давления");
            PressureValue = ParseNumber(entry[4], "давление");
        }
        
        public override string ToString()
        {
            return $"{Type}, {Date:yyyy:MM:dd}, {Place}, {TemperatureValue}, {PressureValue}";
        }
    }
}
