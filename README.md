# LocalInfoApp
Displays weather, news , stocks and sports information.

THIS SOFTWARE IS PROVIDED AS IS WITH NO WARRANTY OF ANY KIND. USE AT OWN RISK.

Coded using VS 2019 with Xamarin.Forms, RestSharp and Newtownsoft Json. Can be deployed to Android and iOS devices. Ran and tested using Android 8.1, API 27 emulator.

Out of the box, the app will run with sample data. A configuration file exists that, upon editing, allows easy access to live data.

In the following file, read the keys below and update their values:

LocalInfoApp/Properties/Resources.resx

RapidApiKey - a private key must be obtained by registering at RapidApi.com and then subscribing to The Rundown API. At last check, there was a free and limited option but a credit card must be held on file.

OpenWeatherMapKey -  a private key can be obtained for free from openweathermap.org

EndpointNewsFeedURL - the URL of an RSS feed

EndpointSportsNewsURL - the URL of an RSS feed with sports news, specifically with this tree structure: channel>item>category=Sports
