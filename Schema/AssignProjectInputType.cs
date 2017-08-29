using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignProjectInputType : InputObjectGraphType {
        public AssignProjectInputType() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<StringGraphType>>("project");
        }
    }
}