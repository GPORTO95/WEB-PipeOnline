using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
