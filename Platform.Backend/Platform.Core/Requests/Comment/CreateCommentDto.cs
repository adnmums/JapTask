namespace Platform.Core.Requests.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid StudentId { get; set; }
    }
}
