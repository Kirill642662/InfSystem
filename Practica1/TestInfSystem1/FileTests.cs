using InfSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInfSystem1
{
    public class FileTests: IDisposable
    {
        private readonly string _path = Path.GetTempFileName();

        public void Dispose() => File.Delete(_path);

        [Fact]
        public void Write_Then_Read_Humidaty()
        {
            var file = new WeatherFile(_path);
            var h = new Humidaty
            {
                Type = "Влажность",
                Date = new DateTime(2026, 8, 9),
                Place = "Красноярск",
                TemperatureValue = 26,
                HumidatyValue = 70
            };

            file.Write(h);
            var restored = file.Read();

            var r = Assert.IsType<Humidaty>(restored);
            Assert.Equal("Красноярск", r.Place);
            Assert.Equal(70m, r.HumidatyValue);
        }

        [Fact]
        public void Read_MissingFile_Throws()
        {
            var file = new WeatherFile(_path);
            File.Delete(_path);
            Assert.Throws<WeatherFileException>(() => file.Read());
        }

        [Fact]
        public void Read_TooFewLines_Throws()
        {
            File.WriteAllLines(_path, new[] { "Влажность", "2026-08-09" });
            var file = new WeatherFile(_path);
            Assert.Throws<NonCorrectFormatException>(() => file.Read());
        }

        [Fact]
        public void Read_UnknownType_Throws()
        {
            File.WriteAllLines(_path, new[] { "Что-то", "2026-08-09", "Город", "26", "70" });
            var file = new WeatherFile(_path);
            Assert.Throws<UnknowWeatherTypeException>(() => file.Read());
        }
    }
}
