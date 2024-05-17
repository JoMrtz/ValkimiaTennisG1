using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Models.Request
{
    public class TournamentPlayerList
    {
        public int TournamentId { get; set; }
        public List<int> PlayerIds { get; set; }
    }
}
