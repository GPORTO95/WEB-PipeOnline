using System.Collections.Generic;

namespace Dev.Business.Models
{
    public class Company : Entity
    {
        public string IdCompany { get; set; }
        public string IdBranch { get; set; }
        public string NameCompany { get; set; }
        public string NameBranch { get; set; }

        public IEnumerable<Prospect> Prospects { get; set; }
    }
}
