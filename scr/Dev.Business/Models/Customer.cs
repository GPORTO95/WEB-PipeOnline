﻿using System;
using System.Collections.Generic;

namespace Dev.Business.Models
{
    public class Customer : Entity
    {
        public Customer() { }

        public Customer(
            Guid id, string name, string cNPJ, string email, Guid segmentId)
        {
            Id = id;
            Name = name;
            CNPJ = cNPJ;
            Email = email;
            SegmentId = segmentId;
        }

        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public Guid SegmentId { get; private set; }
        public Segment Segment { get; private set; }
        public IEnumerable<Prospect> Prospects { get; set; }
    }
}
