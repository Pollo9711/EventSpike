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
using System.Threading.Tasks;
using EventSpikeBack.Context;
using EventSpikeBack.Interfaces.Repositories;
using EventSpikeBack.Interfaces.Services;
using EventSpikeBack.Mapping;
using EventSpikeBack.Repositories;
using EventSpikeBack.Services;
using Microsoft.EntityFrameworkCore;

namespace EventSpikeBack.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventSpikeBack.Api", Version = "v1" });
            });

            services.AddDbContext<EventSpikeBackDbContext>(opt => opt.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:EventSpikeBackDbConnectionString")));

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("myPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventSpikeBack.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("myPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
