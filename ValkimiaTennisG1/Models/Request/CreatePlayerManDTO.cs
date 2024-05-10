namespace ValkimiaTennisG1.Models.Request
{
    public class CreatePlayerManDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ability { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int? ReactionTime { get; set; } = null;
    }
}
