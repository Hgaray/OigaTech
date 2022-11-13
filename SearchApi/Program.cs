using Microsoft.EntityFrameworkCore;
using OigaTech.DataAccess;

var builder = WebApplication.CreateBuilder(args);



//// set options to DbCOntext
builder.Services.AddDbContext<OigaTechDBContext>(db =>
    db.UseSqlServer(
        builder.Configuration.GetConnectionString("OigaTechDBConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
