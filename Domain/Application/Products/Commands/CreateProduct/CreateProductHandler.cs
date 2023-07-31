using System;
using Application.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Application.Products.Commands.CreateProduct
{
	public class CreateProductHandler : IRequestHandler<CreateProductCommand, object>
	{
		private readonly ISqlConnectionFactory _connectionFactory;

		public CreateProductHandler(ISqlConnectionFactory connectionFactory) {
			_connectionFactory = connectionFactory;
		}

		public async Task<object> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			await using SqlConnection connection = _connectionFactory.createConnection();

			object newProduct = new {
				title = request.title,
				price = request.price,
				availability = request.availability
			};

			object result = (Product)await connection.QueryFirstOrDefaultAsync("insert into Products (Title, Price, Availability) output Inserted.* values (@title, @price, @availability)", newProduct);

			return result;
		}
	}
}

