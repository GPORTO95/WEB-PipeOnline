using Dev.Business.Models;
using Dev.Business.Models.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Validations
{
    public class ProspectValidation : AbstractValidator<Prospect>
    {
        public ProspectValidation()
        {

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("O campo Cliente é obrigatório");

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.ProActive)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.International)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Competition)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            
            RuleFor(p => p.EmployeeId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            
            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.PhaseProspect)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            When(p => p.Competition == "1", () => 
            {
                RuleFor(p => p.NameCompetitors)
                    .NotEmpty().WithMessage("O nome dos concorrentes precisa ser fornecido quando concorrencia for Sim");
            });

            When(p => p.PhaseProspect == PhaseProspect.Proposta, () =>
            {
                RuleFor(p => p.Temperature)
                    .NotEmpty().WithMessage("A temperatura da proposta precisa ser forneceida quando a fase for igual a Proposta");

                RuleFor(p => p.ValueProposal)
                    .NotEmpty().WithMessage("O valor da proposta precisa ser preenchida quando a fase for igual a Prosposta")
                    .GreaterThan(0).WithMessage("O valor da proposta precisa ser maior que 0 quando a fase for igual a Proposta");

                RuleFor(p => p.FirstProposal)
                    .NotEmpty().WithMessage("A data da 1º proposta precisa ser preenchida quando a fase for igual a Proposta");
            });

            When(p => p.Status == "WIN" || p.Status == "NOG" || p.Status == "LOS", () =>
            {
                RuleFor(p => p.Reason)
                    .NotEmpty().WithMessage("O campo razão precisa ser preenchido quando o status for nogo/ganhamos ou perdemos");
            });

            When(p => p.Status == "CAN" || p.Status == "LOS", () =>
            {
                RuleFor(p => p.ReasonText)
                    .NotEmpty().WithMessage("O campo motivo precisa ser preenchido quando o status for cancelado ou perdemos");
            });
        }
    }
}
