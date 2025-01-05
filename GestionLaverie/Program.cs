using liveriAPI.infrastructuer;
using liveriAPI.Model.Business;
using liveriAPI.Model.Domaine;

var builder = WebApplication.CreateBuilder(args);

// Ajouter vos services
builder.Services.AddScoped<IProprietaireDAO, ProprietaireDAO>(); // Ajout de l'interface et de son impl�mentation
builder.Services.AddScoped<ConfigurationBusiness>(); // Ajout de votre service m�tier

// Ajouter les contr�leurs
builder.Services.AddControllers();

// Configurer Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration pour l'environnement de d�veloppement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware HTTPS et Authorisation
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
