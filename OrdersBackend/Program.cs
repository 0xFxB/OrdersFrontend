using OrdersBackend.Business;
using OrdersBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.InitSqlServer(builder.Configuration);
builder.Services.InitBusiness();

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5119", "https://localhost:7107");
        //builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
