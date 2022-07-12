using BetAndBuild.Server.Models;

namespace BetAndBuild.Server.DTOs.Responses
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public string CountryName { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<Object> ClubCompetitions { get; set; }
    }
}
