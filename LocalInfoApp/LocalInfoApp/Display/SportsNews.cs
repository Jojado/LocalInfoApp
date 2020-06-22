using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp.Display
{
    public class SportsNews : IDisplayState
    {
        public string SportsNewsText { get; set; }

        public DisplayState State { get; set; }
    }
}
