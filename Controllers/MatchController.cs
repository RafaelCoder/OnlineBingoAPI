using Microsoft.AspNetCore.Mvc;
using OnlineBingoAPI.Contracts;
using OnlineBingoAPI.Services;
using System;
using System.Threading.Tasks;

namespace OnlineBingoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : DefaultController
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteCall(async () =>
            {
                var matches = await _matchService.GetAll();
                return Ok(matches);
            });
        }

        [HttpGet("{id}", Name = "MatchDatails")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExecuteCall(async () =>
            {
                var match = await _matchService.Get(id);
                return Ok(match);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatchCreateContract newMatch)
        {
            return await ExecuteCall(async () =>
            {
                var match = await _matchService.Create(newMatch);
                return CreatedAtRoute("MatchDatails", new { Id = match.Id }, match);
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MatchUpdateContract match)
        {
            return await ExecuteCall(async () =>
            {
                await _matchService.Update(match);
                return NoContent();
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExecuteCall(async () =>
            {
                await _matchService.Delete(id);
                return NoContent();
            });
        }
    }
}
