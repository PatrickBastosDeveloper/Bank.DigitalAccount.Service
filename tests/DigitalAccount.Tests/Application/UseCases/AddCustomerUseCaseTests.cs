using Application.UseCases.AddCustomer;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Entities;
using Moq;

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
            var customer = new Customer("John Doe", "john@example.com", "12345678900");

            // Act
            useCase.AddCustomer(customer);

            // Assert
            mockRepository.Verify(repo => repo.AddCustomer(customer), Times.Once);
        }
    }
}
