using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace dotnet.service.Helper
{
    public class JwtService
    {
        private string secureKey = "45fy46yg645g6y666y6b6un6e6bu";
        public String Generate(String id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            var credential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credential);
            var payload = new JwtPayload(id, null, null, null, DateTime.Today.AddDays(1));
            var secureToken = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(secureToken);
        }
        public JwtSecurityToken Verify(String token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secureKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }
            , out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }
    }
}
