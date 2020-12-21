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
using Xtx.Entity.NetCoreDemoDb;
using Xtx.EntityFramework.Core.DbContexts;
using Zxw.Framework.NetCore.DbContextCore;
using Zxw.Framework.NetCore.Extensions;
using Zxw.Framework.NetCore.IDbContext;
using Zxw.Framework.NetCore.Options;

namespace TestApp
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

            //services.AddDbContext<IDbContextCore, SQLiteDbContext>(new DbContextOption
            //{
            //    ConnectionString = "Data Source=F:\\EF6.db;Version=3;",
            //    ModelAssemblyName = "Xtx.Entity",
            //    IsOutputSql = true,
            //});
            //services.AddDbContextFactory(factory =>
            //{
            //    factory.AddDbContext<IDbContextCore, SqlServerDbContext>(new DbContextOption
            //    {
            //        TagName = "db1",
            //        ConnectionString = "data source=serverb;initial catalog=ErTuiShengShi;persist security info=True;user id=sa;password=sa.123;multipleactiveresultsets=True;application name=EntityFramework",
            //        ModelAssemblyName = "Xtx.Entity",
            //        IsOutputSql = true,
            //    });
            //});


            //services.Configure<DbContextOption>(options =>
            //{
            //    options.TagName = "db0";
            //    options.ConnectionString =
            //        "Data Source=F:\\EF6.db;Version=3;";
            //    //options.ModelAssemblyName = "Zxw.Framework.Website.Models";
            //});

            services.AddDbContextFactory(factory =>
            {
                //factory.AddDbContext<SQLiteDbContext>(new DbContextOption()
                //{
                //    TagName = "db1",
                //    ConnectionString = "Data Source=F:\\EF6.db;Version=3;"
                //});
                factory.AddDbContext<NetcoredemoContext>(new DbContextOption()
                {
                    TagName = "db3",
                    ConnectionString = "data source=serverb;initial catalog=NetCoreDemo;persist security info=True;user id=sa;password=sa.123;multipleactiveresultsets=True;application name=EntityFramework",
                });
                factory.AddDbContext<Db1Context>(new DbContextOption()
                {
                    TagName = "db2",
                    ConnectionString = "data source=serverb;initial catalog=TestDb1;persist security info=True;user id=sa;password=sa.123;multipleactiveresultsets=True;application name=EntityFramework",
                });
               

            });

            //services.AddScoped<IDbContextCore, SQLiteDbContext>(); //注入EF上下文

            services
                .AddScopedAssembly("Xtx.IRepository", "Xtx.Repository");
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestApp", Version = "v1" });
            });


            services.BuildAspectCoreServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestApp v1"));
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
