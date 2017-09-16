using System;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class SkillType : ObjectGraphType<Skill> {
        public SkillType() {
            Name = "Skill";
            Interface<NamedInterface>();
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}