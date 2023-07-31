using System;
namespace Domain.Primitives;

public abstract class Entity
{
	public int Id {
		get; protected set;
	}

	protected Entity(int id) {
		Id = id;
	}
}

