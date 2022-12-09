using RISEDemo.Infrastructure.ServiceExtension;
using RISEDemo.Services;
using RISEDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IUrunService, UrunService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
