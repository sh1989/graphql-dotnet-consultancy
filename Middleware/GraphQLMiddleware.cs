using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Schema;

namespace GraphQLConsultancy.Middleware {
    public class GraphQLMiddleware {
        private readonly RequestDelegate next;
        private readonly ISchema schema;
        public GraphQLMiddleware(RequestDelegate next, ISchema schema) {
            this.next = next;
            this.schema = schema;
        }

        public async Task Invoke(HttpContext context) {
            if (!IsGraphQLRequest(context)) {
                await next(context).ConfigureAwait(false);
                return;
            }
            await ExecuteAsync(context);
        }

        private bool IsGraphQLRequest(HttpContext context) {
            return context.Request.Path.StartsWithSegments("/graphql") &&
                string.Equals(context.Request.Method, "POST", StringComparison.OrdinalIgnoreCase);
        }

        private async Task ExecuteAsync(HttpContext context) {
            string body;
            using (var streamReader = new StreamReader(context.Request.Body)) {
                body = await streamReader
                    .ReadToEndAsync()
                    .ConfigureAwait(true);
            }

            var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

            var result = await new DocumentExecuter()
                .ExecuteAsync(options => {
                    options.Schema = schema;
                    options.Query = request.Query;
                    options.OperationName = request.OperationName;
                    options.Inputs = request.Variables.ToInputs();
                });
            
            await WriteResponseAsync(context, result);
        }

        private async Task WriteResponseAsync(HttpContext context, ExecutionResult result) {
            var json = new DocumentWriter()
                .Write(result);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.Errors?.Any() == true ?
                (int) HttpStatusCode.BadRequest :
                (int) HttpStatusCode.OK;
                await context.Response.WriteAsync(json);
        }
    }
}