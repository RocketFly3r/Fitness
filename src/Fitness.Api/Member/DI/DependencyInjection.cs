using Fitness.Api.Common.Convention;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Fitness.Api.Member.DI
{
    public static class DependencyInjection
    {
        public static void AddMemberApi(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddControllers(options =>
            {
                options.Conventions.Insert(0, new RouteConvention("api"));

            }).AddApplicationPart(assembly);
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}