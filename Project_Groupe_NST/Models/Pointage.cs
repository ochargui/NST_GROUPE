using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Pointage
    {

        [Key]
        public int idPointage { get; set; }

        public DateTimeOffset DateConnexion { get; set; }
        public DateTimeOffset DateDeconnexion { get; set; }
        public int idUsers { get; set; }

    }
}
