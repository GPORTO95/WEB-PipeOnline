using Dev.Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress();

            RuleFor(c => c.CNPJ.Length)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Equal(14).WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(p => p.SegmentId)
                .NotEmpty().WithMessage("O campo Segmento é obrigatório");
        }
    }
}
