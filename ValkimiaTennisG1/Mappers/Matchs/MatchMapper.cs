using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Mappers.Matchs
{
    public static class MatchMapper
    {
        public static Match ToMatch(int tournamentId)
        {
            return new Match
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TournamentId = tournamentId,
                MatchPlayers = new List<MatchPlayer>()
            };
        }
    }
}
