using ValkimiaTennisG1.Models.Entities;

namespace ValkimiaTennisG1.Mappers.MatchPlayers
{
    public static class MatchPlayerMapper
    {
        public static MatchPlayer ToMatchPlayer(Player player, int matchId, bool isWinner)
        {
            return new MatchPlayer
            {
                PlayerId = player.Id,
                MatchId = matchId,
                Winner = isWinner
            };
        }
    }
}
