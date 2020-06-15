using System;
using System.Linq;
using System.Globalization;

using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LocalInfoApp
{
    public class EndpointManager
    {
        public enum Result
        {
            OK,
            Empty,
            Error,
            NoKey
        }

        public static KeyValuePair<DisplaySportsScores, Result> GetSportsScores()
        {
            if (Properties.Resources.RapidApiKey is "")
                return new KeyValuePair<DisplaySportsScores, Result>(null, Result.NoKey);

            const string API_DATE_FORMAT = "yyyy-MM-dd";
            int parsed_team_id;
            DateTime api_date;

            try
            {
                if (Properties.Resources.RapidApiSportsDate is "")
                    api_date = DateTime.Now;
                else
                    api_date = DateTime.ParseExact(Properties.Resources.RapidApiSportsDate, API_DATE_FORMAT, CultureInfo.InvariantCulture);

                parsed_team_id = int.Parse(Properties.Resources.RapidApiSportsTeamId);
            }
            catch (Exception)
            {
                return new KeyValuePair<DisplaySportsScores, Result>(null, Result.Error);
            }

            string clientURL =
                string.Format("https://therundown-therundown-v1.p.rapidapi.com/sports/{0}/events/{1}",
                              Properties.Resources.RapidApiSportsLeagueId,
                              api_date.ToString(API_DATE_FORMAT));
            var client = new RestClient(clientURL);
            var request = new RestRequest(Method.GET);
            request.AddParameter("include", "scores");
            request.AddHeader("x-rapidapi-host", "therundown-therundown-v1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", Properties.Resources.RapidApiKey);

            var response = client.Execute(request);
            var sportsEvents = JsonConvert.DeserializeObject<JsonSportsEvents>(response.Content);
            if (sportsEvents is null || sportsEvents.events is null)
                return new KeyValuePair<DisplaySportsScores, Result>(null, Result.Empty);

            Event event1 = (
                from evnt in sportsEvents.events
                from tm in evnt.teams
                where tm.team_id == parsed_team_id
                select evnt).FirstOrDefault();

            if (event1 is null)
                return new KeyValuePair<DisplaySportsScores, Result>(null, Result.Empty);

            int homeIndex = event1.teams_normalized[0].is_home ? 0 : 1;
            int awayIndex = homeIndex is 0 ? 1 : 0;

            string awayTeamName = event1.teams_normalized[awayIndex].mascot;
            string homeTeamName = event1.teams_normalized[homeIndex].mascot;
            int awayTeamScore = event1.score.score_away;
            int homeTeamScore = event1.score.score_home;

            string status = event1.score.event_status_detail.ToUpper();
            DateTime date = event1.event_date;

            return new KeyValuePair<DisplaySportsScores, Result>(
                new DisplaySportsScores()
                {
                    AwayTeam = awayTeamName,
                    AwayTeamScore = awayTeamScore,
                    HomeTeam = homeTeamName,
                    HomeTeamScore = homeTeamScore,
                    Status = status,
                    DateOfEvent = date
                }, 
                Result.OK);
        }

        public static KeyValuePair<string, Result> GetSportsNews()
        {
            if (Properties.Resources.EndpointSportsNewsURL is "")
                return new KeyValuePair<string, Result>(null, Result.NoKey);

            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(Properties.Resources.EndpointSportsNewsURL);
            }
            catch (Exception)
            {
                return new KeyValuePair<string, Result>(null, Result.Error);
            }

            string sportsStory = (
                from chn in xdoc.Descendants("channel")
                from itm in chn.Descendants("item")
                from ct in itm.Descendants("category")
                where ct.Value is "Sports"
                select itm.Element("title").Value).FirstOrDefault();

            if (sportsStory is null)
                return new KeyValuePair<string, Result>(null, Result.Empty);
            else
                return new KeyValuePair<string, Result>(sportsStory, Result.OK);

        }

        public static KeyValuePair<DisplayWeather, Result> GetWeather()
        {
            if (Properties.Resources.OpenWeatherMapKey is "")
                return new KeyValuePair<DisplayWeather, Result>(null, Result.NoKey);

            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", Properties.Resources.OpenWeatherMapQueryParam); // city or town
            request.AddParameter("appid", Properties.Resources.OpenWeatherMapKey);

            var response = client.Execute(request);
            var weather = JsonConvert.DeserializeObject<JsonWeather>(response.Content);
            if (weather is null || weather.name is null || weather.weather is null || weather.weather.Length is 0)
                return new KeyValuePair<DisplayWeather, Result>(null, Result.Empty);

            string city = weather.name;
            string conditions = weather.weather[0].main;
            int tempCelsius =
                (int)Math.Round(weather.main.temp - 273.15f, MidpointRounding.AwayFromZero);

            // hack for cold-weather conditions
            if (tempCelsius <= 0)
                switch (conditions)
                {
                    case "Rain": conditions = "Flurries"; break;
                    case "Mist": conditions = "Snow Grains"; break;
                    case "Fog": conditions = "Light Freezing Drizzle"; break;
                    default: break;
                }

            return new KeyValuePair<DisplayWeather, Result>(new DisplayWeather()
                {
                    City = city,
                    Conditions = conditions,
                    TempCelsius = tempCelsius,
                    TimeOfReading = DateTime.Now
                }, Result.OK);
        }

        public static KeyValuePair<DisplayStock, Result> GetStocks()
        {
            if (Properties.Resources.RapidApiKey is "")
                return new KeyValuePair<DisplayStock, Result>(null, Result.NoKey);

            /*
             * get all exchanges
             * https://finnhub.io/api/v1/stock/exchange?token=
             * get all symbols for Canada (TO) stocks
             * https://finnhub.io/api/v1/stock/symbol?exchange=TO&token=
             */
            var client = new RestClient("https://finnhub-realtime-stock-price.p.rapidapi.com/quote");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", Properties.Resources.RapidApiStockQueryParam);
            request.AddHeader("x-rapidapi-host", "finnhub-realtime-stock-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", Properties.Resources.RapidApiKey);

            var response = client.Execute(request);
            var stockQuote = JsonConvert.DeserializeObject<JsonStockQuote>(response.Content);
            if (stockQuote is null || stockQuote.c is 0)
                return new KeyValuePair<DisplayStock, Result>(null, Result.Empty);

            float close = stockQuote.c;
            float change = close - stockQuote.pc;

            bool gain = change >= 0.000f;
            float changeAbsValue = Math.Abs(change);
            float changePercentage = changeAbsValue / close;

            // any change in the closing price must be reflected as something
            // other than zero
            if (changePercentage > 0.000 && changePercentage < 0.1000)
                changePercentage += 0.01f;

            return new KeyValuePair<DisplayStock, Result> (new DisplayStock()
                {
                    Change = change,
                    ChangePercentage = changePercentage,
                    Close = close,
                    CompanyName = Properties.Resources.DisplayStockCompanyName,
                    CompanySymbol = Properties.Resources.DisplayStockCompanySymbol,
                    Currency = Properties.Resources.DisplayStockCurrency,
                    ExchangeSymbol = Properties.Resources.DisplayStockExchangeSymbol,
                    Gain = gain
                }, Result.OK);
        }

        public static KeyValuePair<string, Result> GetNews()
        {
            if (Properties.Resources.EndpointNewsFeedURL is "")
                return new KeyValuePair<string, Result>(null, Result.NoKey);

            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(Properties.Resources.EndpointNewsFeedURL);
            }
            catch (Exception)
            {
                return new KeyValuePair<string, Result>(null, Result.Error);
            }

            var newsStory = (
                from chn in xdoc.Descendants("channel")
                from itm in chn.Descendants("item")
                select new
                {
                    Title = itm.Element("title").Value //,
                    //Description = itm.Element("description").Value
                }).FirstOrDefault();

            if (newsStory is null)
                return new KeyValuePair<string, Result>(null, Result.Empty);
            else
                return new KeyValuePair<string, Result>(newsStory.Title, Result.OK);
        }
    }
}
