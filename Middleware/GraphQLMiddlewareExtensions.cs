using System;
using Microsoft.AspNetCore.Builder;

namespace GraphQLConsultancy.Middleware {
    public static class GraphQLMiddlewareExtensions
    {
        public static IApplicationBuilder UseGraphQL(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GraphQLMiddleware>();
        }
}
}