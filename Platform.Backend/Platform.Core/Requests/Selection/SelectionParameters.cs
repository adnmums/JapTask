using Platform.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Requests.Selection
{
    public class SelectionParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
    }
}
