using System;
using Application.Abstractions;
using Domain.Entities;
using MediatR;
using Dapper;
using Microsoft.Data.SqlClient;
using Domain.Exceptions;

namespace Application.Products.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public GetProductByIdHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}

	public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		await using SqlConnection connection = _connectionFactory.createConnection();
		Product product = await connection.QueryFirstOrDefaultAsync<Product>("SELECT Id, Title, Price, Availability from Products where id=@id", new {
			id = request.id
		});

		if (product is null) {
			throw new ProductNotFoundException();
		}

		return product;
	}
}

