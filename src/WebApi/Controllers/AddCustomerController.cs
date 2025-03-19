using Domain.Contracts.UseCases.AddCustomer;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.AddCustomer;
using Domain.Entities;
using FluentValidation;
using WebApi.Models.Error;
using System.Diagnostics.CodeAnalysis;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCase;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;

        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator)
        {
            _addCustomerUseCase = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            var validationResult = _addCustomerInputValidator.Validate(input);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToCustomValidationFailure());

            }

            var customer = new Customer(input.Name, input.Email, input.Documents);

            _addCustomerUseCase.AddCustomer(customer);

            return Created("", input);
        }
    }
}
