using Microsoft.EntityFrameworkCore;
using System;
using ValkimiaTennisG1.Excepcion;
using ValkimiaTennisG1.Mappers.Tournaments;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly TennisContext _context;
        private readonly IMatchService _matchService;

        public TournamentService(TennisContext context, IMatchService matchService)
        {
            _context = context;
            _matchService = matchService;
        }

        public async Task<Tournament> CreateTournamentAsync(TournamentRequest newTournament)
        {

            // Crear el torneo forma vieja
            //var tournament = new Tournament
            //{
            //    Name = request.Name,
            //    Location = request.Location,
            //    CourtType = request.CourtType,
            //    Matches = new List<Match>()
            //};

            // Crear el torneo
            var tournament = newTournament.ToTournament(); //Falta matches en el mapper?

            // Añadir torneo a la base de datos
            await _context.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;

            throw new Exception("Hubo un problema al generar el Torneo");
        }


        public async Task<PlayerWinnerResponse> GenerateTournamentWinnerAsync(TournamentPlayerList tournamentPlayerList)
        {
            var tournament = await _context.Tournament
                .Include(t => t.Matches)
                .ThenInclude(m => m.MatchPlayers)
                .FirstOrDefaultAsync(t => t.Id == tournamentPlayerList.TournamentId);

            if (tournament == null)
            {
                throw new Exception("Torneo no encontrado");
            }

            // Obtener los jugadores del torneo
            var players = await _context.Player
                .Where(p => tournamentPlayerList.PlayerIds.Contains(p.Id))
                .ToListAsync();

            if (players.Count != tournamentPlayerList.PlayerIds.Count)
            {
                throw new Exception("Uno o más jugadores no fueron encontrados");
            }

            List<Player> remainingPlayers = players;
            var flag = true;
            while (remainingPlayers.Count > 1 && flag)
            {
                List<Player> winners = new List<Player>();

                for (int i = 0; i < remainingPlayers.Count; i += 2)
                {
                    Player player1 = remainingPlayers[i];
                    Player player2 = remainingPlayers[i + 1];

                    Match match = await _matchService.CreateMatchAsync(player1, player2, tournament.Id);

                    // Obtener el ganador del partido
                    Player winner = match.MatchPlayers.First(mp => mp.Winner).Player;
                    winners.Add(winner);
                }

                remainingPlayers = winners;
                flag = false;
            }

            Player finalWinner = remainingPlayers.First();
            tournament.Winner = finalWinner.Id;

            // Guardar el ganador del torneo en la base de datos
            _context.Tournament.Update(tournament);
            await _context.SaveChangesAsync();

            // Crear el objeto PlayerWinnerResponse con los datos del ganador
            //var winnerResponse = new PlayerWinnerResponse
            //{
            //    Id = finalWinner.Id,
            //    Name = finalWinner.Name
            //};
            //return winnerResponse;

            // Crear el objeto PlayerWinnerResponse con los datos del ganador
            var winnerResponse = new PlayerWinnerResponse
            {
                Id = finalWinner.Id,
                Name = finalWinner.Name
            };

            return winnerResponse;
        }


    }





}
