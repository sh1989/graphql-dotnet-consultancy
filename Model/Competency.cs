using System;

namespace GraphQLConsultancy.Model {
    public class Competency {
        public Competency(string skillid, int rating) {
            this.SkillId = skillid;
            this.Rating = rating;
        }
        public String SkillId { get; set; }
        public int Rating { get; set; }
    }
}