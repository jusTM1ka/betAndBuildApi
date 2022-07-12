using System;
using System.Collections.Generic;

namespace BetAndBuild.Server.Models
{
    public partial class UserPassword
    {
        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public string Salt { get; set; } = null!;
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual Player Player { get; set; } = null!;
    }
}
