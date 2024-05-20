using System.ComponentModel.DataAnnotations;

namespace ValkimiaTennisG1.Models.Request.Player
{
    public class PlayerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Ability { get; set; }

        public int? Strength { get; set; }

        public int? Speed { get; set; }

        public int? ReactionTime { get; set; }
        [Required]
        public int GenderId { get; set; }
    }
}