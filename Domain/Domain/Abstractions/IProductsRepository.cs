using System;
namespace Domain.Abstractions;

public interface IProductsRepository
{
	void Insert(IProductsRepository product);
}

