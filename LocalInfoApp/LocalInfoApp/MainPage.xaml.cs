using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace LocalInfoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            SetWeather();
            SetSportsScores();
            SetSportsNews();
            SetLocalNews();
            SetStocks();
        }

        private void SetWeather()
        {
            var kvp = EndpointManager.GetWeather();
            var weather = kvp.Key;
            var result = kvp.Value;

            switch (result)
            {
                case EndpointManager.Result.NoKey: weather = Display.Weather.GetSampleData(); break;
                case EndpointManager.Result.Empty: MainWeatherConditions.Text = Properties.Resources.EndpointResultEmpty; return;
                default: break;
            }

            MainWeatherTemp.Text = string.Format(Properties.Resources.DisplayFormatTemp, weather.TempCelsius);
            MainWeatherConditions.Text = weather.Conditions;

            if (weather.HasWindData)
            {
                string direction;
                switch (weather.WindDirection1)
                {
                    case Display.Weather.WindDirection.NorthEast: direction = Properties.Resources.DisplayWeatherWindDirectionNorthEast; break;
                    case Display.Weather.WindDirection.East:      direction = Properties.Resources.DisplayWeatherWindDirectionEast;      break;
                    case Display.Weather.WindDirection.SouthEast: direction = Properties.Resources.DisplayWeatherWindDirectionSouthEast; break;
                    case Display.Weather.WindDirection.South:     direction = Properties.Resources.DisplayWeatherWindDirectionSouth;     break;
                    case Display.Weather.WindDirection.SouthWest: direction = Properties.Resources.DisplayWeatherWindDirectionSouthWest; break;
                    case Display.Weather.WindDirection.West:      direction = Properties.Resources.DisplayWeatherWindDirectionWest;      break;
                    case Display.Weather.WindDirection.NorthWest: direction = Properties.Resources.DisplayWeatherWindDirectionNorthWest; break;
                    default: direction = Properties.Resources.DisplayWeatherWindDirectionNorth; break;
                }

                MainWeatherConditions.Text += 
                    string.Format(Properties.Resources.DisplayFormatWeatherWind,
                                  direction,
                                  weather.WindSpeedKPH,
                                  Properties.Resources.DisplayWeatherWindMeasurement);
            }

            MainWeatherTime.Text = weather.TimeOfReading.ToString(Properties.Resources.DisplayFormatWeatherDateAndTime);
            MainWeatherCity.Text = weather.City;
        }

        private void SetSportsScores()
        {
            var kvp = EndpointManager.GetSportsScores();
            var scores = kvp.Key;
            var result = kvp.Value;

            switch (result)
            {
                case EndpointManager.Result.NoKey: scores = Display.SportsScores.GetSampleData(); break;
                case EndpointManager.Result.Empty: MainSportsScoresTeams.Text = Properties.Resources.EndpointResultEmpty; return;
                case EndpointManager.Result.Error: MainSportsScoresTeams.Text = Properties.Resources.EndpointResultError; return;
                default: break;
            }

            DateTime date = scores.DateOfEvent;
            MainSportsScoresTeams.Text = string.Format(Properties.Resources.DisplayFormatSportsTeams.Replace("\\n", "\n"), scores.AwayTeam, scores.HomeTeam);
            MainSportsScoresValues.Text = string.Format(Properties.Resources.DisplayFormatSportsScoreValues.Replace("\\n", "\n"), scores.AwayTeamScore, scores.HomeTeamScore);
            MainSportsScoresDateAndStatus.Text = string.Format(Properties.Resources.DisplayFormatSportsStatusAndDate.Replace("\\n", "\n"), scores.Status, date, ToOrdinal(date.Day));
        }

        private void SetSportsNews()
        {
            var kvp = EndpointManager.GetSportsNews();
            var sportsNews = kvp.Key;
            var result = kvp.Value;

            switch (result)
            {
                case EndpointManager.Result.NoKey: sportsNews = Properties.Resources.DisplaySampleSportsNews; break;
                case EndpointManager.Result.Empty: sportsNews = Properties.Resources.EndpointResultEmpty; break;
                case EndpointManager.Result.Error: sportsNews = Properties.Resources.EndpointResultError; break;
                default: break;
            }

            MainSportsNews.Text = sportsNews;
        }

        private void SetLocalNews()
        {
            var kvp = EndpointManager.GetNews();
            var news = kvp.Key;
            var result = kvp.Value;

            switch (result)
            {
                case EndpointManager.Result.NoKey: news = Properties.Resources.DisplaySampleLocalNews; break;
                case EndpointManager.Result.Empty: news = Properties.Resources.EndpointResultEmpty; break;
                case EndpointManager.Result.Error: news = Properties.Resources.EndpointResultError; break;
                default: break;
            }

            MainNewsHeadline.Text = news;
        }

        private void SetStocks()
        {
            var kvp = EndpointManager.GetStocks();
            var stock = kvp.Key;
            var result = kvp.Value;

            switch (result)
            {
                case EndpointManager.Result.NoKey: stock = Display.Stock.GetSampleData(); break;
                case EndpointManager.Result.Empty: MainStocks.Text = Properties.Resources.EndpointResultEmpty; return;
                default: break;
            }

            MainStocks.Text =
                string.Format(Properties.Resources.DisplayFormatStocks.Replace("\\n", "\n"),
                              stock.CompanyName,
                              stock.ExchangeSymbol,
                              stock.CompanySymbol,
                              stock.Close,
                              stock.Currency,
                              stock.Gain ? '+' : '-',
                              stock.Change,
                              stock.ChangePercentage,
                              stock.Gain ? '▲' : '▼');
        }

        // helper method by Rod Stephens
        // http://csharphelper.com/blog/2014/11/convert-an-integer-into-an-ordinal-in-c/
        // mod by Joshua Dove
        private static string ToOrdinal(int value)
        {
            // Start with the most common extension.
            string extension = "th";

            // Examine the last 2 digits.
            int last_digits = value % 100;

            // If the last digits are 11, 12, or 13, use th. Otherwise:
            if (last_digits < 11 || last_digits > 13)
                switch (last_digits % 10)
                {
                    case 1: extension = "st"; break;
                    case 2: extension = "nd"; break;
                    case 3: extension = "rd"; break;
                }

            return extension;
        }
    } 
}
