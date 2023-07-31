using System;
using Domain.Entities;
using MediatR;

namespace Application.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<List<Product>>;

