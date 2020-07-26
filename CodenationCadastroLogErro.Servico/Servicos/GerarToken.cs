using CodenationCadastroLogErro.Dominio.Moldels;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using CodenationCadastroLogErro.Dominio.Repository;

namespace CodenationCadastroLogErro.Servico.Servicos
{
    public class GerarToken : IGerarToken
    {
        private readonly Token _token;
        public GerarToken(IOptions<Token> token)
        {
            _token = token?.Value;
        }
        public string GerarOfToken(User usuario)
        {
            if (usuario is null) return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role,usuario.Role),
                }),
                Issuer = _token.Emissor,
                Audience = _token.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_token.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
  