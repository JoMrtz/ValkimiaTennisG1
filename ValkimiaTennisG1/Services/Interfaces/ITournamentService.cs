using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<Tournament> CreateTournamentAsync(TournamentRequest request);
        //  Task<IEnumerable<TournamentResponse>> GetTournaments();
        Task<Player> GenerateTournamentWinnerAsync(TournamentPlayerList playersList);

    }
}
