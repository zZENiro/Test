using Test.DataAccess;
using Test.DataAccess.MSServer;
using Test.Domain;

var builder = WebApplication.CreateBuilder(args);

var cfgBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddUserSecrets(typeof(Program).Assembly);

var configuration = cfgBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// App services
builder.Services.AddSingleton<IDataAccessProviderFactory<MSServerDataAccessProvider>, MSServerDataAccessProviderFactory>();
builder.Services.AddModuleServices(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
}

app.MapControllerRoute("api", "api/{controller}/{action}/{param?}");

app.Run();