using Contacts.Logic.Services;
using Contacts.Persistence;
using Contacts.Persistence.Repositories.Implementations;
using Contacts.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<ContactDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IContactRepository, ContactRepository>();
services.AddScoped<ContactService>();

services.AddControllers();

//services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();

var app = builder.Build();


app.UseRouting();

//app.UseSwagger();
//app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "Contacts Api");

app.Run();