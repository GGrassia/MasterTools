namespace DnD.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
