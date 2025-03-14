using FluentValidation;

namespace WebApi.Models.AddCustomer
{
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
