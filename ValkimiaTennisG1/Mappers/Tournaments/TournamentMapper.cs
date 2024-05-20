using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Response.Tournament;
using ValkimiaTennisG1.Models.Response.Player;
using ValkimiaTennisG1.Models.Request.Tournament;

namespace ValkimiaTennisG1.Mappers.Tournaments
{
    public static class TournamentMapper
    { 
        public static Tournament ToTournament(this TournamentRequest newTournament)
        {
            return new Tournament
            {
                Name = newTournament.Name,
                Location = newTournament.Location,
                CourtType = newTournament.CourtType
            };
        }

        public static AllTournamentsResponse ToTournamentResponse(this Tournament tournament)
        {
            return new AllTournamentsResponse
            {
                Name = tournament.Name,
                Location = tournament.Location,
                CourtType = tournament.CourtType,
                Winner = tournament.Winner
            };
        }

        public static PlayerWinnerResponse ToPlayerWinnerResponse(this Player player)
        {
            return new PlayerWinnerResponse
            {
                Name = player.Name,
                Id = player.Id

            };
        }
    }
    
}
