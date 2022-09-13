

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_Groupe_NST.Models;
using Project_Groupe_NST.Services;
using Project_Groupe_NST.Views;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Conge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TokenController : ControllerBase
    {
        private readonly ProjectsDbContext _context;

        private IConfiguration _configuration;
        private readonly IUserManager _userManager;
        public TokenController(

            IConfiguration configuration,
            ProjectsDbContext context,
            IUserManager userManager)
        {

            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Some properties are not valid");

            var token = _userManager.Login(model);
            if (token != null)
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            return BadRequest("Invalid credentials");
        }


       [HttpPost("ForgetPassword")]
        public ActionResult<string> ForgotPassword(string EmailID)
        {

            string message = "";
            bool status = false;

            {
                Users user = _context.Users.Where(x => x.Email == EmailID).FirstOrDefault();

                if (user != null)
                {

                    string resetCode = Guid.NewGuid().ToString();

                    user.RestPassword = resetCode;
                    _context.SaveChanges();
                    return resetCode;

                }
                else
                {
                    message = "Account not found";
                    return message;
                }
            }
        }
     

        [HttpPost("ResetPassword")]
        public async Task<Boolean> ResetPassword(ResetPasswordModel model)

        {
            Boolean message = false;
            if (ModelState.IsValid)
            {

                    Users user = _context.Users.Where(x => x.RestPassword == model.ResetCode).FirstOrDefault();
                if (user != null)
                {
                    //   user.mdp = Crypto.Hash(model.NewPassword);
                    user.Password = model.NewPassword;
                    user.RestPassword = "";

                    _context.SaveChanges();
                    message = true;
                }
                else
                {
                    message = false;
                }
            }

            return message;
        }



        [HttpGet("GetTeamByIdSup")]

        public ActionResult GetTeamByIdSup(int id)
        {
            List<Users> Collaborateurs = _context.Users.Where(c => c.id == id).Select(c => new Users { id = c.id,
              Nom = c.Nom, Prenom = c.Prenom, Email = c.Email, Password = c.Password, roleid = c.roleid, idCRA = c.idCRA }).ToList();
         
          
            return new ObjectResult(Collaborateurs);
        }
    }
}

