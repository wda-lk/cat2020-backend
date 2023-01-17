using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAT20.Core;
using CAT20.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Options;
using CAT20.Core.Services.Control;
using CAT20.Core.Services.Vote;
using CAT20.Services.Control;
using CAT20.Services.Vote;
using CAT20.Core.Services.User;
using CAT20.Services.User;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.HttpOverrides;

namespace CAT20.Api
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
            services.AddDbContext<ControlDbContext>(options => options.UseMySql(Configuration.GetConnectionString("control"), ServerVersion.AutoDetect(Configuration.GetConnectionString("control"))).UseLoggerFactory(
                    LoggerFactory.Create(
                        b => b
                            .AddConsole()
                            .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging().EnableDetailedErrors());

            services.AddDbContext<VoteAccDbContext>(options => options.UseMySql(Configuration.GetConnectionString("vote"), ServerVersion.AutoDetect(Configuration.GetConnectionString("vote"))).UseLoggerFactory(
                    LoggerFactory.Create(
                        b => b
                            .AddConsole()
                            .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging().EnableDetailedErrors());

            services.AddDbContext<UserActivityDBContext>(options => options.UseMySql(Configuration.GetConnectionString("user"), ServerVersion.AutoDetect(Configuration.GetConnectionString("user"))).UseLoggerFactory(
                    LoggerFactory.Create(
                        b => b
                            .AddConsole()
                            .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging().EnableDetailedErrors());

            services.AddScoped<IControlUnitOfWork, ControlUnitOfWork>();
            services.AddScoped<IVoteUnitOfWork, VoteUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();


            services.AddControllers();

            //JWT Authentication
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = Configuration["Jwt:Audience"],
            //        ValidIssuer = Configuration["Jwt:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            //    };
            //});


            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Jwt:Key").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            //                .GetBytes(Configuration.GetSection("Jwt:Key").Value)),
            //            ValidateIssuer = true,
            //            ValidateAudience = true
            //        };
            //    });

            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("CorsPolicy",
            //        policy => { policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"); });
            //});

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddEndpointsApiExplorer();


            //Control Services
            services.AddTransient<IAppCategoryService, AppCategoryService>();
            services.AddTransient<IBankDetailService, BankDetailService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IMonthService, MonthService>();
            services.AddTransient<IOfficeService, OfficeService>();
            services.AddTransient<IOfficeTypeService, OfficeTypeService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<ISabhaService, SabhaService>();
            services.AddTransient<ISelectedLanguageService, SelectedLanguageService>();
            services.AddTransient<IYearService, YearService>();
            services.AddTransient<IEmailOutBoxService, EmailOutBoxService>();
            services.AddTransient<IEmailConfigurationService, EmailConfigurationService>();


            //Vote Services
            services.AddTransient<IAccountBalanceDetailService, AccountBalanceDetailService>();
            services.AddTransient<IAccountDetailService, AccountDetailService>();
            services.AddTransient<IBalancesheetBalanceService, BalancesheetBalanceService>();
            services.AddTransient<IBalancesheetSubtitleService, BalancesheetSubtitleService>();
            services.AddTransient<IBalancesheetTitleService, BalancesheetTitleService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ISubProjectService, SubProjectService>();
            services.AddTransient<IIncomeSubtitleService, IncomeSubtitleService>();
            services.AddTransient<IIncomeTitleService, IncomeTitleService>();
            services.AddTransient<IVoteAllocationService, VoteAllocationService>();
            services.AddTransient<IProgrammeService, ProgrammeService>();
            services.AddTransient<IVoteDetailService, VoteDetailService>();

            //User Services
            services.AddTransient<IUserDetailService, UserDetailService>();
            services.AddTransient<IPreviledgeService, PreviledgeService>();
            services.AddTransient<IUserHasPreviledgeService, UserHasPreviledgeService>();
            services.AddTransient<IUserRecoverQuestionService, UserRecoverQuestionService>();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Products", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(x => x
            //    .WithOrigins("http://localhost:4200")
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials

            app.UseCors(builder =>
            {
                builder
                   .WithOrigins("http://localhost:4200", "http://localhost:51961", "https://localhost:4200", "http://localhost", "https://localhost", "http://localhost:80", "https://localhost:80", "http://cat2020.lk", "https://cat2020.lk")
                   .SetIsOriginAllowedToAllowWildcardSubdomains()
                   .AllowAnyHeader()
                   .AllowCredentials()
                   .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                   .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            }
);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Products V1");
            });

            app.UseStaticFiles();// For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"
            });
            //Enable directory browsing
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                            Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"
            });


            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
            //    RequestPath = "/Photos"
            //});
        }
    }
}
