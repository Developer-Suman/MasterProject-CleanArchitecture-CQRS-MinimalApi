using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            return services;
        }

       public static IEndpointRouteBuilder AddEndPoint(this IEndpointRouteBuilder builder)
        {
            return builder;
        }
    }
}
