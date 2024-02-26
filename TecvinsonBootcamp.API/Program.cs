using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Serilog;
using TecvinsonBootcamp.Domain.Constant;
using TecvinsonBootcamp.Repository;
using TecvinsonBootcamp.Repository.Data;
using TecvinsonBootcamp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRepository()
    .AddService();

builder.Services.AddDbContext<TecvinsonDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString(DbConstant.DbConnectionString));
});


builder.Services
    .AddControllers()
    // using the NewtonsoftJson formatter
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());   
    });
builder.Services.AddSwaggerGenNewtonsoftSupport(); // swagger support for NewtonsoftJson

builder.Host.UseSerilog((builderContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(builderContext.Configuration);
});
//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);

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

//app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// adding the Middleware
//app.UseMiddleware<ApplicantMiddleware>();

app.Run();
