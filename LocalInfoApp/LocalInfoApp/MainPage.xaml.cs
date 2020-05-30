using System;
using System.ComponentModel;
using System.Linq;
using System.Globalization;
using Xamarin.Forms;

using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;
using LocalInfoApp.Properties;

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

            DisplayWeather weather = EndpointManager.GetWeather() ?? DisplayWeather.CreateSampleData();
            MainWeatherTemp.Text = string.Format(Properties.Resources.DisplayFormatTemp, weather.TempCelsius);
            MainWeatherConditions.Text = weather.Conditions;
            MainWeatherTime.Text = weather.TimeOfReading.ToString(Properties.Resources.DisplayFormatWeatherDateAndTime);
            MainWeatherCity.Text = weather.City;

            DisplaySportsScores scores = EndpointManager.GetSportsScores() ?? DisplaySportsScores.CreateSampleData();
            DateTime date = scores.DateOfEvent;
            MainSportsScoresTeams.Text = string.Format(Properties.Resources.DisplayFormatSportsTeams.Replace("\\n", "\n"), scores.AwayTeam, scores.HomeTeam);
            MainSportsScoresValues.Text = string.Format(Properties.Resources.DisplayFormatSportsScoreValues.Replace("\\n", "\n"), scores.AwayTeamScore, scores.HomeTeamScore);
            MainSportsScoresDateAndStatus.Text = string.Format(Properties.Resources.DisplayFormatSportsStatusAndDate.Replace("\\n", "\n"), scores.Status, date, ToOrdinal(date.Day));

            string sportsNews = EndpointManager.GetSportsNews() ?? Properties.Resources.DisplaySampleSportsNews;
            MainSportsNews.Text = sportsNews;

            string news = EndpointManager.GetNews() ?? Properties.Resources.DisplaySampleLocalNews;
            MainNewsHeadline.Text = news;

            DisplayStock stock = EndpointManager.GetStocks() ?? DisplayStock.CreateSampleData();
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
