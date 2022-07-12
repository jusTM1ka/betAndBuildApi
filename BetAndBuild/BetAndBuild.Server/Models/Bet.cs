using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Bet
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int GoalsHost { get; set; }
        public int GoalsGuest { get; set; }
        public bool WinHost { get; set; }
        public bool WinGuest { get; set; }
        public bool Draw { get; set; }
        public DateTime BetDate { get; set; }
        public int CouponId { get; set; }

        public virtual Coupon Coupon { get; set; } = null!;
        public virtual Match Match { get; set; } = null!;
        public virtual Player Player { get; set; } = null!;
    }
}
