using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request.Tournament;
using ValkimiaTennisG1.Models.Response.Player;
using ValkimiaTennisG1.Models.Response.Tournament;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<Tournament> CreateTournamentAsync(TournamentRequest request);
        //  Task<IEnumerable<TournamentResponse>> GetTournaments();
        Task<PlayerWinnerResponse> GenerateTournamentWinnerAsync(TournamentRequest tournamentRequest, int genderId);

        Task<IEnumerable<AllTournamentsResponse>> GetAllTournaments();
        Task<OneTournamentResponse> GetOneTournamentAsync(int tournamentId);
    }
}
