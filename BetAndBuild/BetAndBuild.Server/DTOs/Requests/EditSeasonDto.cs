using System.ComponentModel.DataAnnotations;

namespace BetAndBuild.Server.DTOs.Requests
{
    public class EditSeasonDto
    {

        [Required]
        public string Name { get; set; } 
    }
}
