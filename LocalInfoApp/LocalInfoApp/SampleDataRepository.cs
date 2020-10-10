using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp
{
    public static class SampleDataRepository
    {
        public static Display.Weather WeatherData { get; }  = new Display.Weather()
        {
            City = "City Name",
            Conditions = "Conditions",
            TimeOfReading = new DateTime(2001, 1, 1),
            WindDirection1 = Display.Weather.WindDirection.North,
            TempKelvin = 273.15f,
            WindSpeedMps = 0,
            State = Display.DisplayState.Offline,

        };

        public static Display.Stock StockData { get; } = new Display.Stock
        {
            Change = 0.45f,
            ChangePercentage = 2.21f,
            Close = 20.35f,
            CompanyName = "Company Inc.",
            CompanySymbol = "CMP",
            Currency = "USD",
            ExchangeSymbol = "ABC",
            Gain = true,
            State = Display.DisplayState.Offline
        };

        public static Display.SportsScores SportsScoreData { get; } = new Display.SportsScores
        {
            AwayTeam = "Away Team",
            AwayTeamScore = 0,
            DateOfEvent = new DateTime(2001, 1, 1),
            HomeTeam = "Home Team",
            HomeTeamScore = 0,
            Status = "FINAL",
            State = Display.DisplayState.Offline
        };

        public static Display.News NewsData { get; } = new Display.News
        {
            NewsText = "Here is the local news",
            State = Display.DisplayState.Offline
        };

        public static Display.SportsNews SportsNewsData { get; } = new Display.SportsNews
        {
            SportsNewsText = "Here is the sports news",
            State = Display.DisplayState.Offline
        };
    }
}
