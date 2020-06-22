using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp.Display
{
    public class Weather
    {
        public enum WindDirection { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }

        public float TempCelsius { get; set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public bool HasWindData { get; set; }

        public int WindSpeedKPH { get; set; }

        public WindDirection WindDirection1 { get; set; }

        public DisplayState State { get; set; }
    }
}
