using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Repositories.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddScoped<DivisionRepository>(); // register service Division Repository
builder.Services.AddScoped<DepartementRepository>(); //register service Departement Repository
builder.Services.AddScoped<AccountRepository>();

builder.Services.AddDbContext<MyContext>(  //register service DbContext
    opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("MyConnectionString")
        )
    );
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

app.Run();
