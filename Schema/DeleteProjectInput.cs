using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeleteProjectInput : InputObjectGraphType {
        public DeleteProjectInput() {
            Field<NonNullGraphType<StringGraphType>>("id");
        }
    }
}