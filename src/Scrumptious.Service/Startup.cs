﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrumptious.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Scrumptious.Service
{
    public class Startup
    {
        public IConfiguration Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.dev.json", optional: true)
            .Build();

            services.AddDbContext<scrumptiousdbContext>(o => o.UseSqlServer(Configuration["connectionString"]));
            services.AddMvc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
