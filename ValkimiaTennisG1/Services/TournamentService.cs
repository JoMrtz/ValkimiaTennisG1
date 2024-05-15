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
        public TournamentService(TennisContext context)
        {
            _context = context;
        }

        public async Task<Tournament> CreateTournament(TournamentRequest newTournament)
        {
            var tournament = newTournament;
            await _context.AddAsync(tournament);
            await _context.SaveChangesAsync();
            return tournament;
            throw new Exception("Hubo un problema al generar el Torneo");
        }

        public Task<Tournament> GenerateTournamentWinner()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TournamentResponse>> GetTournaments()
        {
            throw new NotImplementedException();
        }


        //public async Task<IEnumerable<PlayersResponse>> GetPlayers()
        //{
        //    var result = await _context.Player.ToListAsync();

        //    var mappedsult = result.Select(x => x.ToPlayersResponse());


        //    return mappedsult;
        //}


    }
}
