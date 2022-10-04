using Microsoft.EntityFrameworkCore;
using Articulo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Contexto>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
//    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))    
);

builder.Services.AddScoped<Contexto, Contexto>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
