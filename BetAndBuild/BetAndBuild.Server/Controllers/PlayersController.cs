using BetAndBuild.Server.DTOs.Requests;
using BetAndBuild.Server.Models;
using BetAndBuild.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetAndBuild.Server.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private static IDbService _service;
        public PlayersController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {

            var players = await _service.GetPlayers();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPlayer(int id)
        {
            var player = await _service.GetPlayerById(id);
            if (player is null)
            {
                return NotFound("Player not found");
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> createPlayer(CreatePlayerDto playerDto)
        {
            await _service.CreatePlayer(playerDto);

            return Ok("Player created");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPlayer(int id, EditPlayerDto playerDto)
        {
            var oldItem = await _service.GetPlayerById(id);
            if (oldItem is null)
            {
                return NotFound("Player not found");
            }
            
            await _service.UpdatePlayer(id, playerDto);
            return Ok("Player edited");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var existCheck = await _service.GetPlayerById(id);
            if (existCheck is null)
            {
                return NotFound("Player not found");
            }
            await _service.DeletePlayer(id);
            return Ok("Player deleted");
        }
    }
}
