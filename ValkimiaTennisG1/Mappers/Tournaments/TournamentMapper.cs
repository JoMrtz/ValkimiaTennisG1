using System.Runtime.CompilerServices;
using ValkimiaTennisG1.Models.Entities;
using ValkimiaTennisG1.Models.Request;
using ValkimiaTennisG1.Models.Response;

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

        public static TournamentWinnerResponse ToTournamentWinnerResponse(this Tournament newTournamentWinner)
        {
            return new TournamentWinnerResponse
            {
                Id = newTournamentWinner.Id,
                Name = newTournamentWinner.Name
            };
        }
    }
}