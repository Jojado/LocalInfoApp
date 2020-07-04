using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp.Display
{
    public class Weather
    {
        private float _temperatureDegreesKelvin;
        private float _windSpeedMetresPerSecond;

        public enum WindDirection { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }

        public void SetTemp(float degreesKelvin)
        {
            _temperatureDegreesKelvin = degreesKelvin;
        }

        public int GetTempCelsius()
        {
            return (int) Math.Round(_temperatureDegreesKelvin - 273.15f, MidpointRounding.AwayFromZero);
        }

        public int GetTempFahrenheit()
        {
            return (int) Math.Round((_temperatureDegreesKelvin * (9.00f / 5.00f)) - 459.67f, MidpointRounding.AwayFromZero);
        }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public bool HasWindData { get; set; }

        public void SetWindSpeed(float metresPerSecond)
        {
            _windSpeedMetresPerSecond = metresPerSecond;
        }

        public int GetWindSpeedKPH()
        {
            return (int) Math.Round(_windSpeedMetresPerSecond * 3.6f, MidpointRounding.AwayFromZero);
        }

        public int GetWindSpeedMPH()
        {
            return (int) Math.Round(_windSpeedMetresPerSecond * 2.23694f, MidpointRounding.AwayFromZero);
        }

        public WindDirection WindDirection1 { get; set; }

        public DisplayState State { get; set; }
    }
}
