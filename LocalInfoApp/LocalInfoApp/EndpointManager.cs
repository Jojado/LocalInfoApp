using System;
using System.Linq;
using System.Globalization;

using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;
using System.Collections.Generic;
using LocalInfoApp.Display;

namespace LocalInfoApp
{
    public class EndpointManager
    {
        public static SportsScores GetSportsScores()
        {
            if (Properties.Resources.RapidApiKey is "")
                return new SportsScores { State = DisplayState.Offline };

            const string API_DATE_FORMAT = "yyyy-MM-dd"; // Expected format for web service
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
                return new SportsScores { State = DisplayState.Error };
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
            var sportsEvents = JsonConvert.DeserializeObject<Json.SportsEvents>(response.Content);
            if (sportsEvents is null || sportsEvents.events is null)
                return new SportsScores { State = DisplayState.Empty };

            Json.Event event1 = (
                from evnt in sportsEvents.events
                from tm in evnt.teams
                where tm.team_id == parsed_team_id
                select evnt).FirstOrDefault();

            if (event1 is null)
                return new SportsScores { State = DisplayState.Empty };

            int homeIndex = event1.teams_normalized[0].is_home ? 0 : 1;
            int awayIndex = homeIndex is 0 ? 1 : 0;

            string awayTeamName = event1.teams_normalized[awayIndex].mascot;
            string homeTeamName = event1.teams_normalized[homeIndex].mascot;
            int awayTeamScore = event1.score.score_away;
            int homeTeamScore = event1.score.score_home;

            string status = event1.score.event_status_detail.ToUpper();
            DateTime date = event1.event_date;

            return new SportsScores  {
                AwayTeam = awayTeamName,
                AwayTeamScore = awayTeamScore,
                HomeTeam = homeTeamName,
                HomeTeamScore = homeTeamScore,
                Status = status,
                DateOfEvent = date,
                State = DisplayState.OK
            };
        }

        public static SportsNews GetSportsNews()
        {
            if (Properties.Resources.EndpointSportsNewsURL is "")
                return new SportsNews { State = DisplayState.Offline };

            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(Properties.Resources.EndpointSportsNewsURL);
            }
            catch (Exception)
            {
                return new SportsNews { State = DisplayState.Error };
            }

            string sportsStory = (
                from chn in xdoc.Descendants("channel")
                from itm in chn.Descendants("item")
                from ct in itm.Descendants("category")
                where ct.Value is "Sports"
                select itm.Element("title").Value).FirstOrDefault();

            if (sportsStory is null)
                return new SportsNews { State = DisplayState.Empty };
            else
                return new SportsNews { SportsNewsText = sportsStory, State = DisplayState.OK };

        }

        public static Weather GetWeather()
        {
            if (Properties.Resources.OpenWeatherMapKey is "")
                return new Weather { State = DisplayState.Offline };

            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", Properties.Resources.OpenWeatherMapQueryParam); // city or town
            request.AddParameter("appid", Properties.Resources.OpenWeatherMapKey);

            var response = client.Execute(request);
            var weather = JsonConvert.DeserializeObject<Json.Weather1>(response.Content);
            if (weather is null || weather.name is null || weather.weather is null || weather.weather.Length is 0)
                return new Weather { State = DisplayState.Empty };

            string city = weather.name;
            string conditions = weather.weather[0].main;

            var weatherDisplay = new Weather()
            {
                City = city,
                TimeOfReading = DateTime.Now,
                TempKelvin = weather.main.temp,
                State = DisplayState.OK
            };

            // Hack for cold-weather conditions
            if (weatherDisplay.TempCelsius <= 0)
            {
                switch (conditions)
                {
                    case "Rain": conditions = "Flurries"; break;
                    case "Mist": conditions = "Snow Grains"; break;
                    case "Fog":  conditions = "Light Freezing Drizzle"; break;
                    default: break;
                }
            }
            weatherDisplay.Conditions = conditions;

            if (weather.wind != null)
            {
                weatherDisplay.WindSpeedMps = weather.wind.speed;
                weatherDisplay.WindDirection1 = GetWindDirection(weather.wind.deg);
            }

            return weatherDisplay;
        }

        // helper method to determine wind direction
        private static Display.Weather.WindDirection GetWindDirection(int directionDegrees)
        {
            // From the weather API: zero degrees is north, 180 degrees is south.
            // With eight desired directions, 360 / 8 = 45 degree range per direction.
            // Between 337.5 and 359 is north.
            // Between zero and 22.5 is also north.
            // Between 158.5 and 203.5 is south.
            // Since degrees are supplied as integers, round up.

            if (directionDegrees >= 23 && directionDegrees < 68)
                return Display.Weather.WindDirection.NorthEast;

            else if (directionDegrees >= 68 && directionDegrees < 113)
                return Display.Weather.WindDirection.East;

            else if (directionDegrees >= 113 && directionDegrees < 158)
                return Display.Weather.WindDirection.SouthEast;

            else if (directionDegrees >= 158 && directionDegrees < 203)
                return Display.Weather.WindDirection.South;

            else if (directionDegrees >= 203 && directionDegrees < 248)
                return Display.Weather.WindDirection.SouthWest;

            else if (directionDegrees >= 248 && directionDegrees < 293)
                return Display.Weather.WindDirection.West;

            else if (directionDegrees >= 293 && directionDegrees < 338)
                return Display.Weather.WindDirection.NorthWest;

            else
                return Display.Weather.WindDirection.North;
        }

        public static Stock GetStocks()
        {
            if (Properties.Resources.RapidApiKey is "")
                return new Stock { State = DisplayState.Offline };

            /*
             * Get all exchanges
             * https://finnhub.io/api/v1/stock/exchange?token=
             * Get all symbols for Canada (TO) stocks
             * https://finnhub.io/api/v1/stock/symbol?exchange=TO&token=
             */
            var client = new RestClient("https://finnhub-realtime-stock-price.p.rapidapi.com/quote");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", Properties.Resources.RapidApiStockQueryParam);
            request.AddHeader("x-rapidapi-host", "finnhub-realtime-stock-price.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", Properties.Resources.RapidApiKey);

            var response = client.Execute(request);
            var stockQuote = JsonConvert.DeserializeObject<Json.StockQuote>(response.Content);
            if (stockQuote is null || stockQuote.c is 0)
                return new Stock { State = DisplayState.Empty };

            float close = stockQuote.c;
            float change = close - stockQuote.pc;

            bool gain = change >= 0.000f;
            float changeAbsValue = Math.Abs(change);
            float changePercentage = changeAbsValue / close;

            // Any change in the closing price must be reflected as something
            // other than zero.
            if (changePercentage > 0.000 && changePercentage < 0.1000)
                changePercentage += 0.01f;

            return new Stock
            {
                Change = change,
                ChangePercentage = changePercentage,
                Close = close,
                CompanyName = Properties.Resources.DisplayStockCompanyName,
                CompanySymbol = Properties.Resources.DisplayStockCompanySymbol,
                Currency = Properties.Resources.DisplayStockCurrency,
                ExchangeSymbol = Properties.Resources.DisplayStockExchangeSymbol,
                Gain = gain,
                State = DisplayState.OK
            };
        }

        public static News GetNews()
        {
            if (Properties.Resources.EndpointNewsFeedURL is "")
                return new News { State = DisplayState.Offline };

            XDocument xdoc;
            try
            {
                xdoc = XDocument.Load(Properties.Resources.EndpointNewsFeedURL);
            }
            catch (Exception)
            {
                return new News { State = DisplayState.Error };
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
                return new News { State = DisplayState.Empty };
            else
                return new News { NewsText = newsStory.Title, State = DisplayState.OK };
        }
    }
}
