using System;

namespace LocalInfoApp.Display
{
    public class SportsScores
    {
        private static SportsScores _sampleSports = new SportsScores
        {
            AwayTeam = "Away Team",
            AwayTeamScore = 0,
            DateOfEvent = new DateTime(2001, 1, 1),
            HomeTeam = "Home Team",
            HomeTeamScore = 0,
            Status = "FINAL",
            State = DisplayState.NoKey
        };

        public DateTime DateOfEvent { get; set; }

        public string AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public string HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public string Status { get; set; }

        public DisplayState State { get; set; }

        public static SportsScores GetSampleData()
        {
            return _sampleSports;
        }
    }
}
