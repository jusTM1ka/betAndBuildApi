using BetAndBuild.Server.DTOs.Responses;
using BetAndBuild.Server.Models;

namespace BetAndBuild.Server
{
    public static class Extensions
    {
        public static PlayerDto ConvertToDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Email = player.Email,
                Login = player.Login,
                LastActivity = player.LastActivity,
                Budget = player.Budget,

                Bets = player.Bets.Select(b => new
                {
                    IdBet = b.Id,
                    BetDate = b.BetDate
                }).ToList(),
                UserPasswords = player.UserPasswords.Select(pass => new
                {
                    Id = pass.Id,
                    ExpireDate = pass.ExpireDate,
                    StartDate = pass.StartDate,
                    Password = pass.Password

                }).ToList()


            };
        }

        public static ClubDto ConvertToDto(this Club club)
        {
        
                return new ClubDto
                {
                    Id = club.Id,
                    Name = club.Name,
                    //CountryName = club.Country.Name,
                    CountryId = club.CountryId,
                    ClubCompetitions = club.ClubCompetitions.Select(c => new
                    {
                        CompetitonId = c.CompetitionId

                    }).ToList()


                };
            
         
        }
        public static SeasonDto ConvertToDto(this Season season)
        {
            return new SeasonDto
            {
                Id = season.Id,
                Name = season.Name
            };
        }

    }
}
