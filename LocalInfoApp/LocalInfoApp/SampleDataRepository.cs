using System;
using System.Collections.Generic;
using System.Text;

namespace LocalInfoApp
{
    public class SampleDataRepository
    {
        private static Display.Weather _sampleWeatherData = new Display.Weather()
        {
            City = "City Name",
            Conditions = "Conditions",
            TimeOfReading = new DateTime(2001, 1, 1),
            WindDirection1 = Display.Weather.WindDirection.North,
            TempKelvin = 273.15f,
            WindSpeedMps = 0,
            State = Display.DisplayState.Offline,
            
        };

        private static Display.Stock _sampleStockData = new Display.Stock
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

        private static Display.SportsScores _sampleSportsData = new Display.SportsScores
        {
            AwayTeam = "Away Team",
            AwayTeamScore = 0,
            DateOfEvent = new DateTime(2001, 1, 1),
            HomeTeam = "Home Team",
            HomeTeamScore = 0,
            Status = "FINAL",
            State = Display.DisplayState.Offline
        };

        private static Display.News _sampleNewsData = new Display.News
        {
            NewsText = "Here is the local news",
            State = Display.DisplayState.Offline
        };

        private static Display.SportsNews _sampleSportsNews = new Display.SportsNews
        {
            SportsNewsText = "Here is the sports news",
            State = Display.DisplayState.Offline
        };

        public static Display.Weather GetSampleWeatherData()
        {
            return _sampleWeatherData;
        }

        public static Display.Stock GetSampleStockData()
        {
            return _sampleStockData;
        }

        public static Display.SportsScores GetSampleSportsScoreData()
        {
            return _sampleSportsData;
        }

        public static Display.News GetSampleNewsData()
        {
            return _sampleNewsData;
        }

        public static Display.SportsNews GetSampleSportsNewsData()
        {
            return _sampleSportsNews;
        }
    }
}
