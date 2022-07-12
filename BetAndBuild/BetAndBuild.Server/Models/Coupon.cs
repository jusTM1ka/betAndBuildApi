using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Bets = new HashSet<Bet>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public bool Status { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
