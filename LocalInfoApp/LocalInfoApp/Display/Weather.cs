using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp.Display
{
    public class Weather
    {
        private static Weather _sampleData = new Weather()
        {
            City = "City Name",
            Conditions = "Conditions",
            TempCelsius = 0,
            TimeOfReading = new DateTime(2001, 1, 1),
            HasWindData = true,
            WindDirection1 = WindDirection.North,
            WindSpeedKPH = 0,
            State = DisplayState.Offline
        };

        public enum WindDirection { North, NorthEast, East, SouthEast, South, SouthWest, West, NorthWest }

        public float TempCelsius { get; set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public bool HasWindData { get; set; }

        public int WindSpeedKPH { get; set; }

        public WindDirection WindDirection1 { get; set; }

        public DisplayState State { get; set; }

        public static Weather GetSampleData()
        {
            return _sampleData;
        }
    }
}
