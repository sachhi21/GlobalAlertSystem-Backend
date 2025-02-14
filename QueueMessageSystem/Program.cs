using QueueMessageSystem.Model;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString, d => d.MigrationsAssembly("QueueMessageSystem")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });


var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
