using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Models.AddCustomer
{
    [ExcludeFromCodeCoverage]
    public class AddCustomerInputValidatior : AbstractValidator<AddCustomerInput>
    {
        public AddCustomerInputValidatior()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("CPF cannot be empty")
                .Length(11).WithMessage("CPF must have exactly 11 digits")
                .Matches(@"^\d{11}$").WithMessage("CPF must contain only digits");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Address cannot be empty")
                .Length(5, 100).WithMessage("Address must be between 5 and 100 characters");

            RuleFor(c => c.Telephone)
                .NotEmpty().WithMessage("Telephone cannot be empty")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid telephone format");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email format");

            //RuleFor(c => c.Documents)
            //    .IsValidCPF().WithMessage("'Document' é um CPF inválido.");
        }
    }
}
