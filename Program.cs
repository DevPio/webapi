using Microsoft.EntityFrameworkCore;
using webapi.Controllers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(opts=> {
    opts.UseSqlite(builder.Configuration.GetConnectionString("database"));
});
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
