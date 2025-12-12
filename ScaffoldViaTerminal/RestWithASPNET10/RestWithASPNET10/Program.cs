using RestWithASPNET10.Configs;
using RestWithASPNET10.Service;
using RestWithASPNET10.Service.Impl;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllers();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<IPerasonService, PersonServicesImpl>();

var app = builder.Build();

//Configure thew HTTP request pipeline

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();