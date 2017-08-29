using System;
using System.Linq;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;
using GraphQLConsultancy.Middleware;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeveloperType : ObjectGraphType<Developer> {
        public DeveloperType(IDataRepository repository) {
            Field(x => x.Id);
            Field(x => x.Name);
            Field<RoleType>("role");
            Field<ProjectType>("project",
                resolve: context => {
                    return repository.GetProjectAssignment(context.Source.Id);
                }
            );
            Field<ListGraphType<CompetencyType>>("competencies",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "top" }
                ),
                resolve: context => {
                    var top = context.GetArgument<int?>("top");
                    return repository.GetCompetencies(context.Source.Id, top);
                }
            );
        }
    }
}