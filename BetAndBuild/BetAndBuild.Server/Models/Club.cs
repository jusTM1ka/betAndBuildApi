using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Club
    {
        public Club()
        {
            ClubCompetitions = new HashSet<ClubCompetition>();
            MatchGuests = new HashSet<Match>();
            MatchHosts = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<ClubCompetition> ClubCompetitions { get; set; }
        public virtual ICollection<Match> MatchGuests { get; set; }
        public virtual ICollection<Match> MatchHosts { get; set; }
    }
}
