using System;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class OrderType : EnumerationGraphType<Order> {
        public OrderType() {
            AddValue("ASCENDING", "Ascending order", (int) Order.ASCENDING);
            AddValue("DESCENDING", "Descending order", (int) Order.DESCENDING);
        }
    }
}