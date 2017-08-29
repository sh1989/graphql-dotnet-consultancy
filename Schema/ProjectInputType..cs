using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class ProjectInputType : InputObjectGraphType {
        public ProjectInputType() {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
        }
    }
}