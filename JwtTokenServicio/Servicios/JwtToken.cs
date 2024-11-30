using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtTokenServicio.Servicios
{
    public class JwtToken
    {
        private readonly string _llaveJwt;

        public JwtToken(IConfiguration configuration)
        {

            _llaveJwt = configuration["LLaveJwt"];
        }

        /// <summary>
        /// Agregue en el diccionario nombre, role, id, correo
        /// </summary>
        /// <param name="keys">Llave, valor para los claims</param>
        /// <param name="fechaDeExpiracion">Por standard 20 minutos mas a la fecha actual</param>
        /// <returns>Token</returns>
        public string ObtenerToken(Dictionary<string, string> keys, DateTime fechaDeExpiracion)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_llaveJwt));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);            

            var claims = new List<Claim>();
            foreach (var key in keys)            
                claims.Add(new Claim(key.Key, key.Value));           

            var tokenOptions = new JwtSecurityToken(
                //issuer: "https://localhost:5002",            
                claims: claims,
                expires: fechaDeExpiracion,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
