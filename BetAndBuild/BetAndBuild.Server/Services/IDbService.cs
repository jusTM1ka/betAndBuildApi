namespace BetAndBuild.Server.Services
{
    using BetAndBuild.Server.DTOs.Requests;
    using BetAndBuild.Server.DTOs.Responses;
    using BetAndBuild.Server.Models;
    public interface IDbService
    {
        Task<PlayerDto> GetPlayerById(int id);
        Task<IEnumerable<Player>> GetPlayers();
        Task CreatePlayer(CreatePlayerDto player);
        Task UpdatePlayer(int id, EditPlayerDto player);
        Task DeletePlayer(int id);
        Task<ClubDto>GetClubById(int id);
        Task<IEnumerable<Club>> GetClubs();
        Task CreateClub(CreateClubDto club);
        Task UpdateClub(int id, EditClubDto club);
        Task DeleteClub(int id);
        Task<SeasonDto> GetSeasonById(int id);
        Task<IEnumerable<Season>> GetSeasons();
        Task CreateSeason(CreateSeasonDto season);
        Task UpdateSeason(int id, EditSeasonDto season);
        Task DeleteSeason(int id);
    }
}
