using Classroom.Data;
using Classroom.Repository;
using Classroom.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedLibs.Configs;
using SharedLibs.Services;
using micro = SharedLibs.MicroServices;
using Newtonsoft.Json;

namespace Classroom.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClassroomDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ClassroomConnection"))
            );

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("RedisConnection");
                options.InstanceName = "master";
            });

            services.AddOptions();

            services.Configure<MicroServiceConfig>(Configuration.GetSection("MicroService"));

            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<IClassroomStudentRepository, ClassroomStudentRepository>();
            services.AddTransient<IStudentService, micro.StudentService>();
            services.AddTransient<IClassroomService, ClassroomService>();

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
