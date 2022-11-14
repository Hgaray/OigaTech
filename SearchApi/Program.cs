using Microsoft.EntityFrameworkCore;
using OigaTech.BusinessRules;
using OigaTech.DataAccess;
using OigaTech.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);



//// set options to DbCOntext
builder.Services.AddDbContext<OigaTechDBContext>(db =>
    db.UseSqlServer(
        builder.Configuration.GetConnectionString("OigaTechDBConnection")));


//builder.Services.AddDbContext<OigaTechDBContext>(db =>
//    db.UseSqlServer("data source=DESKTOP-CSKLPH3,1433;initial catalog=OigaTechDataBase;User Id=OigaUser;Password=Octubr3_2022;Encrypt=False;Trusted_Connection=False;",
//    builder => builder.EnableRetryOnFailure()));

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
