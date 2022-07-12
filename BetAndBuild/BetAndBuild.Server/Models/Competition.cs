using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Competition
    {
        public Competition()
        {
            ClubCompetitions = new HashSet<ClubCompetition>();
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TeamsCounter { get; set; }
        public int? CountryId { get; set; }
        public bool IsLeagueCompetition { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<ClubCompetition> ClubCompetitions { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
