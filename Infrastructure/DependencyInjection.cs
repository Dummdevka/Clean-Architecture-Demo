using System;
using Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;


public static class DependencyInjection
{
	public static IServiceCollection AddInfrastrucutre(this IServiceCollection services) {
		services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();
		return services;
	}
}

