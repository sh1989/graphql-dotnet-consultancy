using System;
using GraphQLConsultancy.Model;
using GraphQL.Types;

namespace GraphQLConsultancy.Schema {
    public class RoleType : EnumerationGraphType<Role> {
        public RoleType() {
            Name = "Role";
            AddValue("GRAD", "Graduate Developer", (int) Role.GRAD);
            AddValue("JUNIOR", "Junior Developer", (int) Role.JUNIOR);
            AddValue("SENIOR", "Senior Developer", (int) Role.SENIOR);
            AddValue("LEAD", "Lead Developer", (int) Role.LEAD);
        }
    }
}