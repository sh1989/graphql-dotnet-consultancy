using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLConsultancy.Model;

namespace GraphQLConsultancy.Data {
    public interface IDataRepository {
        Developer GetDeveloper(string id);
        IEnumerable<Developer> GetDevelopers(bool? assigned);

        Developer AddDeveloper(Developer developer);

        string DeleteDeveloper(string id);

        Project GetProject(string id);
        IEnumerable<Project> GetProjects();

        string DeleteProject(string id);

        Project AddProject(Project project);

        Skill GetSkill(string id);
        IEnumerable<Skill> GetSkills(Order order);

        Skill AddSkill(Skill skill);

        Task<Project> GetProjectAssignment(string developerId);
        Task<IEnumerable<Competency>> GetCompetencies(string developerId, int? top);

        Task<Developer> AssignCompetency(CompetencyAssignment operation);
        Task<Developer> AssignProject(ProjectAssignment operation);
        Task<Developer> AssignRole(RoleAssignment operation);
    }
}