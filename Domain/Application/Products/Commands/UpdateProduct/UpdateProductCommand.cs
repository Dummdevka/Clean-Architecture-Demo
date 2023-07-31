using System;
using MediatR;

namespace Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(int id, string title, int price, int availability) : IRequest<object>;


