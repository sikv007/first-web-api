using Microsoft.EntityFrameworkCore;
using usersApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UsersAPIContext>(options => options.UseSqlite("Data source  = Users.db"));

builder.Services.AddCors(
  options => { options.AddPolicy("Allow",
  policies => policies
  .AllowAnyOrigin()
  .AllowAnyHeader()
  .AllowAnyMethod());
  }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("Allow");

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
