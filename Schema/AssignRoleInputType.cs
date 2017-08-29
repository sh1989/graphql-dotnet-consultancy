using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignRoleInputType : InputObjectGraphType {
        public AssignRoleInputType() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<RoleType>>("role");
        }
    }
}