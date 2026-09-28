
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using vemdezap.Domain.Entities;

namespace vemdezap.Api.Services;

public class TokenService(IConfiguration configuration)
{
    public string GerarToken(Usuario usuario)
    {
        var jwtConfig = configuration.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"]!));
        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            //sub => subject(identificador único do usuário)
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            //email
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email), 
            //jti => jwt id(id do token, que permite montar uma lista de tokens
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //aqui é que faz funcionar [Authorize(Roles = "...")]
            new Claim(ClaimTypes.Role, usuario.Papel)
        };

        var token = new JwtSecurityToken
        (
            issuer: jwtConfig["Issuer"],
            audience: jwtConfig["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtConfig["ExpiresInMinutes"]!)),
            signingCredentials: credenciais
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
