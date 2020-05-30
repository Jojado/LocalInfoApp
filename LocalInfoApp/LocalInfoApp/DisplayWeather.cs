using System;
using LocalInfoApp.Properties;

namespace LocalInfoApp
{
    public class DisplayWeather
    {
        public float TempCelsius { get; set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public static DisplayWeather CreateSampleData()
        {
            return new DisplayWeather()
            {
                City = "City Name",
                Conditions = "Conditions",
                TempCelsius = 0,
                TimeOfReading = new DateTime(2001, 1, 1)
            };
        }
    }
}
