using BetAndBuild.Server.DTOs.Requests;
using BetAndBuild.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetAndBuild.Server.Controllers
{
    [ApiController]
    [Route("clubs")]
    public class ClubsController : ControllerBase
    {
        private static IDbService _service;
        public ClubsController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {

            var clubs = await _service.GetClubs();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getClub(int id)
        {
            var club = await _service.GetClubById(id);
            if (club is null)
            {
                return NotFound("Club not found");
            }
            return Ok(club);
        }

        [HttpPost]
        public async Task<IActionResult> createClubr(CreateClubDto clubDto)
        {
            await _service.CreateClub(clubDto);
            return Ok("Club created");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditClub(int id, EditClubDto clubDto)
        {
            var oldItem = await _service.GetClubById(id);
            if (oldItem is null)
            {
                return NotFound("Club not found");
            }

            await _service.UpdateClub(id, clubDto);
            return Ok("Club edited");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var existCheck = await _service.GetClubById(id);
            if (existCheck is null)
            {
                return NotFound("Club not found");
            }
            await _service.DeleteClub(id);
            return Ok("CLub deleted");
        }
    }
}
