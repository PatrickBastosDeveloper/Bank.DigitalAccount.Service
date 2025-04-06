using Dapper;
using Domain.Contracts.Repositories.AddCustomer;
using Domain.Entities;
using Infra.Repository.DbContext;

namespace Infra.Repository.Repositories.AddCustomer
{
    public class AddCustomerRepository : IAddCustomerRepository
    {
        private readonly IDbContext _dbContext;

        public AddCustomerRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCustomer(Customer customer)
        {
            var query = @"
                INSERT INTO customer (external_id, name, cpf, address, telephone, email) 
                VALUES (@ExternalId, @Name, @CPF, @Address, @Telephone, @Email)";

            var parameters = new DynamicParameters();
            parameters.Add("ExternalId", customer.ExternalId, System.Data.DbType.String);
            parameters.Add("Name", customer.Name, System.Data.DbType.String);
            parameters.Add("CPF", customer.CPF, System.Data.DbType.String);
            parameters.Add("Address", customer.Address, System.Data.DbType.String);
            parameters.Add("Telephone", customer.Telephone, System.Data.DbType.String);
            parameters.Add("Email", customer.Email, System.Data.DbType.String);

            using var connection = _dbContext.CreateConnection();
            connection.Execute(query, parameters);
        }
    }
}
