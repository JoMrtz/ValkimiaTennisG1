using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;

namespace ValkimiaTennisG1.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> CreatePlayer(PlayerRequest player);

        Task<IEnumerable<PlayersResponse>> GetPlayers();
    }
}
