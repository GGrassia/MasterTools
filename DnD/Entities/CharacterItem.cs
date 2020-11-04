namespace DnD.Entities
{
    public class CharacterItem
    {
        public int CharacterId { get; set; }
        public int ItemId { get; set; }
        public Character Character { get; set; }
        public Item Item { get; set; }
    }
}