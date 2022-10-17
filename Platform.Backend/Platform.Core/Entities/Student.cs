namespace Platform.Core.Entities
{
    public class Student : User
    {
        public StudentStatus Status { get; set; }
        public Guid? SelectionId { get; set; }
        public Selection? Selection { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
