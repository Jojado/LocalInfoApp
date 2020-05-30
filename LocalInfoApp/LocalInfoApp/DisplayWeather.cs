using System;

namespace LocalInfoApp
{
    public class DisplayWeather
    {
        public float TempCelsius { get; set; }

        public string Conditions { get; set; }

        public DateTime TimeOfReading { get; set; }

        public string City { get; set; }

        public static DisplayWeather CreateTestData()
        {
            return new DisplayWeather()
            {
                City = "City Test",
                Conditions = "Conditions Test",
                TempCelsius = 10,
                TimeOfReading = new DateTime(2001, 1, 1)
            };
        }
    }
}
