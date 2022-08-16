using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Services;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("Match/{MatchId}/[controller]")]
    public class PlayerController : DefaultController
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid MatchId)
        {
            return await ExecuteCall(async () =>
            {
                var matches = await _playerService.GetAll(MatchId);
                return Ok(matches);
            });
        }

        [HttpGet("{id}", Name = "PlayerDatails")]
        public async Task<IActionResult> Get(Guid MatchId, Guid id)
        {
            return await ExecuteCall(async () =>
            {
                var match = await _playerService.Get(MatchId, id);
                return Ok(match);
            });
        }

        [HttpPost]
        public async Task<IActionResult> NewPlayer(Guid MatchId, [FromBody] PlayerCreateContract newPlayer)
        {
            return await ExecuteCall(async () =>
            {
                var player = await _playerService.NewPlayer(MatchId, newPlayer);
                return CreatedAtRoute("PlayerDatails", new { MatchId = MatchId, Id = player.Id }, player);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid MatchId, [FromBody] PlayerUpdateContract player)
        {
            return await ExecuteCall(async () =>
            {
                await _playerService.Update(MatchId, player);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid MatchId, Guid id)
        {
            return await ExecuteCall(async () =>
            {
                await _playerService.Delete(MatchId, id);
                return NoContent();
            });
        }
    }
}
