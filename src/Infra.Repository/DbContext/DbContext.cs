using Infra.Repository.DbContext;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient; // Usar apenas System.Data.SqlClient
using System.Data;

public class DbContext : IDbContext
{
    private readonly string _connectionString;
    private readonly IDbConnection _connection;

    // Construtor para produção (SQL Server)
    public DbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DigitalAccount") ?? throw new ArgumentNullException(nameof(configuration));
        _connection = null!;
    }

    // Construtor para testes (injeção de conexão SQL Server)
    public DbContext(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _connectionString = string.Empty; // Inicializa com uma string vazia
    }

    public IDbConnection CreateConnection()
    {
        // Retorna a conexão injetada, não tentando abrir uma nova conexão
        return _connection ?? new SqlConnection(_connectionString);
    }
}
