using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Projet
    {
        [Key]

        public int idProjet { get; set; }

        public string NomProjet { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateDebutA { get; set; }

        public DateTimeOffset DateCreaction { get; set; }
        public string isValid { get; set; }
        public int idActivite { get; set; }
        public int idtypeProjet { get; set; }
        public int idEtatProjet { get; set; }
        public ICollection<Tache> Taches { get; set; }
        public ICollection<Mission> Missions { get; set; }


    }
}
