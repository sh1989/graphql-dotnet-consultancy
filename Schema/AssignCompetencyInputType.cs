using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignCompetencyInputType : InputObjectGraphType {
        public AssignCompetencyInputType() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<StringGraphType>>("skill");
            Field<NonNullGraphType<IntGraphType>>("rating");
        }
    }
}