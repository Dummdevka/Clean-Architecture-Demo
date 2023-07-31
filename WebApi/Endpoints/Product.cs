using System;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProductById;
using Application.Products.Queries.GetProducts;
using Carter;
using MediatR;

namespace WebApi.Endpoints;

public class Product : ICarterModule
{
	public Product()
	{
	}

	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("api/products", async (ISender sender) =>
		{
			return await sender.Send(new GetProductsQuery());
		});

		app.MapGet("api/products/{id:int}", async (int id, ISender sender) =>
		{
			return await sender.Send(new GetProductByIdQuery(id));
		});

		app.MapPost("api/products", async (CreateProductCommand command, ISender sender) =>
		{
			return await sender.Send(command);
		});

		app.MapDelete("api/products/{id:int}", async (int id, ISender sender) =>
		{
			await sender.Send(new DeleteProductCommand(id));
			return new {
				success = true
			};
		});
		
		app.MapPut("api/products/{id:int}", async (UpdateProductCommand command, ISender sender) =>
		{
			return await sender.Send(command);
		});
	}

	
}

