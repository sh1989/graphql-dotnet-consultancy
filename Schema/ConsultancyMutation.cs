using GraphQL.Types;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;

namespace GraphQLConsultancy.Schema {
    public class ConsultancyMutation : ObjectGraphType {
        public ConsultancyMutation(IDataRepository repository) {
            Name = "Mutation";
            Field<DeveloperType>("addDeveloper",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeveloperInput>> { Name = "input" }
                ),
                resolve: context => {
                    var developer = context.GetArgument<Developer>("input");
                    return repository.AddDeveloper(developer);
                }
            );
            Field<StringGraphType>("deleteDeveloper",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeleteDeveloperInput>> { Name = "input" }
                ),
                resolve: context => {
                    var developer = context.GetArgument<Developer>("input");
                    return repository.DeleteDeveloper(developer.Id);
                }
            );
            Field<ProjectType>("addProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProjectInput>> { Name = "input" }
                ),
                resolve: context => {
                    var project = context.GetArgument<Project>("input");
                    return repository.AddProject(project);
                }
            );
            Field<StringGraphType>("deleteProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeleteProjectInput>> { Name = "input" }
                ),
                resolve: context => {
                    var project = context.GetArgument<Project>("input");
                    return repository.DeleteProject(project.Id);
                }
            );
            Field<SkillType>("addSkill",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SkillInput>> { Name = "input" }
                ),
                resolve: context => {
                    var skill = context.GetArgument<Skill>("input");
                    return repository.AddSkill(skill);
                }
            );
            Field<DeveloperType>("assignCompetency",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignCompetencyInput>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<CompetencyAssignment>("input");
                    return repository.AssignCompetency(operation);
                });
            Field<DeveloperType>("assignProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignProjectInput>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<ProjectAssignment>("input");
                    return repository.AssignProject(operation);
                });
            Field<DeveloperType>("assignRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignRoleInput>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<RoleAssignment>("input");
                    return repository.AssignRole(operation);
                });
        }
    }
}