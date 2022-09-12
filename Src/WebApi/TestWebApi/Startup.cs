using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestApp.Application;
using TestApp.Application.Interfaces;
using TestApp.Application.Validator;
using TestApp.Domain.Entiti;
using TestApp.Persistence.Repositories;

namespace TestWebApi
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
           

            //Validation
            services
   .AddMvc()
   .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TodoValidator>());

            services.AddSingleton<ApplicationDbContext>();
            services.AddControllers();
            services.AddSingleton<ApplicationDbContext>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddControllers();
            services.ApplicationRegistration();

   //         services.AddControllers().AddJsonOptions(x =>
   //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

   //         services.AddControllers()
   //.AddJsonOptions(options => options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.Strict);


   //         var options = new JsonSerializerOptions()
   //         {
   //             PropertyNameCaseInsensitive = true,
   //             PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
   //             NumberHandling = JsonNumberHandling.AllowReadingFromString
   //         };
   //         services.AddControllers().AddJsonOptions(j =>
   //         {
   //             j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
   //         });
          







            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestWebApi v1"));
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
