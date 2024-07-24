using ClinicManager.API.Extensions;
using ClinicManager.API.Filters;
using ClinicManager.Application.Validators.Patient;
using ClinicManager.Core.Entities;
using ClinicManager.Infrastructure;
using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opt => opt.Filters.Add(typeof(ValidatorFilter))).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreatePatientCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

var app = builder.Build();

app.UseHangfireDashboard();

var smtp = new Configuration.SmtpConfiguracao();
app.Configuration.GetSection("Smtp").Bind(smtp);
Configuration.Smtp = smtp;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
