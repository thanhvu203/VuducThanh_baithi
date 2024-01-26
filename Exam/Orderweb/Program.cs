using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orderweb.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderwebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderwebContext") ?? throw new InvalidOperationException("Connection string 'OrderwebContext' not found.")));

// Add services to the container.
string _policyName = "CorsPolicy";
string _anotherPolicy = "AnotherCorsPolicy";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: _policyName, builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
    opt.AddPolicy(name: _anotherPolicy, builder =>
    {
        builder.WithOrigins("https://localhost:7056")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
app.UseCors(_policyName);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();