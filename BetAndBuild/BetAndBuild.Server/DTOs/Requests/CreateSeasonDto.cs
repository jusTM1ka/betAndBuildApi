using System.ComponentModel.DataAnnotations;

namespace BetAndBuild.Server.DTOs.Requests
{
    public class CreateSeasonDto
    {
        [Required]
        public string Name { get; set; } 
    }
}
