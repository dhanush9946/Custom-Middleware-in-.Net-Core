using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Use(async (context, next) =>
{
    Console.WriteLine("request middleware 1");
    await next();
    Console.WriteLine("response Middleware 1");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware2 Request");
    await next();
    Console.WriteLine("Middleware2 Response");
});

app.Run(async (context) =>
{
    Console.WriteLine("Middleware3 is the terminal middleware");
    await context.Response.WriteAsync("Hello world response");
});

app.Run();
