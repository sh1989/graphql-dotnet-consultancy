using System;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class SkillType : ObjectGraphType<Skill> {
        public SkillType() {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}