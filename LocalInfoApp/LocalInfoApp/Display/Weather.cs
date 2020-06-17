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
            TimeOfReading = new DateTime(2001, 1, 1)
        };

        public float TempCelsius { get; set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public static Weather GetSampleData()
        {
            return _sampleData;
        }
    }
}
