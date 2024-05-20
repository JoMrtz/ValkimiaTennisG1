using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request.Player;
using ValkimiaTennisG1.Models.Response.Player;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> CreatePlayer(PlayerRequest player);

        Task<IEnumerable<PlayersResponse>> GetPlayers();
        public int CalculatePlayerScore(Player player);
        Task<bool> DeletePlayerAsync(int id);
    }
}
