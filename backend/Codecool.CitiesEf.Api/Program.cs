using Codecool.CitiesEf.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CitiesDataContext>(options =>
{
    var connectionstring = builder.Configuration.GetConnectionString("CitiesDataContext");
    options.UseSqlServer(connectionstring);
});

builder.Services.AddTransient<CitiesSeed>();


var app = builder.Build();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initialiser = services.GetRequiredService<CitiesSeed>();
initialiser.Seed();

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
public partial class Program { }