using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        /* EF Relations */
        public IEnumerable<Prospect> Prospects { get; set; }
    }
}
