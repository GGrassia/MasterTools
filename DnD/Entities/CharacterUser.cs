namespace DnD.Entities
{
    public class CharacterUser
    {
        public int CharacterId { get; set; }
        public int UserId { get; set; }
        public Character Character { get; set; }
        public User User { get; set; }
    }
}
