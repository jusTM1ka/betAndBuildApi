using BetAndBuild.Server.DTOs.Requests;
using BetAndBuild.Server.DTOs.Responses;
using BetAndBuild.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BetAndBuild.Server.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;
        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task CreateClub(CreateClubDto clubDto)
        {
            var club = new Club
            {
                Name = clubDto.Name,
                CountryId = clubDto.CountryId
                
            };
            await _context.AddAsync(club);
            await _context.SaveChangesAsync();
        }

        public async Task  CreatePlayer(CreatePlayerDto playerDto)
        {
            var player = new Player
            {
                Login = playerDto.Login,
                Email = playerDto.Email,
                Budget = playerDto.Budget,
                LastActivity = DateTime.Now

            };
            await _context.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSeason(CreateSeasonDto seasonDto)
        {
            var season = new Season
            {
               Name=seasonDto.Name
            };
            await _context.AddAsync(season);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteClub(int id)
        {
            var clubToDelete = await _context.Clubs.Where(c => c.Id == id).FirstAsync();
            _context.Clubs.Remove(clubToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlayer(int id)
        {
            var playerToDelete  = await _context.Players.Where(p => p.Id == id).FirstAsync();
            _context.Players.Remove(playerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSeason(int id)
        {
            var seasonToDelete = await _context.Seasons.Where(s => s.Id == id).FirstAsync();
            _context.Seasons.Remove(seasonToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ClubDto> GetClubById(int id)
        {
            var club = await _context.Clubs.Include(c=> c.ClubCompetitions).Include(c => c.Country).Where(c => c.Id == id).FirstAsync();
            return club.ConvertToDto();
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            var clubsList = await _context.Clubs.Include(c => c.ClubCompetitions).Include(c=> c.Country).ToListAsync();
            return clubsList;
        }

        public async Task<PlayerDto> GetPlayerById(int id)
        {
            
            var player = await _context.Players.Include(p=>p.UserPasswords).Include(p=>p.Bets).Where(p => p.Id == id).FirstAsync();
            return player.ConvertToDto();
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var playersList = await _context.Players.Include(p => p.UserPasswords).Include(p => p.Bets).ToListAsync();
            return playersList;
        }

        public async Task<SeasonDto> GetSeasonById(int id)
        {
            var season = await _context.Seasons.Where(s => s.Id == id).FirstAsync();
            return season.ConvertToDto();
        }

        public async Task<IEnumerable<Season>> GetSeasons()
        {
            var seasonsList = await _context.Seasons.ToListAsync();
            return seasonsList;
        }

        public async Task UpdateClub(int id, EditClubDto club)
        {
            var clubToUpdate = await _context.Clubs.Where(c => c.Id == id).FirstAsync();
            clubToUpdate.Name = club.Name;
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayer(int id,EditPlayerDto player)
        {
            var playerToUpdate = await _context.Players.Where(p => p.Id == id).FirstAsync();
            playerToUpdate.Email = player.Email;
            playerToUpdate.Login = player.Login;
            playerToUpdate.Budget = player.Budget;
            playerToUpdate.LastActivity = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSeason(int id, EditSeasonDto season)
        {
            var seasonToUpdate = await _context.Seasons.Where(s => s.Id == id).FirstAsync();
            seasonToUpdate.Name = season.Name;
            await _context.SaveChangesAsync();
        }
    }
}
