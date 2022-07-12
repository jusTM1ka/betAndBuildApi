using System.ComponentModel.DataAnnotations;

namespace BetAndBuild.Server.DTOs.Requests
{
    public record CreateClubDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }

    }
}
