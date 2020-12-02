using System.Collections.Generic;
using System.ComponentModel;

namespace Dev.App.ViewModels
{
    public class ProspectListViewModel
    {
        public IEnumerable<ProspectViewModel> ProspectViewModels { get; set; }

        [DisplayName("Clientes")]
        public string CustomerIds { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }
        
        [DisplayName("Tipos")]
        public string Types { get; set; }
        
        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Dono do projeto")]
        public string EmployeeIds { get; set; }

        [DisplayName("Período abertura")]
        public string DateOpening { get; set; }

        [DisplayName("Temperatura")]
        public string Temperatures { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; }
    }
}
