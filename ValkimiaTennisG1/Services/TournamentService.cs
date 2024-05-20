using Microsoft.EntityFrameworkCore;
using System;
using ValkimiaTennisG1.Excepcion;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Repository;
using ValkimiaTennisG1.Services.Interfaces;
using ValkimiaTennisG1.Mappers.Tournaments;
using ValkimiaTennisG1.Models.Response.Tournament;
using ValkimiaTennisG1.Models.Response.Player;
using ValkimiaTennisG1.Models.Response.Match;
using ValkimiaTennisG1.Models.Request.Tournament;

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

        public async Task<Tournament> CreateTournamentAsync(TournamentRequest request)
        {
            // Crear el torneo
            var tournament = TournamentMapper.ToTournament(request);

            // Añadir el torneo a la base de datos
            await _context.Tournament.AddAsync(tournament);
            await _context.SaveChangesAsync();

            return tournament;
        }

        public async Task<PlayerWinnerResponse> GenerateTournamentWinnerAsync(TournamentRequest tournamentRequest, int genderId)
        {
            // Obtengo los jugadores del torneo
            var players = await _context.Player.Where(p => tournamentRequest.PlayerIds.Contains(p.Id)).ToListAsync();

            if (players.Count %2 != 0)
            {
                throw new BadRequestException("Error en la cantidad de jugadores", "la cantidad de jugadores debe ser par");
            }

            if (players.Count != tournamentRequest.PlayerIds.Count)
            {
                throw new BadRequestException("Error encontrando jugador", "Uno o más jugadores no fueron encontrados");
            }

            if (players.Any(p => p.GenderId != genderId))
            {
                throw new BadRequestException("Error", "Todos los jugadores deben ser del mismo género para este torneo");
            }


            var tournament = await CreateTournamentAsync(tournamentRequest);
            

            List<Player> remainingPlayers = players;

            
            while (remainingPlayers.Count > 1)
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
                
            }

            Player finalWinner = remainingPlayers.First();
            tournament.Winner = finalWinner.Id;

            // Guardar el ganador del torneo en la base de datos
            _context.Tournament.Update(tournament);
            await _context.SaveChangesAsync();

            // Crear el objeto PlayerWinnerResponse con los datos del ganador
            var winnerResponse = TournamentMapper.ToPlayerWinnerResponse(finalWinner);
            return winnerResponse;
        }



        public async Task<OneTournamentResponse> GetOneTournamentAsync(int tournamentId)
        {
            var tournament = await _context.Tournament
                .Include(t => t.Matches)
                .ThenInclude(m => m.MatchPlayers)
                .ThenInclude(mp => mp.Player)
                .FirstOrDefaultAsync(t => t.Id == tournamentId);

            if (tournament == null)
            {
                throw new BadRequestException("Error encontrando el torneo","El ID ingresado no existe");
            }

            var response = new OneTournamentResponse
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Location = tournament.Location,
                CourtType = tournament.CourtType,
                Winner = tournament.Winner,
                Matches = tournament.Matches.Select(m => new MatchResponse
                {
                    Id = m.Id,
                    Date = m.Date,
                    WinnerId = m.MatchPlayers.First(mp => mp.Winner).PlayerId,
                    WinnerName = m.MatchPlayers.First(mp => mp.Winner).Player.Name
                }).ToList()
            };

            return response;
        }

        public async Task<IEnumerable<AllTournamentsResponse>> GetAllTournaments()
        {
            var result = await _context.Tournament.ToListAsync();
            var mappedResult = result.Select(x => x.ToTournamentResponse());
            return mappedResult;
        }
    }





}
