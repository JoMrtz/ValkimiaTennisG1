using System.ComponentModel.DataAnnotations;

namespace ValkimiaTennisG1.Models.Request
{
    public class PlayerRequest
    {
        
        public string Name { get; set; }
        
        public int Ability { get; set; }
       
        public int? Strength { get; set; }
      
        public int? Speed { get; set; }
       
        public int? ReactionTime { get; set; }
    }
}