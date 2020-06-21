using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp.Display
{
    public class SportsNews
    {
        private static SportsNews _sampleSportsNews = new SportsNews
        {
            SportsNewsText = "Here is the sports news",
            State = DisplayState.Offline
        };

        public string SportsNewsText { get; set; }

        public DisplayState State { get; set; }

        public static SportsNews GetSampleData()
        {
            return _sampleSportsNews;
        }
    }
}
