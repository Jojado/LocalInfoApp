using System;

namespace LocalInfoApp
{
    public class DisplaySportsScores
    {
        public DateTime DateOfEvent { get; set; }

        public string AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public string HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public string Status { get; set; }

        public static DisplaySportsScores CreateSampleData()
        {
            return new DisplaySportsScores
            {
                AwayTeam = "Away Team",
                AwayTeamScore = 0,
                DateOfEvent = new DateTime(2001, 1, 1),
                HomeTeam = "Home Team",
                HomeTeamScore = 0,
                Status = "FINAL"
            };
        }
    }
}
