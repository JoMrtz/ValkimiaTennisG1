using System.ComponentModel.DataAnnotations;

namespace ValkimiaTennisG1.Models.Request.Tournament
{
    public class TournamentRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string CourtType { get; set; }
        [Required]
        public List<int> PlayerIds { get; set; }
    }
}
