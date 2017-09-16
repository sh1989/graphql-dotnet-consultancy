using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class AssignCompetencyInput : InputObjectGraphType {
        public AssignCompetencyInput() {
            Field<NonNullGraphType<StringGraphType>>("developer");
            Field<NonNullGraphType<StringGraphType>>("skill");
            Field<NonNullGraphType<IntGraphType>>("rating");
        }
    }
}