using Microsoft.EntityFrameworkCore;
using Ttalesson09.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Chu y usesing 
var connectionString = builder.Configuration.GetConnectionString("TtaBookStore");
builder.Services.AddDbContext<TtaBookContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/TtaHome/TtaError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TtaHome}/{action=TtaIndex}/{TtaId?}");
    
app.Run();
