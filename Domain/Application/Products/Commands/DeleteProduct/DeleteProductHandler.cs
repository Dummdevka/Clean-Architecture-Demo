using System;
using Application.Abstractions;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
	private readonly ISqlConnectionFactory _connectionFactory;

	public DeleteProductHandler(ISqlConnectionFactory connectionFactory) {
		_connectionFactory = connectionFactory;
	}

	public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		await using SqlConnection connection = _connectionFactory.createConnection();
		await connection.QueryAsync("delete from Product where id=@id", new { id= request.id });
	}
}

