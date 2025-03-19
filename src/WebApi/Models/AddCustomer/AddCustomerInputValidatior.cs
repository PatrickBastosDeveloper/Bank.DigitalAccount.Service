using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Models.AddCustomer
{
    [ExcludeFromCodeCoverage]
    public class AddCustomerInputValidatior : AbstractValidator<AddCustomerInput>
    {
        public AddCustomerInputValidatior()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Documents).IsValidCPF().WithMessage("'Document' é um CPF inválido.");
        }
    }
}
