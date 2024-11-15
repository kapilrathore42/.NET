using Core.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace API
{
    public static class DependecyInjection
    {
        public  static IServiceCollection services;
        public static IServiceCollection AddMediatrdependency(this IServiceCollection services)
        {
            var currentAssebly = typeof(DependecyInjection).Assembly;
          //  _ = services.AddMediatR(typeof(currentAssebly).Assembly);
            return services;
        }

    }
}
