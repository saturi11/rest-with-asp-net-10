var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllers();

var app = builder.Build();

//Configure thew HTTP request pipeline

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();