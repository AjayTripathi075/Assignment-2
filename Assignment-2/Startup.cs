using Assignment_2.Models.Data;
using Assignment_2.Models.Error;
using Assignment_2.Repositories;
using Assignment_2.Repositories.IRepository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using Assignment_2.Validation.DateConverter;
using System.Reflection;
using System.IO;

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

            services.AddControllers().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.Converters.Add(new DateConverter());
            });
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment_2", Version = "v1" });
                c.EnableAnnotations();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


            });
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest)
           .ConfigureApiBehaviorOptions(options => {
            options.InvalidModelStateResponseFactory = actionContext => {
           return CustomErrorResponse(actionContext);
       };
       
    });

}
        private IActionResult CustomErrorResponse(ActionContext actionContext)
        {
            var errorresult = string.Join('\n', actionContext.ModelState.Values.Where(modelError => modelError.Errors.Count > 0)

            .SelectMany(modelError => modelError.Errors)
            .Select(modelError => modelError.ErrorMessage));
            var errs = actionContext.ModelState.Values.SelectMany(v => v.Errors).ToList();
            var error = actionContext.ModelState.Select(modelError => new Error
            {
                Source = modelError.Key,
                Description=modelError.Value.Errors.FirstOrDefault().ErrorMessage
            });
            return new BadRequestObjectResult(new
            {
                correlationId = Guid.NewGuid(),
                Errors = error
            }); ;
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
