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
            var weather = EndpointManager.GetWeather();
            bool useMetric = App.UseMetric.Equals("true");

            switch (weather.State)
            {
                case Display.DisplayState.Offline: weather = SampleDataRepository.GetSampleWeatherData(); break;
                case Display.DisplayState.Empty: MainWeatherConditions.Text = Properties.Resources.EndpointResultEmpty; return;
                default: break;
            }

            int tempNumericValueToDisplay = useMetric ? weather.TempCelsius : weather.TempFahrenheit;
            MainWeatherTemp.Text = string.Format(Properties.Resources.DisplayFormatTemp, tempNumericValueToDisplay);
            MainWeatherConditions.Text = weather.Conditions;

            if (weather.HasCompleteWindData)
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

                string windSpeedMeasurementToDisplay =
                    useMetric ? Properties.Resources.DisplayWeatherWindMeasurementKPH : Properties.Resources.DisplayWeatherWindMeasurementMPH;
                int windSpeedNumericValueToDisplay =
                    useMetric ? weather.WindSpeedKPH : weather.WindSpeedMPH;

                MainWeatherConditions.Text += 
                    string.Format(Properties.Resources.DisplayFormatWeatherWind,
                                  direction,
                                  windSpeedNumericValueToDisplay,
                                  windSpeedMeasurementToDisplay);
            }

            MainWeatherTime.Text = weather.TimeOfReading.ToString(Properties.Resources.DisplayFormatWeatherDateAndTime);
            MainWeatherCity.Text = weather.City;
        }

        private void SetSportsScores()
        {
            var scores = EndpointManager.GetSportsScores();

            switch (scores.State)
            {
                case Display.DisplayState.Offline: scores = SampleDataRepository.GetSampleSportsScoreData(); break;
                case Display.DisplayState.Empty: MainSportsScoresTeams.Text = Properties.Resources.EndpointResultEmpty; return;
                case Display.DisplayState.Error: MainSportsScoresTeams.Text = Properties.Resources.EndpointResultError; return;
                default: break;
            }

            DateTime date = scores.DateOfEvent;
            MainSportsScoresTeams.Text = string.Format(Properties.Resources.DisplayFormatSportsTeams.Replace("\\n", "\n"), scores.AwayTeam, scores.HomeTeam);
            MainSportsScoresValues.Text = string.Format(Properties.Resources.DisplayFormatSportsScoreValues.Replace("\\n", "\n"), scores.AwayTeamScore, scores.HomeTeamScore);
            MainSportsScoresDateAndStatus.Text = string.Format(Properties.Resources.DisplayFormatSportsStatusAndDate.Replace("\\n", "\n"), scores.Status, date, ToOrdinal(date.Day));
        }

        private void SetSportsNews()
        {
            var sportsNews = EndpointManager.GetSportsNews();

            switch (sportsNews.State)
            {
                case Display.DisplayState.Offline: sportsNews = SampleDataRepository.GetSampleSportsNewsData(); break;
                case Display.DisplayState.Empty: MainSportsNews.Text = Properties.Resources.EndpointResultEmpty; return;
                case Display.DisplayState.Error: MainSportsNews.Text = Properties.Resources.EndpointResultError; return;
                default: break;
            }

            MainSportsNews.Text = sportsNews.SportsNewsText;
        }

        private void SetLocalNews()
        {
            var news = EndpointManager.GetNews();

            switch (news.State)
            {
                case Display.DisplayState.Offline: news = SampleDataRepository.GetSampleNewsData(); break;
                case Display.DisplayState.Empty: MainNewsHeadline.Text = Properties.Resources.EndpointResultEmpty; return;
                case Display.DisplayState.Error: MainNewsHeadline.Text = Properties.Resources.EndpointResultError; return;
                default: break;
            }

            MainNewsHeadline.Text = news.NewsText;
        }

        private void SetStocks()
        {
            var stock = EndpointManager.GetStocks();

            switch (stock.State)
            {
                case Display.DisplayState.Offline: stock = SampleDataRepository.GetSampleStockData(); break;
                case Display.DisplayState.Empty: MainStocks.Text = Properties.Resources.EndpointResultEmpty; return;
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
