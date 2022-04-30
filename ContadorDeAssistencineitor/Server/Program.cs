using MediatR;
using Application.CountGroup;
using Application.Contracts.Repositories;
using Infrastructure.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CountGroupContext>(options => options.UseInMemoryDatabase("CountGroup"));
builder.Services.AddScoped<ICountGroup, CountGroupRepository>();
builder.Services.AddMediatR(typeof(Create).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();
