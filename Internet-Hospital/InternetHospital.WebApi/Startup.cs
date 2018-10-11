using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetHospital.BusinessLogic.Interfaces;
using InternetHospital.BusinessLogic.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using InternetHospital.DataAccess;
using InternetHospital.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using InternetHospital.BusinessLogic.Models;

namespace InternetHospital.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(); //for enable CROS
            services.AddScoped<IMailService, MailService>(); // register our mail service;
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection"))
            );
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.SignIn.RequireConfirmedEmail = true;
                config.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders(); // generate token for reset password, change email etc

            // for sign is
            //services.ConfigureApplicationCookie(config =>
            //{
            //    config.LoginPath = "/Auth/Login";
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => // for enable CROS
            options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseAuthentication();


            Mapper.Initialize(config => 
            { 
                config.CreateMap<UserRegistrationModel, User>();
            }
            );





            
            app.UseMvc();
        }
    }
}
