using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MinimalPetShelter.Controladores
{
    public static class JWTHandler
    {
        private static readonly string Secret = "EstoyAprendiendoC#NoMeJusguen:):):)";
        // Método para generar un token JWT
        public static string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(Secret);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
               
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), 
                                                                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDes);
            return tokenHandler.WriteToken(token);
        }
        // Método para obtener el principal a partir de un token JWT
        public static ClaimsPrincipal? GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Convert.FromBase64String(Secret);
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var principal = tokenHandler.ValidateToken(token, parameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
