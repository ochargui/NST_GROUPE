using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_Groupe_NST.Models;
using Project_Groupe_NST.Views;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Project_Groupe_NST.Services
{
    public class UserManager : IUserManager
    {
        private readonly ProjectsDbContext _context;
        private readonly IConfiguration _configuration;

        public UserManager(
            ProjectsDbContext context,
            IConfiguration config)
        {
            _context = context;
            _configuration = config;
        }

        public SecurityToken Login(LoginViewModel model)
        {
            Users user = _context.Users.Where(x => x.Password == model.Password && x.Email == model.Email).FirstOrDefault();
            if (user != null)
            {
                var claims = new[]{
                    new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim("id",user.id.ToString()),
                    new Claim("Email",user.Email),
                    new Claim("Password",user.Password)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signIn);
                return token;
            }
            return null;

        }

       
    }
}
