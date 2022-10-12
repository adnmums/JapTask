using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Requests.Comment
{
    public class CreateCommentDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid StudentId { get; set; }
    }
}
