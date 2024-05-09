using System.ComponentModel.DataAnnotations;

namespace ValkimiaTennisG1.Models.Request
{
    public class PlayerRequest
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2)]
        public int Ability { get; set; }
        [MaxLength(2)]
        public int Strength { get; set; }
        [MaxLength(2)]
        public int Speed { get; set; }
        [MaxLength(2)]
        public int ReactionTime { get; set; }
    }
}