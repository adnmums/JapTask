namespace Platform.Core.Entities
{
    public class Student
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public Selection? Selection { get; set; }
        public virtual List<Comment>? Comments { get; set; }
    }
}
