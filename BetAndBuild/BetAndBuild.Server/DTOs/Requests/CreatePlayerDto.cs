using System.ComponentModel.DataAnnotations;

namespace BetAndBuild.Server.DTOs.Requests
{
    public record CreatePlayerDto
    {
        [Required]
        public string Login { get; set; } 
        [Required]
        public string Email { get; set; } 
        [Required]
        public decimal Budget { get; set; }
       

    }
}
