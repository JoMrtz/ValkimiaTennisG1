using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface ITournamentService
    {
        Task<Tournament> CrearTournament();
    }
}
