using Platform.Core.Entities;
using Platform.Core.Requests.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Requests.Selection
{
    public class SingleSelectionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public SelectionStatus Status { get; set; }
        public ProgramDto? Program { get; set; }
    }
}
