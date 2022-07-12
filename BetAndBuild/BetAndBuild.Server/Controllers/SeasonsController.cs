using BetAndBuild.Server.DTOs.Requests;
using BetAndBuild.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetAndBuild.Server.Controllers
{
    [Route("seasons")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private static IDbService _service;
        public SeasonsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeasons()
        {

            var seasons = await _service.GetSeasons();
            return Ok(seasons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getSeason(int id)
        {
            var season = await _service.GetSeasonById(id);
            if (season is null)
            {
                return NotFound("Season not found");
            }
            return Ok(season);
        }

        [HttpPost]
        public async Task<IActionResult> createSeason(CreateSeasonDto seasonDto)
        {
            
            await _service.CreateSeason(seasonDto);

            return Ok("Season created");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSeason(int id, EditSeasonDto seasonDto)
        {
            var oldItem = await _service.GetSeasonById(id);
            if (oldItem is null)
            {
                return NotFound("Season not found");
            }

            await _service.UpdateSeason(id, seasonDto);
            return Ok("Season edited");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var existCheck = await _service.GetSeasonById(id);
            if (existCheck is null)
            {
                return NotFound("Season not found");
            }
            await _service.DeleteSeason(id);
            return Ok("Season deleted");
        }
    }
}
