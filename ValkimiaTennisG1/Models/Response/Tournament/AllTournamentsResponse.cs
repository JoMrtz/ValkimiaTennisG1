namespace ValkimiaTennisG1.Models.Response.Tournament
{
    public class AllTournamentsResponse
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string CourtType { get; set; }
        public int? Winner { get; set; }
    }
}
