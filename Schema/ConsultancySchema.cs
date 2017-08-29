using System;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema
{
    public class ConsultancySchema : GraphQL.Types.Schema
    {
        public ConsultancySchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (ConsultancyQuery) resolveType(typeof (ConsultancyQuery));
            Mutation = (ConsultancyMutation) resolveType(typeof (ConsultancyMutation));
        }
    }
}