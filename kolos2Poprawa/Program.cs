

using kolos2Poprawa.Database;
using kolos2Poprawa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? connectionString = builder.Configuration.GetConnectionString("Default");
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    }
);
builder.Services.AddScoped<IDbService, DbService>();
//builder.Services.AddScoped<>()


builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();



app.Run();