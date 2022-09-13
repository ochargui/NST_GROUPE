using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Type_Projet
    {
        [Key]
        public int idTProjet { get; set; }

        public string code { get; set; }
        public string label { get; set; }
        public ICollection<Projet> Projets { get; set; }
    }
}
