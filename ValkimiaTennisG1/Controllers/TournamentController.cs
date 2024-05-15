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
        private readonly TennisContext _context;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }



        //[HttpGet("")]
        //public async Task<ActionResult> GetPlayers()
        //{
        //    var players = await _playerService.GetPlayers();
        //    return Ok(players);
        //}


        [HttpPost("GenerateTournament")]
        public async Task<IActionResult> PostTournament([FromBody] TournamentRequest tournament)
        {

            await _tournamentService.CreateTournament(tournament);

            return Created("Torneo creado", tournament);


        }

    }
}
