using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp.Display
{
    public class Weather
    {
        private int _windSpeedMPH;
        private int _windSpeedKPH;
        private bool _hasWindSpeed = false;
        private WindDirection _windDirection;
        private bool _hasWindDirection = false;
        private int _tempCelsius;
        private int _tempFahrenheit;

        public enum WindDirection { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }

        public float TempKelvin
        {
            set
            {
                _tempCelsius = (int)Math.Round(value - 273.15f, MidpointRounding.AwayFromZero);
                _tempFahrenheit = (int)Math.Round((value * (9.00f / 5.00f)) - 459.67f, MidpointRounding.AwayFromZero);
            }
        }

        public int TempCelsius
        {
            get
            {
                return _tempCelsius;
            }
        }

        public int TempFahrenheit
        {
            get
            {
                return _tempFahrenheit;
            }
        }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public bool HasCompleteWindData
        {
            get
            {
                return _hasWindSpeed && _hasWindDirection;
            }
        }

        public float WindSpeedMps // metres per second
        {
            set
            {
                _windSpeedKPH = (int)Math.Round(value * 3.600f, MidpointRounding.AwayFromZero);
                _windSpeedMPH = (int)Math.Round(value * 2.23694f, MidpointRounding.AwayFromZero);
                _hasWindSpeed = true;
            }
        }

        public int WindSpeedKPH
        {
            get
            {
                return _windSpeedKPH;
            }
        }

        public int WindSpeedMPH
        {
            get
            {
                return _windSpeedMPH;
            }
        }

        public WindDirection WindDirection1
        { 
            get
            {
                return _windDirection;
            }
            set
            {
                _windDirection = value;
                _hasWindDirection = true;
            }
        }

        public DisplayState State { get; set; }
    }
}
