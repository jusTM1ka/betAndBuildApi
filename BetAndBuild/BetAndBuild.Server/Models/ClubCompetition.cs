using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class ClubCompetition
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int CompetitionId { get; set; }
        public int SeasonId { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual Competition Competition { get; set; } = null!;
        public virtual Season Season { get; set; } = null!;
    }
}
