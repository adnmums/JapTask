namespace Platform.Core.Entities
{
    public class Student : User
    {
        public StudentStatus Status { get; set; }
        public Selection? Selection { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
