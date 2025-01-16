using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Services;
using DAL_CorrectifLabo.Interface;
using DAL_CorrectifLabo.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Ma super API",
            Description = "Api démo pour les Architect .Net",
            Contact = new OpenApiContact
            {
                Name = "Mon nom à moi !!!",
                Email = "arthur@kaamelott.com"
            }
        });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
    }
    );
//Activer l'option "Fichier de documentation" les propriétés du projet
//click droit sur le projet => Propriétés => Build => Sortie

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICoffretRepository, CoffretRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ICoffretUserRepository, CoffretUserRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICoffretService, CoffretService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

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
