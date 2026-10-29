using InfSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInfSystem1
{
    public class FactoryTests
    {
        [Fact]
        public void Create_Humidaty_Ok()
        {
            Assert.IsType<Humidaty>(WeatherFactory.Create("Влажность"));
        }

        [Fact]
        public void Create_Unknown_Throws()
        {
            Assert.Throws<UnknowWeatherTypeException>(
                () => WeatherFactory.Create("Что-то"));
        }
    }
}
