using grading_tab.application.Application.Common.Interfaces;
using Microsoft.Data.SqlClient;

namespace grading_tab.application.Application.Common;

public class DbConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(connectionString);
    }
}