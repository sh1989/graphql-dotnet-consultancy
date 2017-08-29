using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeleteDeveloperInputType : InputObjectGraphType {
        public DeleteDeveloperInputType() {
            Field<NonNullGraphType<StringGraphType>>("id");
        }
    }
}