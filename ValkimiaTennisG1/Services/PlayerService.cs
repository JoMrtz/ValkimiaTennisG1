using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly TennisContext _context;
        public PlayerService(TennisContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayer(PlayerRequest player)
        {

            if (player.ReactionTime == null)
            {
                Player playerM = new Player()
                {
                    Id = 0,
                    GenderId = 1,
                    Name = player.Name,
                    Ability = player.Ability,
                    Strength = player.Strength,
                    Speed = player.Speed,
                    ReactionTime = null

                };
                await _context.AddAsync(playerM);
                await _context.SaveChangesAsync();
                return playerM;
            }
            else
            {
                Player playerW = new Player()
                {
                    Id = 0,
                    GenderId = 2,
                    Name = player.Name,
                    Ability = player.Ability,
                    Strength = null,
                    Speed = null,
                    ReactionTime = player.ReactionTime

                };
                await _context.AddAsync(playerW);
                await _context.SaveChangesAsync();
                return playerW;

            }
        }
        public async Task<IEnumerable<PlayersResponse>> GetPlayers()
        {
            var result = await _context.Player.ToListAsync();
            
            var players = result.Select(x => new PlayersResponse
            {
      
                Name = x.Name,
                Ability = x.Ability,
                Gender = x.GenderId,
            });
            return players;
        }
    }
}
