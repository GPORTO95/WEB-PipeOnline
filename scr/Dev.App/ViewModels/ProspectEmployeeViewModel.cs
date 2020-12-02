using System;

namespace Dev.App.ViewModels
{
    public class ProspectEmployeeViewModel
    {
        public ProspectEmployeeViewModel()
        {}

        public ProspectEmployeeViewModel(Guid employeeId)
        {
            EmployeeId = employeeId;
        }

        public Guid ProspectId { get; set; }
        public Guid EmployeeId { get; set; }

        public ProspectViewModel Prospect { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
