using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class EtatAbsence
    {
        [Key]
        public int idEAbsence { get; set; }

        public string EtatProjet { get; set; }
        public string Description { get; set; }

        public ICollection<Absence> Absences { get; set; }

    }
}
