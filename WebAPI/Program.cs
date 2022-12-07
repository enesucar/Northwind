using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using ServiceStack;
using System;
using System.Reflection;
using WebAPI.Caching;
using WebAPI.Caching.Microsoft;
using WebAPI.Caching.Redis;
using WebAPI.Repository;
using WebAPI.Repository.EntityFramework;
using MediatR;
using WebAPI.Behaviours;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheManager, RedisCacheManager>();
builder.Services.AddSingleton<IProductRepository, EfProductRepository>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehaviour<,>));

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

app.Run();
