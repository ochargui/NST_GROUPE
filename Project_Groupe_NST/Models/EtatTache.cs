using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class EtatTache
    {
        [Key]
        public int idEtatTache { get; set; }
        public string etatTache { get; set; }
        public string descriptionEtatTache { get; set; }
        public ICollection<Tache> Taches { get; set; }
    }
}
