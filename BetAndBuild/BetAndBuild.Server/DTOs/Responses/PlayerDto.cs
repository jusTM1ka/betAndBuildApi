using BetAndBuild.Server.Models;

namespace BetAndBuild.Server.DTOs.Responses
{
    public record PlayerDto
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Budget { get; set; }
        public DateTime LastActivity { get; set; }

        public  IEnumerable<Object> Bets { get; set; }
        public  IEnumerable<Object> UserPasswords { get; set; }
    }
}
