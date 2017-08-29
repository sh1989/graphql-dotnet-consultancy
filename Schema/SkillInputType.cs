using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class SkillInputType : InputObjectGraphType {
        public SkillInputType() {
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}