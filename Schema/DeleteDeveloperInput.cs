using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class DeleteDeveloperInput : InputObjectGraphType {
        public DeleteDeveloperInput() {
            Field<NonNullGraphType<StringGraphType>>("id");
        }
    }
}