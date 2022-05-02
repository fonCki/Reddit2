using Application;
using Application.Contracts;
using Contracts;
using EFCDataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ForumContextClass>();
builder.Services.AddScoped<IPostService, PostServiceImp>();
builder.Services.AddScoped<IUserService, UserServiceImp>();
builder.Services.AddScoped<IPostDAO, EfcPostDao>();
builder.Services.AddScoped<IUserDAO, EfcUserDao>();


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