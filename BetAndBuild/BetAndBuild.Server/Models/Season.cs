using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Season
    {
        public Season()
        {
            ClubCompetitions = new HashSet<ClubCompetition>();
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ClubCompetition> ClubCompetitions { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
