using Net6.Lab.Example.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net6.Lab.Example.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Net6LabExampleContext>(options =>
//options.UseInMemoryDatabase("Lab")
options.UseSqlServer(builder.Configuration.GetConnectionString("Net6LabExampleContext"))
);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

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

app.Run();
