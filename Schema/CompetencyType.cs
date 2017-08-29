using System;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class CompetencyType : ObjectGraphType<Competency> {
        public CompetencyType(IDataRepository repository) {
            Field<StringGraphType>("name",
                resolve: context => repository
                    .GetSkill(context.Source.SkillId)
                    .Name
            );
            Field(x => x.Rating);
        }
    }
}