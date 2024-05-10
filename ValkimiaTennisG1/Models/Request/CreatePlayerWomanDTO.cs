namespace ValkimiaTennisG1.Models.Request
{
    public class CreatePlayerWomanDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int? Strength { get; set; } = null;
        public int? Speed { get; set; } = null;
        public int ReactionTime { get; set; }
    }
}
