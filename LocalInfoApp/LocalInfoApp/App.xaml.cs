using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalInfoApp
{
    public partial class App : Application
    {
        private static bool _appStarted = false;

        public App()
        {
            LoadAppConfig();
            InitializeComponent();
            MainPage = new MainPage();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void LoadAppConfig()
        {
            if (_appStarted)
                return;
            else
                _appStarted = true;

            var doc = new XmlDocument();
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

            using (var stream = assembly.GetManifestResourceStream("LocalInfoApp.App.xml"))
            {
                var reader = new System.IO.StreamReader(stream);
                var text = reader.ReadToEnd();
                doc.LoadXml(text);
            };
            
            SportsScoresKey          = doc.SelectSingleNode("AppConfig/SportsScoresKey").InnerText;
            SportsScoresBaseEndpoint = doc.SelectSingleNode("AppConfig/SportsScoresBaseEndpoint").InnerText;
            SportsScoresDate         = doc.SelectSingleNode("AppConfig/SportsScoresDate").InnerText;
            SportsScoresLeagueId     = doc.SelectSingleNode("AppConfig/SportsScoresLeagueId").InnerText;
            SportsScoresTeamId       = doc.SelectSingleNode("AppConfig/SportsScoresTeamId").InnerText;
            StocksKey                = doc.SelectSingleNode("AppConfig/StocksKey").InnerText;
            StocksBaseEndpoint       = doc.SelectSingleNode("AppConfig/StocksBaseEndpoint").InnerText;
            StocksQueryParam         = doc.SelectSingleNode("AppConfig/StocksQueryParam").InnerText;
            WeatherKey               = doc.SelectSingleNode("AppConfig/WeatherKey").InnerText;
            WeatherBaseEndpoint      = doc.SelectSingleNode("AppConfig/WeatherBaseEndpoint").InnerText;
            WeatherPath              = doc.SelectSingleNode("AppConfig/WeatherPath").InnerText;
            WeatherQueryParam        = doc.SelectSingleNode("AppConfig/WeatherQueryParam").InnerText;
            NewsFeedBaseEndpoint     = doc.SelectSingleNode("AppConfig/NewsFeedBaseEndpoint").InnerText;
            NewsFeedPath             = doc.SelectSingleNode("AppConfig/NewsFeedPath").InnerText;
            SportsNewsBaseEndpoint   = doc.SelectSingleNode("AppConfig/SportsNewsBaseEndpoint").InnerText;
            SportsNewsPath           = doc.SelectSingleNode("AppConfig/SportsNewsPath").InnerText;
            UseMetric                = doc.SelectSingleNode("AppConfig/UseMetric").InnerText;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static string SportsScoresKey { get; private set; }

        public static string SportsScoresBaseEndpoint { get; private set; }

        public static string SportsScoresDate { get; private set; }

        public static string SportsScoresLeagueId { get; private set; }

        public static string SportsScoresTeamId { get; private set; }

        public static string StocksKey { get; private set; }

        public static string StocksBaseEndpoint { get; private set; }

        public static string StocksQueryParam { get; private set; }

        public static string WeatherKey { get; private set; }

        public static string WeatherBaseEndpoint { get; private set; }

        public static string WeatherPath { get; private set; }

        public static string WeatherQueryParam { get; private set; }

        public static string NewsFeedBaseEndpoint { get; private set; }

        public static string NewsFeedPath { get; private set; }

        public static string SportsNewsBaseEndpoint { get; private set; }

        public static string SportsNewsPath { get; private set; }

        public static string UseMetric { get; private set; }
    }
}
