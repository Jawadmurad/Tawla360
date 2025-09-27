using Bogus.Extensions.UnitedKingdom;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Tawla._360.Application;
using Tawla._360.Infrastructure;
using Tawla._360.Logging;
using Tawla._360.Logging.Middlewares;
using Tawla._360.Persistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddOpenApi();
builder.Host.UseLogging(builder.Configuration.GetConnectionString("LoggingConnection"));

services.RegisterApplication();
services.RegisterInfrastructure(builder.Configuration);


var app = builder.Build();


await using (var serviceScope = app.Services.CreateAsyncScope())
await using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
{
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});
}

app.UseHttpsRedirection();

app.UseLoggingMiddlewares();
app.MapControllers();


app.Run();
