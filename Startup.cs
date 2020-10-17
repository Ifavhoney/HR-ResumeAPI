using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using ResumeAPI.Models;
using ResumeAPI.Repository;

namespace ResumeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //DB Service
            services.AddDbContext<ResumeContext>(item => item.UseSqlServer
(Configuration.GetConnectionString("ResumeDBConnection")));
            //IResume and ResumeRepository will perform one request (to aid postview)
            services.AddScoped<IResumeRepository, ResumeRepository>();
            services.AddSwaggerGen(
                           c => c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "ResumeAPI", Version = "1.0" }
                           ));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(
              c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResumeAPI")
              );
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
