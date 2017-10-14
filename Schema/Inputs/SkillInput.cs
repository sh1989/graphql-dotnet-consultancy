using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class SkillInput : InputObjectGraphType {
        public SkillInput() {
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}