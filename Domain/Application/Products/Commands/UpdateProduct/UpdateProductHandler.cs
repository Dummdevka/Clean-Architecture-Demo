using System;
using Application.Abstractions;
using Dapper;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, object>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public UpdateProductHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}

	public async Task<object> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		await using SqlConnection connection = _connectionFactory.createConnection();

		var newProduct = new {
			id = request.id,
			title = request.title,
			price = request.price,
			availability = request.availability
		};

		var result = await connection.QueryFirstOrDefaultAsync<Product>("update Product set Title=@title, Price=@price, Availability=@availability where Id=@id", newProduct);
		return result;
	}
}

