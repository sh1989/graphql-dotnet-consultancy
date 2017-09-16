using System;
using System.Linq;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;
using GraphQLConsultancy.Middleware;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class NamedInterface : InterfaceGraphType<Developer> {
        public NamedInterface() {
            Name = "Named";
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}