using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Role
    {
        [Key]
        public int idRole { get; set; }

        public string code { get; set; }
        public string label { get; set; }
        public ICollection<Users> Userss { get; set; }
    }
}
