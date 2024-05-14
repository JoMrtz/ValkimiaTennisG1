using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly TennisContext _context;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        [HttpGet("")]
        public async Task<ActionResult> GetPlayers()
        {
           var players = await _playerService.GetPlayers();
            return Ok(players);
        }

        [HttpPost("GeneratePlayer")]
        public async Task<IActionResult> PostPlayer([FromBody] PlayerRequest player) {

            await _playerService.CreatePlayer(player);
            
            return Created("creado", player);
   

        }
       

    }
}