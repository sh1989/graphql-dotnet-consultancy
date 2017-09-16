using System;

namespace GraphQLConsultancy.Model {
    public abstract class Named {
        public String Id { get; set; }
        public String Name { get; set; }
    }
}