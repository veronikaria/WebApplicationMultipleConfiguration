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
             ���������� � ������� ��� ���� ������ ������������: xml, json � ini. � ������ �� ��� ����� �������� 
            ���������� � ��������� Microsoft, Apple � Google. � �������� ������������� ��������� ������ ���� 
            ���������� ����������� ������ ��������. �������� ������, ������� ����� ������������� ���������� 
            �����������, ���������� � ���������� ���� ������ ������������, � �������� �������� ��������, � 
            ������� ���� ���������� ����
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
