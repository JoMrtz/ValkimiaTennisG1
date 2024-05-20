

namespace ValkimiaTennisG1.Models.Response.Match
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int WinnerId { get; set; }
        public string WinnerName { get; set; }

    }

}
