# LocalInfoApp
Displays weather, news, stocks and sports information.

THIS SOFTWARE IS PROVIDED AS IS WITH NO WARRANTY OF ANY KIND. USE AT YOUR OWN RISK.

Coded using VS 2019 with Xamarin.Forms, RestSharp and Newtownsoft Json. Can be deployed to Android and iOS devices. Ran and tested using Android 8.1, API 27 emulator.

Out of the box, the app will run with sample data. A configuration file exists that - upon updating - would enable access to live data.

In the following file, read the keys below and update their values:

LocalInfoApp/Properties/Resources.resx

(NOTE: a future update will move these specific properties to an application configuration XML file)

RapidApiKey - a private key must be obtained by registering at https://RapidApi.com and then subscribing to The Rundown API. Last I checked, there was a free and limited option but a credit card number must be provided and held on file.

OpenWeatherMapKey -  a private key can be obtained for free from https://OpenWeatherMap.org

EndpointNewsFeedURL - the URL of an RSS feed, e.g. https://calgary.ctvnews.ca/rss/ctv-news-calgary-1.822341

EndpointSportsNewsURL - the URL of an RSS feed with sports news, specifically with this tree structure: channel>item>category=Sports , e.g. https://calgarysun.com/feed/
