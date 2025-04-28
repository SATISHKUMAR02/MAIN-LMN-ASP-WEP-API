
using services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AspNetCoreRateLimit;
using System.Text;
using services.Mapping;
using services.Application_Services.User_Service;
using services.Application_Services.LeadServices;
using services.Repository;
using services.Application_Services.MouServices.ConnectorServices;
using services.Application_Services.MouServices.TelecallerServices;
using services.Application_Services.MouServices.InstitutionServices;
using services.Application_Services.ActivityServices;
using services.Application_Services.Usermanagement.AddUsers.Connectors;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices;


var builder = WebApplication.CreateBuilder(args);
var lmn_specification = "lmn";
try
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddDbContext<DBConnection>(options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
          
              ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."),
              sqlOptions =>sqlOptions.MigrationsAssembly("services")
              ));

    builder.Services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));


    // Authentication setup
    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });

    builder.Services.AddAuthorization();

    // Register AutoMapper
    builder.Services.AddAutoMapper(typeof(MappingConfig));

    builder.Services.AddSwaggerGen(swagger =>
    {
        swagger.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "LNM",
            Version = "v1",
            Description = "LNM OpenAPI Documentation",
            Contact = new OpenApiContact
            {
                Name = "CSG",
                Email = "abhilash.ba@csgkarnataka.in",
            },
            License = new OpenApiLicense
            {
                Name = "LICX",
                Url = new Uri("https://example.com/license")
            }
        });
        // To Enable authorization using Swagger (JWT)
        swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
        });

        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });
    builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
    //cache control
    builder.Services.AddControllersWithViews().AddMvcOptions(options => options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
        }));

    // CORS configuration
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(lmn_specification, policy =>
        {
            policy.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();

        });
    });

   

    RegisterServices(builder.Services); //Register all the services

    // Register IP rate limiting services
    builder.Services.AddInMemoryRateLimiting();
    builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
    builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    //builder.Services.AddScoped<ILeadService, LeadService>();
  
}
catch (Exception ex)
{
    throw ex;
}

var app = builder.Build();

try
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LMN v1");
        c.RoutePrefix = "swagger"; 
    });
    app.MapGet("/", () => "Quartz Scheduler in ASP.NET Core 6!");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseCors(lmn_specification);
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseIpRateLimiting();

    if (app.Environment.IsDevelopment())
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers().AllowAnonymous();
        });
    }
    else
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    // Remove Server HTTP header
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Remove("Server");
        await next();
    });

    app.Run();
}
catch (Exception ex)
{
    throw ex;
}


 void RegisterServices(IServiceCollection services)
{


    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddTransient<ILeadService, LeadService>();
    builder.Services.AddTransient<IConnectorServices,ConnectorServices>();
    builder.Services.AddTransient<IInstitutionService,InstitutionServicecs>();
    builder.Services.AddTransient<IActivityService,ActivityService>();
    builder.Services.AddTransient<IAddConnectors,AddConnectors>();





}
