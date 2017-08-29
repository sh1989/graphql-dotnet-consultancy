using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GraphQL.Types;
using GraphQLConsultancy.Data;
using GraphQLConsultancy.Middleware;
using GraphQLConsultancy.Schema;

namespace GraphQLConsultancy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IDataRepository, DataRepository>();

            services.AddSingleton<ConsultancyQuery>();
            services.AddSingleton<CompetencyType>();
            services.AddSingleton<DeveloperType>();
            services.AddSingleton<ProjectType>();
            services.AddSingleton<RoleType>();
            services.AddSingleton<SkillType>();
            services.AddSingleton<OrderType>();
            services.AddSingleton<ConsultancyMutation>();
            services.AddSingleton<DeveloperInputType>();
            services.AddSingleton<DeleteDeveloperInputType>();
            services.AddSingleton<ProjectInputType>();
            services.AddSingleton<DeleteProjectInputType>();
            services.AddSingleton<SkillInputType>();
            services.AddSingleton<AssignCompetencyInputType>();
            services.AddSingleton<AssignProjectInputType>();
            services.AddSingleton<AssignRoleInputType>();
            services.AddSingleton<ISchema>(s => new ConsultancySchema(type => (GraphType) s.GetService(type)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();
            app.UseMvc();
        }
    }
}
