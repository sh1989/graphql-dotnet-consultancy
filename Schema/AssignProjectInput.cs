using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignProjectInput : InputObjectGraphType {
        public AssignProjectInput() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<StringGraphType>>("project");
        }
    }
}