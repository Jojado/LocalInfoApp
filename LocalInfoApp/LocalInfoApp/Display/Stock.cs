

namespace LocalInfoApp.Display
{
    public class Stock
    {
        private static Stock _sampleStock = new Stock
        {
            Change = 0.45f,
            ChangePercentage = 2.21f,
            Close = 20.35f,
            CompanyName = "Company Inc.",
            CompanySymbol = "CMP",
            Currency = "USD",
            ExchangeSymbol = "ABC",
            Gain = true,
            State = DisplayState.NoKey
        };

        public string CompanyName { get; set; }

        public string ExchangeSymbol { get; set; }

        public string CompanySymbol { get; set; }

        public float Close { get; set; }

        public string Currency { get; set; }

        public float Change { get; set; }

        public float ChangePercentage { get; set; }

        public bool Gain { get; set; }

        public DisplayState State { get; set; }

        public static Stock GetSampleData()
        {
            return _sampleStock;
        }
    }
}
