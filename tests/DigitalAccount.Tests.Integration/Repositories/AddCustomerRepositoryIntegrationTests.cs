using Dapper;
using System;
using System.Data.SqlClient; // Usar apenas System.Data.SqlClient
using Xunit;

public class AddCustomerRepositoryIntegrationTests : IDisposable
{
    private SqlConnection _connection;
    private string _databaseName;

    public AddCustomerRepositoryIntegrationTests()
    {
        // Gerar um nome de banco de dados único para o teste
        _databaseName = "Test_" + Guid.NewGuid().ToString("N");

        // Conectar ao banco de dados master para criar o banco de dados de teste
        var connectionString = "Server=172.28.222.159,1433;Database=master;User Id=sa;Password=Pass@word;";
        _connection = new SqlConnection(connectionString);
        _connection.Open();

        // Criar um banco de dados temporário
        var createDatabaseQuery = $"CREATE DATABASE {_databaseName}";
        _connection.Execute(createDatabaseQuery);

        // Fechar a conexão inicial
        _connection.Close();

        // Abrir uma nova conexão para o banco de dados temporário
        _connection = new SqlConnection($"Server=172.28.222.159,1433;Database={_databaseName};User Id=sa;Password=Pass@word;");
        _connection.Open();

        // Criar a tabela 'customer' no banco de dados temporário
        var createTableQuery = @"
        CREATE TABLE customer (
            id INT PRIMARY KEY IDENTITY(1,1),
            name NVARCHAR(100) NOT NULL,
            email NVARCHAR(100) NOT NULL,
            document NVARCHAR(20) NOT NULL
        )";
        _connection.Execute(createTableQuery);
    }

    [Fact]
    public void AddCustomer_ShouldInsertCustomerIntoDatabase()
    {
        // Lógica para o teste de adicionar um cliente à tabela 'customer'
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

        // Verificar se o cliente foi inserido
        var checkQuery = "SELECT COUNT(1) FROM customer WHERE email = @Email";
        var customerCount = _connection.ExecuteScalar<int>(checkQuery, new { Email = customer.Email });

        Assert.Equal(1, customerCount);
    }

    // Método para excluir o banco de dados após o teste
    public void Dispose()
    {
        _connection.Close();

        // Remover o banco de dados temporário
        using (var masterConnection = new SqlConnection("Server=172.28.222.159,1433;Database=master;User Id=sa;Password=Pass@word;"))
        {
            masterConnection.Open();

            // Encerrar conexões ativas com o banco de dados
            var killConnectionsQuery = $@"
            DECLARE @sql NVARCHAR(MAX) = '';
            SELECT @sql = @sql + 'KILL ' + CAST(spid AS NVARCHAR(10)) + ';'
            FROM sys.sysprocesses
            WHERE dbid = DB_ID('{_databaseName}');
            EXEC sp_executesql @sql;";
            masterConnection.Execute(killConnectionsQuery);

            // Agora excluir o banco de dados
            var dropDatabaseQuery = $"DROP DATABASE {_databaseName}";
            masterConnection.Execute(dropDatabaseQuery);
        }
    }
}
