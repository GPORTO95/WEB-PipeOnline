using System.Collections.Generic;

namespace Dev.Business.Models
{
    public class Segment : Entity
    {
        public Segment() { }

        public Segment(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
