using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Models
{
    public class Employee : Entity
    {
        public string Name { get; set; }

        /* EF Relations */
        public IEnumerable<Prospect> Prospects { get; set; }

        public IEnumerable<ProspectEmployee> ProspectEmployees { get; set; }
    }
}
