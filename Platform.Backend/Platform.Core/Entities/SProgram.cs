namespace Platform.Core.Entities
{
    public class SProgram
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Selection> Selections { get; set; } = new List<Selection>();
    }
}
