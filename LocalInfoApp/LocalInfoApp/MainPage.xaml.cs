using System;
using System.ComponentModel;
using System.Linq;
using System.Globalization;
using Xamarin.Forms;

using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;

namespace LocalInfoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string KEY_RAPID_API = "";
        private const string KEY_OPEN_WEATHER_MAP = "";

        private const int SPORTS_TARGET_TEAM_ID = 39727;         // 39727 is the Calgary Flames
        private const string SPORTS_TARGET_DATE = "2020-03-08";  // YYYY-MM-DD
        private const int SPORTS_TARGET_LEAGUE = 6;              // 6 is the National Hockey League
        private const string STOCK_QUERY_PARAM_SYMBOL = "SU.TO"; // Suncor Energy Inc. symbol
        private const string WEATHER_QUERY_PARAM_CITY = "calgary,ab,ca";

        private const string STOCK_DISPLAY_DESCRIPTION = "Suncor Energy Inc.";
        private const string STOCK_DISPLAY_EXCHANGE_SYMBOL = "TSE";
        private const string STOCK_DISPLAY_SYMBOL = "SU";
        private const string STOCK_DISPLAY_CURRENCY_CODE = "CAD";

        public MainPage()
        {
            InitializeComponent();

            DisplayWeather weather = GetWeather() ?? DisplayWeather.CreateTestData();
            MainWeatherTemp.Text = weather.TempCelsius + "°";
            MainWeatherConditions.Text = weather.Conditions;
            MainWeatherTime.Text = weather.TimeOfReading.ToString("MM-dd h:mm tt");
            MainWeatherCity.Text = weather.City;

            DisplaySportsScores scores = GetSportsScores() ?? DisplaySportsScores.CreateTestData();
            DateTime date = scores.DateOfEvent;
            MainSportsScoresTeams.Text = string.Format("{0}\n{1}", scores.AwayTeam, scores.HomeTeam);
            MainSportsScoresValues.Text = string.Format("{0}\n{1}", scores.AwayTeamScore, scores.HomeTeamScore);
            MainSportsScoresDateAndStatus.Text = string.Format("{0}\n{1:ddd MMM d}{2}", scores.Status, date, ToOrdinal(date.Day));

            string sportsNews = GetSportsNews() ?? "This is sports news";
            MainSportsNews.Text = sportsNews;

            string news = GetNews() ?? "This is the news";
            MainNewsHeadline.Text = news;

            DisplayStock stock = GetStocks() ?? DisplayStock.CreateTestData();
            MainStocks.Text =
                string.Format("{0}\n{1}: {2}\n{3:0.00} {4}\n{5}{6:0.00} ({7:0.00}%) {8}",
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

        private DisplaySportsScores GetSportsScores()
        {
            try
            {
                DateTime.ParseExact(SPORTS_TARGET_DATE, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return null;
            }

            string clientURL =
                string.Format("https://therundown-therundown-v1.p.rapidapi.com/sports/{0}/events/{1}",
                              SPORTS_TARGET_LEAGUE,
                              SPORTS_TARGET_DATE);
            var client = new RestClient(clientURL);
            var request = new RestRequest(Method.GET);
            request.AddParameter("include", "scores");
            request.AddHeader("x-rapidapi-host", "therundown-therundown-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", KEY_RAPID_API);

            var response = client.Execute(request);
            var sportsEvents = JsonConvert.DeserializeObject<JsonSportsEvents>(response.Content);
            if (sportsEvents is null || sportsEvents.events is null)
                return null;

            Event event1 = (
                from evnt in sportsEvents.events
                from tm in evnt.teams
                where tm.team_id == SPORTS_TARGET_TEAM_ID
                select evnt).FirstOrDefault();

            if (event1 is null)
                return null;

            int homeIndex = event1.teams_normalized[0].is_home ? 0 : 1;
            int awayIndex = homeIndex is 0 ? 1 : 0;

            string awayTeamName = event1.teams_normalized[awayIndex].mascot;
            string homeTeamName = event1.teams_normalized[homeIndex].mascot;
            int awayTeamScore = event1.score.score_away;
            int homeTeamScore = event1.score.score_home;

            string status = event1.score.event_status_detail.ToUpper();
            DateTime date = event1.event_date;

            return new DisplaySportsScores()
            {
                AwayTeam = awayTeamName,
                AwayTeamScore = awayTeamScore,
                HomeTeam = homeTeamName,
                HomeTeamScore = homeTeamScore,
                Status = status,
                DateOfEvent = date
            };
        }

        private string GetSportsNews()
        {
            XDocument xdoc = XDocument.Load("https://calgarysun.com/feed/");

            string sportsStory = (
                from chn in xdoc.Descendants("channel")
                from itm in chn.Descendants("item")
                from ct in itm.Descendants("category")
                where ct.Value is "Sports"
                select itm.Element("title").Value).FirstOrDefault();

            return sportsStory;
        }

        private DisplayWeather GetWeather()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", WEATHER_QUERY_PARAM_CITY); // city or town
            request.AddParameter("appid", KEY_OPEN_WEATHER_MAP);

            var response = client.Execute(request);
            var weather = JsonConvert.DeserializeObject<JsonWeather>(response.Content);
            if (weather is null)
                return null;

            string city = weather.name;
            string conditions = weather.weather[0].main;
            int tempCelsius =
                (int) Math.Round(weather.main.temp - 273.15f, MidpointRounding.AwayFromZero);

            // hack for cold-weather conditions
            if (tempCelsius <= 0)
                switch (conditions)
                {
                    case "Rain": conditions = "Flurries"; break;
                    case "Mist": conditions = "Snow Grains"; break;
                    case "Fog":  conditions = "Light Freezing Drizzle"; break;
                    default: break;
                }

            return new DisplayWeather()
            {
                City = city,
                Conditions = conditions,
                TempCelsius = tempCelsius,
                TimeOfReading = DateTime.Now
            };
        }

        private DisplayStock GetStocks()
        {
            /*
             * get all exchanges
             * https://finnhub.io/api/v1/stock/exchange?token=
             * get all symbols for Canada (TO) stocks
             * https://finnhub.io/api/v1/stock/symbol?exchange=TO&token=
             */
            var client = new RestClient("https://finnhub-realtime-stock-price.p.rapidapi.com/quote");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", STOCK_QUERY_PARAM_SYMBOL);
            request.AddHeader("x-rapidapi-host", "finnhub-realtime-stock-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", KEY_RAPID_API);

            var response = client.Execute(request);
            var stockQuote = JsonConvert.DeserializeObject<JsonStockQuote>(response.Content);
            if (stockQuote is null)
                return null;

            float close = stockQuote.c;
            float change = close - stockQuote.pc;

            bool gain = change >= 0.000f;
            float changeAbsValue = Math.Abs(change);
            float changePercentage = changeAbsValue / close;

            // any change in the closing price must be reflected as something
            // other than zero
            if (changePercentage > 0.000 && changePercentage < 0.1000)
                changePercentage += 0.01f;

            return new DisplayStock()
            {
                Change = change,
                ChangePercentage = changePercentage,
                Close = close,
                CompanyName = STOCK_DISPLAY_DESCRIPTION,
                CompanySymbol = STOCK_DISPLAY_SYMBOL,
                Currency = STOCK_DISPLAY_CURRENCY_CODE,
                ExchangeSymbol = STOCK_DISPLAY_EXCHANGE_SYMBOL,
                Gain = gain
            };
        }

        private string GetNews()
        {
            XDocument xdoc = XDocument.Load("https://calgary.ctvnews.ca/rss/ctv-news-calgary-1.822341");

            var newsStory = (
                from chn in xdoc.Descendants("channel")
                from itm in chn.Descendants("item")
                select new {
                    Title = itm.Element("title").Value //,
                    //Description = itm.Element("description").Value
                }).FirstOrDefault();

            return newsStory is null ? null : newsStory.Title;
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
