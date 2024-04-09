using API.Config;
using API.Context;
using API.IServices;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var build = new ConfigurationBuilder();
build.AddJsonFile("appsettings.json");
var configuration = build.Build();


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbContextSettings>(configuration);
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICaisseService, CaisseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILignedeVenteService, LignedeventeService>();
builder.Services.AddScoped<IModepaiementService, ModepaiementService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IVenteService, VenteService>();
builder.Services.AddScoped<IDbContextFactory, DbContextFactory>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
                          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Add services to the container.
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
app.UseRouting();

app.UseAuthorization();
app.MapControllers();


app.Run();


