using Microsoft.Data.SqlClient;

namespace grading_tab.application.Application.Common.Interfaces;

public interface IDbConnectionFactory
{
    SqlConnection CreateConnection();
}