using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
            var sent = false;
            if (context.Request.Path.StartsWithSegments("/graphql")) {
                using (var str = new StreamReader(context.Request.Body)) {
                    var query = await str.ReadToEndAsync();
                    if (!String.IsNullOrWhiteSpace(query)) {
                        var result = await new DocumentExecuter()
                            .ExecuteAsync(options => {
                                options.Schema = schema;
                                options.Query = query;
                            }).ConfigureAwait(false);
                        CheckForErrors(result);
                        await WriteResult(context, result);
                        sent = true;
                    }
                }
            }
            if (!sent) {
                await next(context);
            }
        }

        private async Task WriteResult(HttpContext context, ExecutionResult result) {
            var json = new DocumentWriter(indent: true)
                .Write(result);
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }

        private void CheckForErrors(ExecutionResult result) {
            if (result.Errors?.Count > 0) {
                var errors = new List<Exception>();
                foreach(var error in result.Errors) {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null){
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
    }
}