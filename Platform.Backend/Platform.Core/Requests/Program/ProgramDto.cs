namespace Platform.Core.Requests.Program
{
    public class ProgramDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
