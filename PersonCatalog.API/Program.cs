using Microsoft.EntityFrameworkCore;
using PersonCatalog.Application.Commands;
using PersonCatalog.Application.Handlers;
using PersonCatalog.Core.Interfaces;
using PersonCatalog.Infrastructure.Data;
using PersonCatalog.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39)),
        mysqlOptions =>
        {
            mysqlOptions.MigrationsAssembly("PersonCatalog.Infrastructure");
            mysqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        }
    )
);

builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Register MediatR and Handlers
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(UpdatePersonHandler).Assembly);
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(CreatePersonHandler).Assembly);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonCatalog.API v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
