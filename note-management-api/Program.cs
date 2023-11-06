
using Core.Handlers;
using Core.Services;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Settings;
using Services.Database;
using Services.Database.Base;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return config.GetRequiredSection("Settings").Get<Settings>();
});

var provider = builder.Services.BuildServiceProvider();
var settings = provider.GetRequiredService<Settings>();

builder.Services.AddDbContextFactory<AppDbContext>(
    options =>
    {
        options
            .UseSqlServer(settings.ConnectionString);
    }, ServiceLifetime.Scoped);

builder.Services.AddTransient<NotesHandler>();
builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.Run();
