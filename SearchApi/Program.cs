using Microsoft.EntityFrameworkCore;
using OigaTech.BusinessRules;
using OigaTech.DataAccess;
using OigaTech.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<OigaTechDBContext>(db =>
    db.UseSqlServer(
        builder.Configuration.GetConnectionString("OigaTechDBConnection")), ServiceLifetime.Transient);



// Add services to the container.
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserBusinessRules, UserBusinessRules>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();

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
