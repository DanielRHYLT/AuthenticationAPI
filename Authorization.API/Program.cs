using Microsoft.EntityFrameworkCore;
using Authorization.CORE.Entities;
using Authorization.CORE.Interfaces;
using Authorization.CORE.Services;
using Authorization.INFRAESTRUCTURE.Data;
using Authorization.INFRAESTRUCTURE.Repositories;
using Authorization.INFRAESTRUCTURE.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<DbauthContext>
    (options => options.UseSqlServer(_cnx));
builder.Services.AddSharedInfraestructure(_config);
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersService, UsersService>();

builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddCors(Options =>
{
    Options.AddDefaultPolicy(builder =>
    {
        var urlFrontend = "http://localhost:9000/";
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
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

app.UseCors();

app.Run();
