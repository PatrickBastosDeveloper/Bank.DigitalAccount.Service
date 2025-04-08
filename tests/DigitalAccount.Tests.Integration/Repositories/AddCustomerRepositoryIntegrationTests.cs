using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Xunit;

public class AddCustomerRepositoryIntegrationTests : IDisposable
{
    private MySqlConnection _connection;
    private string _databaseName;
    private string _baseConnectionString = "Server=localhost;Port=3306;User=user;Password=password;"; // Ajuste para seu ambiente

    public AddCustomerRepositoryIntegrationTests()
    {
        _databaseName = "test_" + Guid.NewGuid().ToString("N");

        // Criar banco de dados temporário
        using (var masterConnection = new MySqlConnection(_baseConnectionString))
        {
            masterConnection.Open();
            masterConnection.Execute($"CREATE DATABASE `{_databaseName}`");
        }

        _connection = new MySqlConnection($"{_baseConnectionString}Database={_databaseName};");
        _connection.Open();

        // Criar tabela no banco de testes
        var createTableQuery = @"
            CREATE TABLE customer (
                id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(100) NOT NULL,
                email VARCHAR(100) NOT NULL,
                document VARCHAR(20) NOT NULL
            )";
        _connection.Execute(createTableQuery);
    }

    [Fact]
    public void AddCustomer_ShouldInsertCustomerIntoDatabase()
    {
        var insertQuery = @"
            INSERT INTO customer (name, email, document) 
            VALUES (@Name, @Email, @Document)";

        var customer = new
        {
            Name = "John Doe",
            Email = "john.doe@example.com",
            Document = "1234567890"
        };

        _connection.Execute(insertQuery, customer);

        var checkQuery = "SELECT COUNT(1) FROM customer WHERE email = @Email";
        var customerCount = _connection.ExecuteScalar<int>(checkQuery, new { Email = customer.Email });

        Assert.Equal(1, customerCount);
    }

    public void Dispose()
    {
        _connection?.Close();

        // Excluir o banco de dados após o teste
        using (var masterConnection = new MySqlConnection(_baseConnectionString))
        {
            masterConnection.Open();
            masterConnection.Execute($"DROP DATABASE IF EXISTS `{_databaseName}`");
        }
    }
}
