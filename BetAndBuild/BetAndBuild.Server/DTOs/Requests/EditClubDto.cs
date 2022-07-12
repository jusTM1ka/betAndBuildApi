using System.ComponentModel.DataAnnotations;

namespace BetAndBuild.Server.DTOs.Requests
{
    public class EditClubDto
    {
        [Required]
        public string Name { get; set; }
    }
}
