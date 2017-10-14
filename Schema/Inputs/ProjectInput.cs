using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class ProjectInput : InputObjectGraphType {
        public ProjectInput() {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
        }
    }
}