using ValkimiaTennisG1.Mappers.MatchPlayers;
using ValkimiaTennisG1.Mappers.Matchs;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1.Services
{
        public class MatchService : IMatchService
        {
            private readonly IPlayerService _playerService;
            private readonly TennisContext _context;
            public MatchService(TennisContext context, IPlayerService playerService)
            {
                _context = context;
                _playerService = playerService;
        }

            public async Task<Match> CreateMatchAsync(Player player1, Player player2, int tournamentId)
            {
                var match = MatchMapper.ToMatch(tournamentId);

                // Calcular el puntaje de cada jugador con el factor de suerte
                var player1Score = _playerService.CalculatePlayerScore(player1) + GetLuckFactor();
                var player2Score = _playerService.CalculatePlayerScore(player2) + GetLuckFactor();

                // Decidir el ganador
                var player1IsWinner = player1Score > player2Score;

                // Usar el mapper para crear los registros de MatchPlayer
                match.MatchPlayers.Add(MatchPlayerMapper.ToMatchPlayer(player1, match.Id, player1IsWinner));
                match.MatchPlayers.Add(MatchPlayerMapper.ToMatchPlayer(player2, match.Id, !player1IsWinner));

                await _context.Match.AddAsync(match);
                await _context.SaveChangesAsync();

                return match;
            }

           

            private int GetLuckFactor()
            {
                Random random = new Random();
                return random.Next(0, 11); // Valor aleatorio entre 0 y 10
            }
        }

    }



