using Microsoft.EntityFrameworkCore;
using VirtualWaiter.Service.Data.Models;
using VirtualWaiter.Service.Helpers;
using VirtualWaiter.Service.Interface;
using VirtualWaiter.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ContextHelpers>(builder.Configuration.GetSection("DbContext"));

var connectionString = builder.Configuration.GetSection("DbContext").Get<ContextHelpers>();

builder.Services.AddDbContextPool<VirtualWaiterContext>
    (options => options.UseMySql(connectionString.ConnectionString, ServerVersion.AutoDetect(connectionString.ConnectionString)));

builder.Services.AddScoped<IProduct, ProductService >();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IEaterytable, EaterytableService>();
builder.Services.AddScoped<IOrder, OrderService>();

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
