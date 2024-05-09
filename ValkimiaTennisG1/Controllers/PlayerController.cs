using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;

namespace ValkimiaTennisG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
            public List<Player> ListPlayers = new List<Player>()
            {
                new Player()
                {
                    Id = 1,
                    Name = "Pablo Romero",
                    Ability = 6,
                    Strength = 7,
                    Speed = 4,
                    ReactionTime = 4
                },
                new Player()
                {
                    Id = 2,
                    Name = "Ezequiel Mendez",
                    Ability = 8,
                    Strength = 6,
                    Speed = 3,
                    ReactionTime = 2
                },
                new Player()
                {
                    Id = 3,
                    Name = "John Doe",
                    Ability = 5,
                    Strength = 4,
                    Speed = 8,
                    ReactionTime = 5
                },
                new Player()
                {
                    Id = 4,
                    Name = "Roberto Sosa",
                    Ability = 9,
                    Strength = 4,
                    Speed = 7,
                    ReactionTime = 4
                },
                new Player()
                {
                    Id = 5,
                    Name = "Marcos Lopez",
                    Ability = 8,
                    Strength = 2,
                    Speed = 4,
                    ReactionTime = 10
                },
                new Player()
                {
                    Id = 6,
                    Name = "Jorge Rossi",
                    Ability = 2,
                    Strength = 10,
                    Speed = 2,
                    ReactionTime = 5
                },
                new Player()
                {
                    Id = 7,
                    Name = "Armando Barreda",
                    Ability = 9,
                    Strength = 4,
                    Speed = 3,
                    ReactionTime = 7
                },
                new Player()
                {
                    Id = 8,
                    Name = "Gregorio Pellegrini",
                    Ability = 9,
                    Strength = 8,
                    Speed = 9,
                    ReactionTime = 7
                },
            };

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(ListPlayers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlayerRequest playerRequest)
        {
            ListPlayers.Add(new Player()
            {
            Id = ListPlayers.Count+1,
            Name = playerRequest.Name,
            Ability = playerRequest.Ability,
            Strength = playerRequest.Strength,
            Speed = playerRequest.Speed,
            ReactionTime = playerRequest.ReactionTime
            });
            
            return Ok();
        }
    }
}