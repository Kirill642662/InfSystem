using System;
using System.IO;
using InfSystem;
using Xunit;
namespace TestInfSystem1
{
    public class ParsersTests
    {
        [Fact]
        public void Parse_Humidaty_Ok()
        {
            var h = new Humidaty();
            h.FromStr("Влажность 2026.08.09 Красноярск 26 70");

            Assert.Equal("Красноярск", h.Place);
            Assert.Equal(26m, h.TemperatureValue);
            Assert.Equal(70m, h.HumidatyValue);
        }

        [Fact]
        public void Parse_Pressure_Ok()
        {
            var p = new Pressure();
            p.FromStr("Давление 2026.08.09 Красноярск 26 70");
            Assert.Equal(70m, p.PressureValue);
        }

        [Fact]
        public void Parse_Empty_Throws()
        {
            var w = new Weather();
            Assert.Throws<NonCorrectFormatException>(() => w.FromStr(""));
        }

        [Fact]
        public void Parse_TooFewFields_Throws()
        {
            var w = new Weather();
            Assert.Throws<NonCorrectFormatException>(() => w.FromStr("Погода 2026.08.09"));
        }

        [Fact]
        public void Parse_BadDate_Throws()
        {
            var w = new Weather();
            Assert.Throws<NonCorrectFormatException>(
                () => w.FromStr("Погода вчера Красноярск 24"));
        }

        [Fact]
        public void Parse_BadNumber_Throws()
        {
            var w = new Weather();
            Assert.Throws<NonCorrectFormatException>(
                () => w.FromStr("Погода 2026.08.09 Красноярск abc"));
        }

        [Fact]
        public void Parse_Humidaty_NoValue_Throws()
        {
            var h = new Humidaty();
            Assert.Throws<NonCorrectFormatException>(
                () => h.FromStr("Влажность 2026.08.09 Красноярск 26"));
        }
    }
}