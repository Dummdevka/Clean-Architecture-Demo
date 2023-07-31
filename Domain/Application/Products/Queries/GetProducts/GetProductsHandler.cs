using System;
using Application.Abstractions;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Queries.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public GetProductsHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}

	public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
	{
		await using SqlConnection connection = _connectionFactory.createConnection();

		List<Product> products = (List<Product>)await connection.QueryAsync<Product>(@"SELECT Id, Title, Price, Availability FROM Products");

		return products;
	}
}

