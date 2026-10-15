using api.Config;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//aca van los seteos del builder -> osea en el contenedor de services

builder.Services.AddScoped<UsuarioServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuracion de db

builder.Services.AddDbContext<AppDbContext>(options =>
{
    string conn = builder.Configuration.GetConnectionString("dbDev") ?? string.Empty;
    options.UseSqlServer(conn);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

//middleware de cors que me permite enviar peticiones hacia el back

app.UseCors(opt =>
{
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    opt.AllowAnyOrigin();
});


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
