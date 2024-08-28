using BlazorApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Stunt.Components;
using Stunt.Components.Services.Implementation;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.Data;
using Stunt.Models;
using Stunt.Repositories.Implementation;
using Stunt.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultSqliteConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IStuntmanService, StuntmanService>();
builder.Services.AddScoped<IMovieSetService, MovieSetService>();
builder.Services.AddScoped<IHorseService, HorseService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IStuntLeaderService, StuntLeaderService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    db.Database.OpenConnection();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();