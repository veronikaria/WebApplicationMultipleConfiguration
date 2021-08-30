using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMultipleConfiguration
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            builder.SetBasePath(env.ContentRootPath);

            builder.AddIniFile("Google.ini");
            builder.AddJsonFile("Apple.json");
            builder.AddXmlFile("Microsoft.xml");

            Configuration = builder.Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ServiceCompany>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();



            var section = this.Configuration.GetSection("Microsoft");
            string res = $"{section["name"]} -> {section["staff"]}\n";


            section = this.Configuration.GetSection("Google");
            res += $"{section["name"]} -> {section["staff"]}\n";

            section = this.Configuration.GetSection("Apple");
            res += $"{section["name"]} -> {section["staff"]}\n";


            /*
             * 
             * 
             Подключите к серверу три типа файлов конфигурации: xml, json и ini. В каждом из них будет записана 
            информация о компаниях Microsoft, Apple и Google. В качестве обязательного параметра должно быть 
            количество сотрудников данных компаний. Создайте сервис, который будет анализировать количество 
            сотрудников, записанное в упомянутых выше файлах конфигурации, и выводить название компании, у 
            которой этот показатель выше
             *
             *
             */


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(res);
                });
            });
        }
    }
}
