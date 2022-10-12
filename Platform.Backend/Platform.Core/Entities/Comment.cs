namespace Platform.Core.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User? Author { get; set; }
        public Student? Student { get; set; }
    }
}
