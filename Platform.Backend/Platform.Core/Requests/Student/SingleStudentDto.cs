using Platform.Core.Entities;

namespace Platform.Core.Requests.Student
{
    public class SingleStudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
    }
}
