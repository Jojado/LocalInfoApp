using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp.Display
{
    public class Weather
    {
        private WindDirection _windDirection;

        public enum WindDirection { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }

        public float TempKelvin
        {
            set
            {
                TempCelsius = (int)Math.Round(value - 273.15f, MidpointRounding.AwayFromZero);
                TempFahrenheit = (int)Math.Round((value * (9.00f / 5.00f)) - 459.67f, MidpointRounding.AwayFromZero);
            }
        }

        public int TempCelsius { get; private set; }

        public int TempFahrenheit { get; private set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public bool HasCompleteWindData
        {
            get
            {
                return HasWindSpeed && HasWindDirection;
            }
        }

        public bool HasWindSpeed { get; private set; } = false;

        public bool HasWindDirection { get; private set; } = false;

        public float WindSpeedMps // metres per second
        {
            set
            {
                WindSpeedKPH = (int)Math.Round(value * 3.600f, MidpointRounding.AwayFromZero);
                WindSpeedMPH = (int)Math.Round(value * 2.23694f, MidpointRounding.AwayFromZero);
                HasWindSpeed = true;
            }
        }

        public int WindSpeedKPH { get; private set; }

        public int WindSpeedMPH { get; private set; }

        public WindDirection WindDirection1
        {
            get
            {
                return _windDirection;
            }
            set
            {
                _windDirection = value;
                HasWindDirection = true;
            }
        }

        public DisplayState State { get; set; }
    }
}
