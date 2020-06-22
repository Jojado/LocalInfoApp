using System;

namespace LocalInfoApp.Display
{
    public class SportsScores : IDisplayState
    {
        public DateTime DateOfEvent { get; set; }

        public string AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public string HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        public string Status { get; set; }

        public DisplayState State { get; set; }
    }
}
