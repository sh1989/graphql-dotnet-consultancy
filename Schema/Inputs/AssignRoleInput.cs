using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignRoleInput : InputObjectGraphType {
        public AssignRoleInput() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<RoleType>>("role");
        }
    }
}