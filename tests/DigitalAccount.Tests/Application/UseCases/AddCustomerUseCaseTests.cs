using Application.UseCases.AddCustomer;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Entities;
using Moq;
using Xunit;

namespace Application.Tests.UseCases.AddCustomer
{
    public class AddCustomerUseCaseTests
    {
        [Fact]
        public void AddCustomer_ShouldCallRepositoryOnce()
        {
            // Arrange
            var mockRepository = new Mock<IAddCustomerRepository>();
            var useCase = new AddCustomerUseCase(mockRepository.Object);
            var customer = new Customer(
                name: "John Doe",
                cpf: "12345678900",
                address: "123 Main St",
                telephone: "+5511999999999",
                email: "john@example.com"
            );

            // Act
            useCase.AddCustomer(customer);

            // Assert
            mockRepository.Verify(repo => repo.AddCustomer(customer), Times.Once);
        }
    }
}

