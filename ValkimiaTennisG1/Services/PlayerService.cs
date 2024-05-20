using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ValkimiaTennisG1.Excepcion;
using ValkimiaTennisG1.Mappers.Players;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request.Player;
using ValkimiaTennisG1.Models.Response.Player;
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
            var playerGender = await _context.Gender.FirstOrDefaultAsync(g => g.Id == newPlayer.GenderId) ?? throw new BadRequestException("error ingresando el genero", "el genero no existe");

            if (playerGender.GenderType == Enums.GenderType.Man)
            {
                var player = newPlayer.ToPlayerMan();
                await _context.AddAsync(player);
                await _context.SaveChangesAsync();
                return player;
            }
            else if (playerGender.GenderType == Enums.GenderType.Woman)
            {
                var player = newPlayer.ToPlayerWoman();
                await _context.AddAsync(player);
                await _context.SaveChangesAsync();
                return player;
            }

            throw new BadRequestException("Error", "Hubo un problema al generar el Jugador");

        }

        public async Task<IEnumerable<PlayersResponse>> GetPlayers()
        {
            var result = await _context.Player.ToListAsync();

            var mappedsult = result.Select(x => x.ToPlayersResponse());


            return mappedsult;
        }
        public int CalculatePlayerScore(Player player)
        {
            int baseScore = player.Ability;

            int specialScore = player.GenderId == 1 ? (player.Strength ?? 0) + (player.Speed ?? 0) : player.ReactionTime ?? 0;

            return baseScore + specialScore;
        }
        public async Task<bool> DeletePlayerAsync(int id)
        {
            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return false;
            }
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
