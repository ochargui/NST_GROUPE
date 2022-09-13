using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Views
{
    public class AuthModel
    {
     
        public string Nom { get; set; }
        public string Prenom { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }



        public int idRole { get; set; }

       
        public int idCRA{ get; set; }
      

     


    }
}