using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dev.App.ViewModels
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string IdCompany { get; set; }
        public string IdBranch { get; set; }
        
        [DisplayName("Empresa")]
        public string NameCompany { get; set; }
        
        [DisplayName("Unidade")]
        public string NameBranch { get; set; }
        public IEnumerable<ProspectViewModel> Projetos { get; set; }
    }
}
