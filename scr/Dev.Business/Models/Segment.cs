using System.Collections.Generic;

namespace Dev.Business.Models
{
    public class Segment : Entity
    {
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
