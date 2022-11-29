using BibliotecaVirtual.Api.Context;
using BibliotecaVirtual.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilita o CORS (pol�tica que permite a execu��o de um dominio diferente no navegador)
builder.Services.AddCors();

builder.Services.AddDbContext<BDBiblioteca>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BDBib"));
});

// Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Repositories
builder.Services.AddScoped<ILivroRepository, LivroRepository>(); // cada requisi��o obtem uma nova instancia do servi�o
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<IFavoritoRepository, FavoritoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7180", "https://localhost:7180")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
