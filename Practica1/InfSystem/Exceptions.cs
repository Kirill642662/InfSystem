using System;

namespace InfSystem
{
    public class WeatherException : Exception //все исключения
    {
        public WeatherException(string mes): base(mes) { }
    }
    public class NonCorrectFormatException : WeatherException //Неверный формат
    {
        public NonCorrectFormatException(string mes) : base(mes) { }
    }
    public class UnknowWeatherTypeException : WeatherException
    {
        public UnknowWeatherTypeException(string type)
            : base($"Неизвестный тип: {type}") { }
    }
    public class WeatherFileException : WeatherException
    {
        public WeatherFileException(string mes): base (mes) { }
    }
}
