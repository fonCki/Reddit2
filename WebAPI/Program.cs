using Application;
using Application.Contracts;
using Contracts;
using JsonDataAccess;
using JsonDataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JsonContext>();
builder.Services.AddScoped<IPostService, PostServiceImp>();
builder.Services.AddScoped<IUserService, UserServiceImp>();
builder.Services.AddScoped<IPostDAO, JsonPostDAO>();
builder.Services.AddScoped<IUserDAO, JsonUserDAO>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();