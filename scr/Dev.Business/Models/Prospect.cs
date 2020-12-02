using Dev.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Models
{
    public class Prospect : Entity
    {
        public string Name { get; private set; }
        public string IdPsp { get; private set; }
        public string ProActive { get; private set; }
        public string Competition { get; private set; }
        public string NameCompetitors { get; private set; }
        public string International { get; private set; }
        public string Status { get; private set; }
        public string AutomaticPhase { get; private set; }
        public string AutomaticStatus { get; private set; }
        public string Interlocutor { get; private set; }
        public string Decision { get; private set; }
        public string ReasonText { get; private set; }
        public DateTime Opening { get; private set; }
        public DateTime? FirstBriefing { get; private set; }
        public DateTime? FirstProposal { get; private set; }
        public DateTime? ExpectedSale { get; private set; }
        public DateTime? DeliveryJob { get; private set; }
        public DateTime? FirstSale { get; private set; }
        public double? ValueEstimated { get; private set; }
        public double? ValueProposal { get; private set; }
        public double? ValueApproved { get; private set; }
        public double? ValueSold { get; private set; }
        public TypeProspect Type { get; private set; }
        public PhaseProspect PhaseProspect { get; private set; }
        public TemperatureProspect? Temperature { get; private set; }
        public ReasonProspect? Reason { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public Guid CompanyId { get; private set; }
        public Company Company { get; private set; }

        public IReadOnlyCollection<ProspectEmployee> ProspectEmployees { get; set; }

        public void AddOpening()
        {
            Opening = DateTime.Now;
        }

        public void AddIdPsp(string idPsp)
        {
            IdPsp = idPsp;
        }

        public void AddValueSold()
        {
            ValueSold = 0.0;
        }
    }
}
