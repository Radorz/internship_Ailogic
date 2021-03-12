using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace internship_Ailogic.Helpers
{
    public class Utilities
    {

        private readonly IConfiguration _configuration;

        public Utilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       public string CreatePassword(string name, string lastname, string cedula ,DateTime date)
       {
            string password = name.Substring(0, 3)
                + lastname.Substring(0, 3)
                + cedula.Substring(4, 3)
                + Convert.ToString(date).Substring(0, 6);
            return password;
       }


       public string FormatCedula(string cedula)
       {
            if (cedula.Contains("-") && cedula.Length == 13)
            {
                return cedula;
            }
             else if(cedula.Length == 11 && !cedula.Contains("-"))
            {
                cedula.Insert(2, "-");
                cedula.Insert(11, "-");
                return cedula;
            }
            else
            {
                return "Invalid Cedula";
            }
       }

        public string FormatPhone(string phone)
        {
            if (phone.Contains("-") && phone.Length == 12)
            {
                return phone;
            }
            else if (phone.Length == 10 && !phone.Contains("-"))
            {
                phone.Insert(3, "-");
                phone.Insert(7, "-");
                return phone;
            }
            else
            {
                return "Invalid Phone";
            }
        }


        public UserToken BuildToken(UserInfo userInfo, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                new Claim("miValor", "Loqueseamanito"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tiempo de expiracion del token.
            var expiration = DateTime.UtcNow.AddHours(5);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };


        }




    }
}
