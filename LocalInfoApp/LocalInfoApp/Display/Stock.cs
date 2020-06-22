

namespace LocalInfoApp.Display
{
    public class Stock : IDisplayState
    {
        public string CompanyName { get; set; }

        public string ExchangeSymbol { get; set; }

        public string CompanySymbol { get; set; }

        public float Close { get; set; }

        public string Currency { get; set; }

        public float Change { get; set; }

        public float ChangePercentage { get; set; }

        public bool Gain { get; set; }

        public DisplayState State { get; set; }
    }
}
