using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Users
    {
      
        [Key]
        public int id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string RestPassword { get; set; }


        public int roleid { get; set; }
        public int idCRA { get; set; }
        public int idRole { get; set; }
        public ICollection<Absence> Absence { get; set; }
        public ICollection<Notification>Notification{ get; set; }
        public ICollection<Pointage> pointages{ get; set; }








    }
}
