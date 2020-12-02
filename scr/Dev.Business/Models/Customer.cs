using System;
using System.Collections.Generic;

namespace Dev.Business.Models
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public Guid SegmentId { get; private set; }
        public Segment Segment { get; private set; }
        public IEnumerable<Prospect> Prospects { get; set; }
    }
}
