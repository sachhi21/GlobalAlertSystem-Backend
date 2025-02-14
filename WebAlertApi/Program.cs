using Microsoft.EntityFrameworkCore;
using NLog.Config;
using NLog;
using PortRec.RepositoryLayer.Repository;
using RepositoryLayer.IRepository;
using WebAlertApi.IServices;
using WebAlertApi.Services;
var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("portrecDBConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString, d => d.MigrationsAssembly("WebAlertApi")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
builder.Services.AddScoped<IRepository, Repository>();
var NlogPath = builder.Configuration.GetConnectionString("NlogConfigPath");
LogManager.Configuration = new XmlLoggingConfiguration(NlogPath);
builder.Services.AddScoped<IIncidentService, IncidentService> ();
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");

app.Run();
