namespace TechChallenge.Infrastructure;
public class SqlConnectionString
{
    public SqlConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; private set; }
}
