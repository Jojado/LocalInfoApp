

namespace LocalInfoApp
{
    public class DisplayStock
    {
        public string CompanyName { get; set; }

        public string ExchangeSymbol { get; set; }

        public string CompanySymbol { get; set; }

        public float Close { get; set; }

        public string Currency { get; set; }

        public float Change { get; set; }

        public float ChangePercentage { get; set; }

        public bool Gain { get; set; }

        public static DisplayStock CreateSampleData()
        {
            return new DisplayStock
            {
                Change = 0.45f,
                ChangePercentage = 2.21f,
                Close = 20.35f,
                CompanyName = "Company Inc.",
                CompanySymbol = "CMP",
                Currency = "USD",
                ExchangeSymbol = "ABC",
                Gain = true
            };
        }
    }
}
