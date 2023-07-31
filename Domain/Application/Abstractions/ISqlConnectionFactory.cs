using System;
using Microsoft.Data.SqlClient;

namespace Application.Abstractions;

public interface ISqlConnectionFactory
{
	public SqlConnection createConnection();
}

