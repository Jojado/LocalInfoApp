using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp.Display
{
    public class News : IDisplayState
    {
        public string NewsText { get; set; }

        public DisplayState State { get; set; }
    }
}
