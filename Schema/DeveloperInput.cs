using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeveloperInput : InputObjectGraphType {
        public DeveloperInput() {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<RoleType>>("role");
        }
    }
}