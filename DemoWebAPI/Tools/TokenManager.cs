using BLL_CorrectifLabo.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoWebAPI.Tools
{
    public class TokenManager
    {
        public static string secretKey = ";dexsfxcrscvhbnyujyhugbtvfrè§!'yçunâpuiç(vn^éà!azekljqoqfpf'çj)j '(§è!çfp2dov2qàç2!è§2ty2df!qsèiovl2jfndspçàiolk;,";
    
        public string GenerateToken(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myclaims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin": "user"),
                new Claim("UserId", user.Id.ToString())
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims: myclaims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(1),
                issuer: "monserver.com",
                audience: "monclient.com"
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
