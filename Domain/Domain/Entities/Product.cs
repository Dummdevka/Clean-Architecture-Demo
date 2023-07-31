using System;
using Domain.Primitives;

namespace Domain.Entities;

public sealed class Product : Entity
{
	public Product(int id, string title, int price, int availability) : base(id){
		Title = title;
		Price = price;
		Availability = availability;
	}

	public string Title {
		get; set;
	}

	public int Price {
		get; set;
	}

	public int Availability {
		get; set;
	}

	public static implicit operator List<object>(Product v)
	{
		throw new NotImplementedException();
	}
}

