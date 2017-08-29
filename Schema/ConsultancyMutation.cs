using GraphQL.Types;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;

namespace GraphQLConsultancy.Schema {
    public class ConsultancyMutation : ObjectGraphType {

        /*
            y addDeveloper : Developer (name, role)
            y deleteDeveloper : String (id)
            y addProject : Project (name, description)
            y deleteProject : String (id)
            y addSkill : Skill (name)
            assignCompetency : Developer (developer, skill, rating)
            assignProject : Developer (developer, project)
            assignRole : Developer (developer, role)
         */

        public ConsultancyMutation(IDataRepository repository) {
            Field<DeveloperType>("addDeveloper",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeveloperInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var developer = context.GetArgument<Developer>("input");
                    return repository.AddDeveloper(developer);
                }
            );
            Field<StringGraphType>("deleteDeveloper",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeleteDeveloperInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var developer = context.GetArgument<Developer>("input");
                    return repository.DeleteDeveloper(developer.Id);
                }
            );
            Field<ProjectType>("addProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProjectInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var project = context.GetArgument<Project>("input");
                    return repository.AddProject(project);
                }
            );
            Field<StringGraphType>("deleteProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DeleteProjectInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var project = context.GetArgument<Project>("input");
                    return repository.DeleteProject(project.Id);
                }
            );
            Field<SkillType>("addSkill",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SkillInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var skill = context.GetArgument<Skill>("input");
                    return repository.AddSkill(skill);
                }
            );
            Field<DeveloperType>("assignCompetency",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignCompetencyInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<CompetencyAssignment>("input");
                    return repository.AssignCompetency(operation);
                });
            Field<DeveloperType>("assignProject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignProjectInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<ProjectAssignment>("input");
                    return repository.AssignProject(operation);
                });
            Field<DeveloperType>("assignRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AssignRoleInputType>> { Name = "input" }
                ),
                resolve: context => {
                    var operation = context.GetArgument<RoleAssignment>("input");
                    return repository.AssignRole(operation);
                });
        }
    }
}