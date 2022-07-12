using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial record Player
    {
        public Player()
        {
            Bets = new HashSet<Bet>();
            UserPasswords = new HashSet<UserPassword>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Budget { get; set; }
        public DateTime LastActivity { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<UserPassword> UserPasswords { get; set; }
    }
}
