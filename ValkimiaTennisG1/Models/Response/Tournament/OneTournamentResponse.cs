using ValkimiaTennisG1.Models.Response.Match;

namespace ValkimiaTennisG1.Models.Response.Tournament
{
    public class OneTournamentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CourtType { get; set; }
        public int? Winner { get; set; }
        public List<MatchResponse> Matches { get; set; }
    }
}
