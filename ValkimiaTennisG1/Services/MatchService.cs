using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1.Services
{
    public class MatchService : IMatchService
    {
        private readonly TennisContext _context;

        public MatchService(TennisContext context)
        {
            _context = context;
        }

        public async Task<Match> CreateMatchAsync(Player player1, Player player2, int tournamentId)
        {
            // Crear un nuevo match
            Match match = new Match
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TournamentId = tournamentId
            };



            // Determinar el ganador
            Player winner = DetermineWinner(player1, player2);




            // Actualizar los jugadores del match
            var matchPlayers = new List<MatchPlayer>
        {
            new MatchPlayer
            {
                Match = match,
                Player = player1,
                Winner = player1 == winner
            },
            new MatchPlayer
            {
                Match = match,
                Player = player2,
                Winner = player2 == winner
            }
        };

            match.MatchPlayers = matchPlayers;

            // Guardar el match en la base de datos
            await _context.Match.AddAsync(match);
            await _context.SaveChangesAsync();

            return match;
        }

        public Player DetermineWinner(Player player1, Player player2)
        {
            int player1Score = CalculatePlayerScore(player1);
            int player2Score = CalculatePlayerScore(player2);

            return player1Score > player2Score ? player1 : player2;
        }

        private int CalculatePlayerScore(Player player)
        {
            int baseScore = player.Ability;
            int specialScore = 0;

            if (player.GenderId == 1) // Masculino
            {
                specialScore = (player.Strength ?? 0) + (player.Speed ?? 0);
            }
            else if (player.GenderId == 2) // Femenino
            {
                specialScore = player.ReactionTime ?? 0;
            }

            return baseScore + specialScore;
        }
    }


}
