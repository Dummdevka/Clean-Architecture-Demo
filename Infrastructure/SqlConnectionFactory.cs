using System;
using Application.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class SqlConnectionFactory : ISqlConnectionFactory
{
	private IConfiguration _configuration;

	public SqlConnectionFactory(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public SqlConnection createConnection()
	{
		return new SqlConnection(_configuration.GetConnectionString("Database"));
	}
}

