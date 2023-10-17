namespace NoteTakingApp.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
