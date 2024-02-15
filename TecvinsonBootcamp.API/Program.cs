using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TecvinsonBootcamp.API.Middleware;
using TecvinsonBootcamp.Domain.Constant;
using TecvinsonBootcamp.Repository;
using TecvinsonBootcamp.Repository.Data;
using TecvinsonBootcamp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicantRepositoryServices()
    .AddApplicantServices();

builder.Services.AddDbContext<TecvinsonDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString(DbConstant.DbConnectionString));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// adding the Middleware
app.UseMiddleware<ApplicantMiddleware>();

app.Run();
