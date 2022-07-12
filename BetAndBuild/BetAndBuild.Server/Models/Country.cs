using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class Country
    {
        public Country()
        {
            Clubs = new HashSet<Club>();
            Competitions = new HashSet<Competition>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
