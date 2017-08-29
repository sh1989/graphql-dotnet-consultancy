using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLConsultancy.Model;

namespace GraphQLConsultancy.Data {
    public class DataRepository : IDataRepository {
        private List<Developer> developers;
        private List<Project> projects;
        private List<Skill> skills;
        private Dictionary<String, String> assignments;
        private Dictionary<String, List<Competency>> competencies;

        private int nextDevId, nextProjectId, nextSkillId;

        public DataRepository() {
            // Developers
            var devSam = new Developer { Id = "1", Name = "Sam", Role = Role.SENIOR };
            var devGary = new Developer { Id = "2", Name = "Gary", Role = Role.LEAD };
            var devChris = new Developer { Id = "3", Name = "Chris", Role = Role.LEAD };
            var devNic = new Developer { Id = "4", Name = "Nic", Role = Role.LEAD };
            var devJess = new Developer { Id = "5", Name = "Jessica", Role = Role.JUNIOR };
            var devStu = new Developer { Id  = "6", Name = "Stu", Role = Role.GRAD };
            var devAndrew = new Developer { Id = "7", Name = "Andrew", Role = Role.JUNIOR };
            var devMarcus = new Developer { Id = "8", Name = "Marcus", Role = Role.GRAD };
            var devBen = new Developer { Id = "9", Name = "Ben", Role = Role.GRAD };
            var devRachel = new Developer { Id = "10", Name = "Rachel", Role = Role.JUNIOR };
            var devKlaus = new Developer { Id = "11", Name = "Klaus", Role = Role.JUNIOR };
            var devRoss = new Developer { Id = "12", Name = "Ross", Role = Role.SENIOR };
            developers = new List<Developer>() {
                devSam, devGary, devChris, devNic, devJess, devStu,
                devAndrew, devMarcus, devBen, devRachel, devKlaus, devRoss
            };

            // Projects
            var proFacelift = new Project { Id = "1", Name = "Facelift", Description = "Redesign of the UI" };
            var proTrader = new Project { Id = "2", Name = "Trader 2G", Description = "The second generation of the trading platform" };
            var proMarket = new Project { Id = "3", Name = "Market Data", Description = "Implementation of the market data API" };
            var proGeord = new Project { Id = "4", Name = "Geordie Pound", Description = "A new crypto-currency for Newcastle local businesses" };
            var proComp = new Project { Id = "5", Name = "Company Website", Description = "Re-launch the company website" };
            var proBreak = new Project { Id = "6", Name = "Breakfast Bot", Description = "A SlackBot to order some bacon sandwiches" };
            projects = new List<Project>() {
                proFacelift, proTrader, proMarket, proGeord, proComp, proBreak
            };

            // Skills
            var skillJs = new Skill { Id = "1", Name = "JavaScript" };
            var skillCs = new Skill { Id = "2", Name = "C#" };
            var skillJv = new Skill { Id = "3", Name = "Java" };
            var skillCp = new Skill { Id = "4", Name = "C++" };
            var skillAi = new Skill { Id = "5", Name = "AI" };
            var skillDk = new Skill { Id = "6", Name = "Docker" };
            var skillMs = new Skill { Id = "7", Name = "Microservices" };
            var skillDb = new Skill { Id = "8", Name = "Databases" };
            var skillAn = new Skill { Id = "9", Name = "Android" };
            var skillIo = new Skill { Id = "10", Name = "iOS" };
            skills = new List<Skill>() {
                skillJs, skillCs, skillJv, skillCp, skillAi,
                skillDk, skillMs, skillDb, skillAn, skillIo
            };

            assignments = new Dictionary<String, String>() {
                { "1", "1" },
                { "2", "2" },
                { "3", "3" },
                { "4", "3" },
                { "5", "5" },
                { "7", "4" },
                { "10", "5" },
                { "11", "6" },
                { "12", "6" }
            };

            competencies = new Dictionary<String, List<Competency>>() {
                { "1", new List<Competency>() { new Competency("1", 8), new Competency("2", 7), new Competency("8", 5), new Competency("9", 6) } },
                { "2", new List<Competency>() { new Competency("3", 6), new Competency("4", 8),new Competency("8", 6) } },
                { "3", new List<Competency>() { new Competency("3", 7), new Competency("1", 6), new Competency("7", 7), new Competency("10", 5) } },
                { "4", new List<Competency>() { new Competency("1", 6), new Competency("2", 6), new Competency("8", 7) } },
                { "5", new List<Competency>() { new Competency("2", 9), new Competency("6", 7), new Competency("8", 8) } },
                { "6", new List<Competency>() { new Competency("1", 7), new Competency("6", 4) } },
                { "7", new List<Competency>() { new Competency("1", 5), new Competency("2", 7), new Competency("3", 7), new Competency("4", 6), new Competency("7", 8) } },
                { "8", new List<Competency>() { new Competency("1", 8), new Competency("5", 3), new Competency("6", 4), new Competency("10", 5) } },
                { "9", new List<Competency>() { new Competency("1", 7), new Competency("3", 6), new Competency("8", 5), new Competency("9", 5) } },
                { "10", new List<Competency>() { new Competency("1", 8), new Competency("2", 6), new Competency("7", 4) } },
                { "11", new List<Competency>() { new Competency("4", 8), new Competency("5", 8), new Competency("8", 7) } },
                { "12", new List<Competency>() { new Competency("1", 7), new Competency("3", 6), new Competency("8", 6), new Competency("10", 5) } }
            };
            
            nextDevId = 13;
            nextProjectId = 7;
            nextSkillId = 11;
        }

        public Developer GetDeveloper(string id) {
            return developers
                .Where(d => d.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Developer> GetDevelopers(bool? assigned) {
            if (assigned.HasValue) {
                return ((bool) assigned.Value) ?
                    developers.Where(x => assignments.ContainsKey(x.Id)) :
                    developers.Where(x => !assignments.ContainsKey(x.Id));
            }
            return developers;
        }

        public Developer AddDeveloper(Developer developer) {
            developer.Id = nextDevId.ToString();
            nextDevId++;
            developers.Add(developer);
            return developer;
        }

        public string DeleteDeveloper(string id) {
            var developer = GetDeveloper(id);
            if (developer != null) {
                developers.Remove(developer);
                if (competencies.ContainsKey(id)) {
                    competencies.Remove(id);
                }
                if (assignments.ContainsKey(id)) {
                    assignments.Remove(id);
                }
                return id;
            }
            return null;
        }

        public Project GetProject(string id) {
            return projects
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Project> GetProjects() {
            return projects;
        }

        public string DeleteProject(string id) {
            var project = GetProject(id);
            if (project != null) {
                projects.Remove(project);
                foreach (var item in assignments.Where(kvp => kvp.Value == id).ToList()) {
                    assignments.Remove(item.Key);
                }
                return id;
            }
            return null;
        }

        public Project AddProject(Project project) {
            project.Id = nextProjectId.ToString();
            nextProjectId++;
            projects.Add(project);
            return project;
        }

        public Skill GetSkill(string id) {
            return skills
                .Where(s => s.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Skill> GetSkills(Order order) {
            return order == Order.DESCENDING ?
                skills.OrderByDescending(x => x.Name) :
                skills.OrderBy(x => x.Name);
        }

        public Skill AddSkill(Skill skill) {
            skill.Id = nextSkillId.ToString();
            nextSkillId++;
            skills.Add(skill);
            return skill;
        }

        public Task<Project> GetProjectAssignment(string developerId) {
            return Task.Run(() => {
                String assignment;
                var assigned = assignments.TryGetValue(developerId, out assignment);
                if (assigned) {
                    return GetProject(assignment);
                }
                return null;
            });
        }

        public Task<IEnumerable<Competency>> GetCompetencies(string developerId, int? top) {
            return Task.Run(() => {
                List<Competency> competencyList;
                var hasCompetencies = competencies.TryGetValue(developerId, out competencyList);
                if (hasCompetencies) {
                    if (top.HasValue) {
                        return competencyList
                            .OrderByDescending(c => c.Rating)
                            .Take((int) top.Value);
                    } else {
                        return competencyList
                            .OrderByDescending(c => c.Rating);
                    }
                }
                return new List<Competency>();
            });
        }

        public Task<Developer> AssignCompetency(CompetencyAssignment operation) {
            return Task.Run(() => {
                var developer = GetDeveloper(operation.Developer);
                if (developer == null) {
                    return null;
                }
                var skill = GetSkill(operation.Skill);
                if (skill == null) {
                    return null;
                }

                List<Competency> skillSet;
                if (competencies.TryGetValue(developer.Id, out skillSet)) {
                    var existingSkill = skillSet.FirstOrDefault(c => c.SkillId == skill.Id);
                    if (existingSkill != null) {
                        existingSkill.Rating = operation.Rating;
                    } else {
                        skillSet.Add(new Competency(skill.Id, operation.Rating));
                    }
                }
                return developer;
            });
        }

        public Task<Developer> AssignProject(ProjectAssignment operation) {
            return Task.Run(() => {
                var developer = GetDeveloper(operation.Developer);
                if (developer == null) {
                    return null;
                }
                var project = GetProject(operation.Project);
                if (project == null) {
                    return null;
                }

                assignments[developer.Id] = project.Id;
                return developer;
            });
        }
        public Task<Developer> AssignRole(RoleAssignment operation) {
            return Task.Run(() => {
                var developer = GetDeveloper(operation.Developer);
                if (developer == null) {
                    return null;
                }

                developer.Role = operation.Role;
                return developer;
            });
        }
    }
}