using System;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class ConsultancyQuery : ObjectGraphType {
        public ConsultancyQuery(IDataRepository data) {
            Field<DeveloperType>("developer",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }
                ),
                resolve: context => {
                    var id = context.GetArgument<String>("id");
                    return data.GetDeveloper(id);
                }
            );

            Field<ListGraphType<DeveloperType>>("developers",
                arguments: new QueryArguments(
                    new QueryArgument<BooleanGraphType>() { Name = "assigned" }
                ),
                resolve: context => {
                    var assigned = context.GetArgument<bool?>("assigned");
                    return data.GetDevelopers(assigned);
                }
            );

            Field<ProjectType>("project",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }
                ),
                resolve: context => {
                    var id = context.GetArgument<String>("id");
                    return data.GetProject(id);
                }
            );

            Field<ListGraphType<ProjectType>>("projects",
                resolve: context => {
                    return data.GetProjects();
                }
            );

            Field<SkillType>("skill",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }
                ),
                resolve: context => {
                    var id = context.GetArgument<String>("id");
                    return data.GetSkill(id);
                }
            );

            Field<ListGraphType<SkillType>>("skills",
                arguments: new QueryArguments(
                    new QueryArgument<OrderType>() { Name = "order", DefaultValue = Order.ASCENDING }
                ),
                resolve: context => {
                    var order = context.GetArgument<Order>("order");
                    return data.GetSkills(order);
                }
            );
        }
    }
}