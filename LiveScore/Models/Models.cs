using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BasicInfrastructure.Persistence;

namespace LiveScore.Models
{
    public class Match : Entity
    {
        public DateTime MatchTime { get; set; }
    }

    public class Score : Entity
    {
        public Match Match { get; set; }

        public int TimeLeft { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

    }

    public class Team : Entity
    {
        public string Name { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
    }
}
