using System;
using Domain.Entities;
using MediatR;

namespace Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(int id) : IRequest<Product>;

