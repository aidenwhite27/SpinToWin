using Microsoft.EntityFrameworkCore;
using Model;

var builder = WebApplication.CreateBuilder(args);
var allowLocalhost = "_allowLocalhost";
Random rand = new Random();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<GameContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowLocalhost,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5110");
                          policy.WithOrigins("https://localhost:7217");
                          //policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseCors("_allowLocalhost");

app.MapControllers();

app.Run();