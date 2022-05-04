using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bootcamp.Repository.Repositories;
using Bootcamp.Service.DependecyResolvers.Autofac;
using Bootcamp.WebAPI.Filters;
using Bootcamp.WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilter())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CheckProductIdActionFilter>();

builder.Services.AddScoped<IDbConnection>(serviceProvider => new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgresql")));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IDbTransaction>(serviceProvider =>
{
    var connection = serviceProvider.GetRequiredService<IDbConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

builder.Services.AddScoped<UnitOfWork>(); //TODO: silinecek


var app = builder.Build();

app.UseGlobalExceptionHandleMiddleware();
app.UseMiddleware<IPAddressControlMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}"
//    );
//});

app.Run();
