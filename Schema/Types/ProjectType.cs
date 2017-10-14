using System;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class ProjectType : ObjectGraphType<Project> {
        public ProjectType() {
            Name = "Project";
            Interface<NamedInterface>();
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}