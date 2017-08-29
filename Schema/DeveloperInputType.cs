using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeveloperInputType : InputObjectGraphType {
        public DeveloperInputType() {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<RoleType>>("role");
        }
    }
}