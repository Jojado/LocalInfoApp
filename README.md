# LocalInfoApp
Displays weather, news, stocks and sports information.

THIS SOFTWARE IS PROVIDED AS IS WITH NO WARRANTY OF ANY KIND. USE AT YOUR OWN RISK.

Coded using VS 2019 with Xamarin.Forms, RestSharp and Newtownsoft Json. Can be deployed to Android and iOS devices. Ran and tested using Android 8.1, API 27 emulator.

Out of the box, the app will run with sample data. A configuration file exists that - upon updating - would enable access to live data.

(a future update will include more robust support for Dev/QA/Prod environments and may include a cleaner app configuration with user-based preferences)

In the following file, read the entitiy names below and update their inner values:

LocalInfoApp/App.xml

SportsScoresKey - a private key must be obtained by registering at https://RapidApi.com and then subscribing to The Rundown API. Last I checked, there was a free and limited option but a credit card number must be provided and held on file.

StocksKey - for the current implementation based on RapidApi, it's the same key as above (SportsScoresKey)

WeatherKey -  a private key can be obtained for free from https://OpenWeatherMap.org

NewsFeedBaseEndpoint - the base endpoint of an RSS feed, e.g. https://calgary.ctvnews.ca

NewsFeedPath - the path which completes the whole news feed URL, e.g. /rss/ctv-news-calgary-1.822341

SportsNewsBaseEndpoint - the base endpoint of an RSS feed, e.g. https://calgarysun.com

SportsNewsPath - the path which completes the whole sports news feed URL, e.g. /feed/
