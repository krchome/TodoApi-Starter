using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;
var builder = WebApplication.CreateBuilder(args);
using var cnn = new SqliteConnection("Filename=:memory:");
cnn.Open();
builder.Services.AddDbContext<TodoContext>(o=>o.UseSqlite(cnn));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<TodoContext>();
DbInitializer.Initialize(db);

DbInitializer.Initialize(db);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "GetTodoItem",
        pattern: "api/todoitems/{id}",
        defaults: new { controller = "TodoItems", action = "GetTodoItemAsync" }
    );
});



app.Run();

public partial class Program
{

}
