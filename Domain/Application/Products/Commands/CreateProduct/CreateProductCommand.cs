using System;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string title, int price, int availability) : IRequest<object>;

