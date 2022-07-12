using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Match
    {
        public Match()
        {
            Bets = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int GoalsHost { get; set; }
        public int GoalsGuest { get; set; }
        public decimal XGHost { get; set; }
        public decimal XgGuest { get; set; }
        public decimal OddsHost { get; set; }
        public decimal OddsGuest { get; set; }
        public decimal OddsDraw { get; set; }
        public int HostId { get; set; }
        public int GuestId { get; set; }
        public int CompetitionId { get; set; }
        public int SeasonId { get; set; }
        public int FixtureNumber { get; set; }

        public virtual Competition Competition { get; set; } = null!;
        public virtual Club Guest { get; set; } = null!;
        public virtual Club Host { get; set; } = null!;
        public virtual Season Season { get; set; } = null!;
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
