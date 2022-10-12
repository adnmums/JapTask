using Platform.Core.Entities;
using Platform.Core.Requests.Comment;
using Platform.Core.Requests.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Requests.Student
{
    public class StudentDto
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public StudentStatus Status { get; set; }
        public SingleSelectionDto? Selection { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
