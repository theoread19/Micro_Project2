using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domain;
using Domain.Logging;
using Domain.Repository;
using Infrastructure.Logging;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Services;
using Web_API.Services.iplm;

namespace Web_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            var builder = new ContainerBuilder();
            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            //repository
            services.AddScoped<IMessageRepository, MessageRepository>();

            //service
            services.AddScoped<IMessageService, MessageService>();
            //
            services.AddSingleton<ILoggerManager, LoggerManager>();

            builder.RegisterType<MessageRepository>().As<IMessageRepository>();

            builder.RegisterType<MessageService>().As<IMessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
            // specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
