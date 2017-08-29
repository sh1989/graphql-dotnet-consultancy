using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeleteProjectInputType : InputObjectGraphType {
        public DeleteProjectInputType() {
            Field<NonNullGraphType<StringGraphType>>("id");
        }
    }
}