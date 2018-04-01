using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Demo.Domain.Model;
using Demo.Domain.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo.Api
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
            services.AddDbContext<ModelContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DemoContext")));

            services.AddMvc();
        }


        // Configure Autofac. Called after ConfigureServices()
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //TODO: нужно проверить корректен ли подход - задача: убрать зависимость от ModelContext-а
            //builder
            //    .Register(ctx => ctx.Resolve<ModelContext>())
            //    .As<IModelContext>();

            builder.RegisterType<UserService>().AsImplementedInterfaces();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
