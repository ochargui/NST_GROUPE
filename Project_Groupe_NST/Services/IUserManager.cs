using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project_Groupe_NST.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Services
{
    public interface IUserManager
    {
        SecurityToken Login(LoginViewModel model);

  
        


    }
}
