using Infra.Repository.DbContext;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

public class DbContext : IDbContext
{
    private readonly string _connectionString;
    private readonly IDbConnection _connection;

    public DbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DigitalAccount")
                            ?? throw new ArgumentNullException(nameof(configuration));
        _connection = null!;
    }

    public DbContext(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _connectionString = string.Empty;
    }

    public IDbConnection CreateConnection()
    {
        return _connection ?? new MySqlConnection(_connectionString);
    }
}
