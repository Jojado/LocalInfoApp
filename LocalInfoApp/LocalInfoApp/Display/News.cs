using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp.Display
{
    public class News
    {
        private static News _sampleNews = new News
        {
            NewsText = "Here is the local news",
            State = DisplayState.Offline
        };

        public string NewsText { get; set; }

        public DisplayState State { get; set; }

        public static News GetSampleData()
        {
            return _sampleNews;
        }
    }
}
