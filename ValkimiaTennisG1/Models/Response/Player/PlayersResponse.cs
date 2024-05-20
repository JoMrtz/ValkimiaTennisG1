using ValkimiaTennisG1.Enums;
using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Models.Response.Player
{
    public class PlayersResponse
    {
        public string Name { get; set; }

        public int Ability { get; set; }

        public GenderType Gender { get; set; }

    }
}
