using BLL_CorrectifLabo.Interface;
using BLL_CorrectifLabo.Services;
using DAL_CorrectifLabo.Interface;
using DAL_CorrectifLabo.Repositories;
using DemoWebAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secretKey)),
            ValidateLifetime = true,
            ValidIssuer = "monserver.com",
            ValidateAudience = false
        };
    }    
    );

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("adminPolicy", policy => policy.RequireRole("admin"));
    options.AddPolicy("authPolicy", policy => policy.RequireAuthenticatedUser());
});

builder.Services.AddScoped<TokenManager>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICoffretRepository, CoffretRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ICoffretUserRepository, CoffretUserRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICoffretService, CoffretService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Services.AddCors(o => o.AddDefaultPolicy(
    options => options.WithMethods("GET", "POST")
                      .WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//a mettre dans cet ordre
app.UseAuthentication();
app.UseAuthorization();
//wild card
//app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
//app.UseCors();
app.MapControllers();

app.Run();
