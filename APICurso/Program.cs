using WebApplication1.Helpers;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrando o reposit�rio como servi�o 
builder.Services.AddScoped<TarefaRepositorio>(provider =>
    new TarefaRepositorio(ConfigurationHelper.GetAppSetting<string>("ConnectionStrings:DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();
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
