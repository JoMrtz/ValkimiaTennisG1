using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;
using ValkimiaTennisG1.Services;
using ValkimiaTennisG1.Models.Response.Tournament;
using ValkimiaTennisG1.Models.Response.Player;
using ValkimiaTennisG1.Models.Request.Tournament;

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

        [Route("SimulateTournament")]
        [HttpPost]
        public async Task<ActionResult<PlayerWinnerResponse>> GenerateTournamentWinner([FromQuery] int genderId, [FromBody] TournamentRequest tournamentRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var winner = await _tournamentService.GenerateTournamentWinnerAsync(tournamentRequest, genderId);
            var winnerResponse = new PlayerWinnerResponse { Id = winner.Id, Name = winner.Name };
            return Ok(winnerResponse);
        }

        [Route("GetAllTournaments")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllTournamentsResponse>>> GetAllTournaments()
        {
            var tournaments = await _tournamentService.GetAllTournaments();
            return Ok(tournaments);
        }
        [Route("GetOneTournament/{id}")]
        [HttpGet]
        public async Task<ActionResult<OneTournamentResponse>> GetOneTournament(int id)
        { 
            var tournament = await _tournamentService.GetOneTournamentAsync(id);
            return Ok(tournament);
        }
          
        
              
            
      

    }
}
