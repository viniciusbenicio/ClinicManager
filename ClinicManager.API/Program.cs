using Amazon.Runtime.Internal.Transform;
using ClinicManager.API.Extensions;
using ClinicManager.API.Filters;
using ClinicManager.Application.Job;
using ClinicManager.Application.Validators.Patient;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opt => opt.Filters.Add(typeof(ValidatorFilter))).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePatientCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicManager.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquema Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{ }
    }   });
});
builder.Services.AddInfrastructure().AddApplication().AddServices();




builder.Services.AddDbContext<ClinicManagerDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHangfire((sp, config) =>
{
    config.UseSqlServerStorage(connectionString);
});

builder.Services.AddHangfireServer();


builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,


        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<NotificationEmailTask>("job-send-notification", jb => jb.Execute(), "*/1 * * * *");


var smtp = new Configuration.SmtpConfiguracao();
app.Configuration.GetSection("Smtp").Bind(smtp);
Configuration.Smtp = smtp;

var sms = new Configuration.SmsConfiguracao();
app.Configuration.GetSection("Sms").Bind(sms);
Configuration.Sms = sms;

var calendar = new Configuration.GoogleConfiguracao();
app.Configuration.GetSection("Calendar").Bind(calendar);
Configuration.Calendar = calendar;


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
