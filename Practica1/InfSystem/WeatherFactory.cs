namespace InfSystem
{
    public static class WeatherFactory
    {
        public static Weather Create(string type)
        {
            switch (type)
            {
                case "Погода": return new Weather();
                case "Влажность": return new Humidaty();
                case "Давление": return new Pressure();
                default:
                    throw new UnknowWeatherTypeException(type);
            }
        }
    }
}
