using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class CRA
    {
        [Key]
        public int idCRA{ get; set; }

        public DateTimeOffset date { get; set; }
        public string dure_conge { get; set; }

        public string conge_paye { get; set; }
        public string conge_non_paye{ get; set; }
        public ICollection<Users> Userss { get; set; }







    }
}
