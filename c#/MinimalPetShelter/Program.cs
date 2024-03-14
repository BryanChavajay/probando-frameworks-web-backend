using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MinimalPetShelter.db;
using MinimalPetShelter.Rutas;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string key = "EstoyAprendiendoC#NoMeJusguen:):):)";

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

    opt.RequireHttpsMetadata = false;

    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = signingKey,
    };
});

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("Connection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

// Mis rutas
RutasAdoptador.Adoptador(app);
RutasMascotas.Mascota(app);
RutasAdopcion.Adopciones(app);
RutasUsuario.Usuarios(app);
RutasAutorizacion.Autorizacion(app);

app.Run();
