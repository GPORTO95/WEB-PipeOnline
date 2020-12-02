using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Models
{
    public class ProspectEmployee
    {
        public Guid ProspectId { get; set; }
        public Guid EmployeeId { get; set; }

        public Prospect Prospect { get; set; }
        public Employee Employee { get; set; }
    }
}
