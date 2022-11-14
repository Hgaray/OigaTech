using Microsoft.EntityFrameworkCore;
using OigaTech.BusinessRules;
using OigaTech.DataAccess;
using OigaTech.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//// set options to DbCOntext
builder.Services.AddDbContext<OigaTechDBContext>(db =>
    db.UseSqlServer(
        builder.Configuration.GetConnectionString("OigaTechDBConnection")));

//builder.Services.AddDbContext<OigaTechDBContext>(db =>
//    db.UseSqlServer("data source=DESKTOP-CSKLPH3,1433;initial catalog=OigaTechDataBase;User Id=OigaUser;Password=Octubr3_2022;Encrypt=False;Trusted_Connection=False;",
//    builder=>builder.EnableRetryOnFailure()));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserBusinessRules, UserBusinessRules>();

builder.Services.AddControllers();
builder.Services.AddDaprClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();
app.Run();
