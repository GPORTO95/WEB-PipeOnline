using Dev.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Dev.App.ViewModels
{
    public class ProspectViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        [DisplayName("Nome do projeto")]
        public string Name { get; set; }

        [DisplayName("PSP")]
        public string IdPsp { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("É uma prospecção pró-ativa")]
        public string ProActive { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("É concorrência")]
        public string Competition { get; set; }

        [MaxLength(200, ErrorMessage = "O campo pode ter no máximo {0} caracteres")]
        [DisplayName("Digite os concorrentes")]
        public string NameCompetitors { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("PSP internacional")]
        public string International { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Fases e status são atualizados automaticamente")]
        public string AutomaticPhase { get; set; }
        
        [DisplayName("Status")]
        public string AutomaticStatus { get; set; }

        [MaxLength(200, ErrorMessage = "O campo pode ter no máximo {0} caracteres")]
        [DisplayName("Interlocutor(es) do cliente")]
        public string Interlocutor { get; set; }
        
        [MaxLength(200, ErrorMessage = "O campo pode ter no máximo {0} caracteres")]
        [DisplayName("Decisor(es) do cliente")]
        public string Decision { get; set; }

        [DisplayName("Pra quem perdemos/Motivo cancelamento")]
        public string ReasonText { get; set; }

        [DisplayName("Data de abertura do PSP")]
        public DateTime Opening { get; set; }

        [DisplayName("Data do 1º briefing")]
        public DateTime? FirstBriefing { get; set; }

        [DisplayName("Data da 1º proposta")]
        public DateTime? FirstProposal { get; set; }

        [DisplayName("Data esperada da venda")]
        public DateTime? ExpectedSale { get; set; }

        [DisplayName("Data da entrega do Job")]
        public DateTime? DeliveryJob { get; set; }

        [DisplayName("Data da primeira venda")]
        public DateTime? FirstSale { get; set; }

        [DisplayName("Valor estimado do projeto")]
        [Coin]
        public double? ValueEstimated { get; set; }
        
        [DisplayName("Valor da proposta")]
        [Coin]
        public double? ValueProposal { get; set; }

        [DisplayName("Proposta aprovada pelo cliente")]
        [Coin]
        public double? ValueApproved { get; set; }
        
        [DisplayName("Valor vendido")]
        [Coin]
        public double? ValueSold { get; set; }

        [DisplayName("Tipo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Type { get; set; }

        [DisplayName("Fases")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int PhaseProspect { get; set; }

        [DisplayName("Temperatura")]
        public int? Temperature { get; set; }

        [DisplayName("Razão")]
        public int? Reason { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Categoria")]
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Dono do projeto")]
        public Guid EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public IEnumerable<EmployeeViewModel> Employees { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Cliente")]
        public Guid CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        [DisplayName("Time TV1")]
        public string ProspectEmployeeId { get; set; }

        public ICollection<ProspectEmployeeViewModel> ProspectEmployees { get; private set; } = new List<ProspectEmployeeViewModel>();

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DisplayName("Empresa")]
        public Guid CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }

        public string ConvertDoubleToReal(double? value)
        {
            return value.HasValue ? string.Format("{0:N}", value) : "0,00";
        }

        public void AddProspectEmployee(ProspectEmployeeViewModel obj)
        {
            ProspectEmployees.Add(obj);
        }

    }
}
