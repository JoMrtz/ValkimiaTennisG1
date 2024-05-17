using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface IMatchService
    {
       public Task<Match> CreateMatchAsync(Player player1, Player player2, int tournamentId);
    }
}
