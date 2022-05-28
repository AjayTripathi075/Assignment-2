using Assignment_2.Models.Data;
using Assignment_2.Models.Error;
using Assignment_2.Repositories;
using Assignment_2.Repositories.IRepository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Assignment_2
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

            services.AddControllers();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment_2", Version = "v1" });
                c.EnableAnnotations();

            });
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
                
         .ConfigureApiBehaviorOptions(options => {
            options.InvalidModelStateResponseFactory = actionContext => {
        
          return CustomErrorResponse(actionContext);
       };
   });
        }

        //private IActionResult CustomErrorResponse(ActionContext actionContext)
        //{
        //    //BadRequestObjectResult is class found Microsoft.AspNetCore.Mvc and is inherited from ObjectResult.    

        //    return new BadRequestObjectResult(actionContext.ModelState
        //     .Where(modelError => modelError.Value.Errors.Count > 0)
        //     .Select(modelError => new Error
        //     {
        //         Source = modelError.Key,
        //         Description = modelError.Value.Errors.FirstOrDefault().ErrorMessage
        //     }).ToList());

        //}
        private IActionResult CustomErrorResponse(ActionContext actionContext)
        {
            //BadRequestObjectResult is class found Microsoft.AspNetCore.Mvc and is inherited from ObjectResult.    
            //Rest code is linq.    
            return new BadRequestObjectResult(actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .Select(modelError => new CorRelation
             {
                 CorRelationId = Guid.NewGuid(),
                 Errors = new List<Error>()
                 {
                     new Error{Source = modelError.Key,
                     Description = modelError.Value.Errors.FirstOrDefault().ErrorMessage }
                 }
             }).ToList());

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment_2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
