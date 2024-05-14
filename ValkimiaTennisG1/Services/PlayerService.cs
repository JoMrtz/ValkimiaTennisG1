using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ValkimiaTennisG1.Mappers.Players;
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

        public async Task<Player> CreatePlayer(PlayerRequest newPlayer)
        {
            var playerGender = await _context.Gender.FirstOrDefaultAsync(g => g.Id == newPlayer.GenderId) ?? throw new Exception("El genero no existe");
          
           if (playerGender.GenderType == Enums.GenderType.Man)
            {
                var player = newPlayer.ToPlayerMan();
                await _context.AddAsync(player);
                await _context.SaveChangesAsync();
                return player;
            }
           else if(playerGender.GenderType == Enums.GenderType.Woman)
            {
                var player = newPlayer.ToPlayerWoman();
                await _context.AddAsync(player);
                await _context.SaveChangesAsync();
                return player;
            }

            throw new Exception("Hubo un problema al generar el Jugador");

        }

        public async Task<IEnumerable<PlayersResponse>> GetPlayers()
        {
            var result = await _context.Player.ToListAsync();
                
             var mappedsult = result.Select(x => x.ToPlayersResponse());


            return mappedsult;
        }
    }
}
