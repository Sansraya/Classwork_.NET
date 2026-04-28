using Sem2.Modals;
using Sem2.Data;
using Microsoft.EntityFrameworkCore;
using Sem2.Services.Interface;
using Sem2.Services.Implementation;
using Sem2.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Sem2.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.Configure<Sem2.Data.Entities.Student>(
    builder.Configuration.GetSection("Student")
    );

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"))
    );

builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();


 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
