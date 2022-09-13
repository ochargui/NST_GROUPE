using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Activite
    {
        [Key]

        public int idActivite { get; set; }

        public string NomActivite { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateDebutAct{ get; set; }

        public DateTimeOffset DateCreactionAct { get; set; }
        public string isValid { get; set; }
        public int idtypeActivite { get; set; }
        public int idEtatActivite { get; set; }
        public ICollection<Projet> Projets { get; set; }
        public ICollection<Mission> Missions{ get; set; }


    }
}
