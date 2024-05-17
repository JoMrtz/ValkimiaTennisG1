using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;
using ValkimiaTennisG1.Services;

namespace ValkimiaTennisG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        public async Task<ActionResult<Tournament>> CreateTournament([FromBody] TournamentRequest request)
        {
            var tournament = await _tournamentService.CreateTournamentAsync(request);
            return CreatedAtAction(nameof(CreateTournament), new { id = tournament.Id }, tournament);
        }

        [HttpPost("generate-winner")]
        public async Task<ActionResult<Player>> GenerateTournamentWinner([FromBody] TournamentPlayerList tournamentPlayerList)
        {
            var winner = await _tournamentService.GenerateTournamentWinnerAsync(tournamentPlayerList);
            return Ok(winner);
        }
    }
}
