using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Absence
    {
        [Key]
        public int idAbsence { get; set; }

        public string EtatAbsence{ get; set; }
        public DateTimeOffset DateDebutAbsence { get; set; }

        public DateTimeOffset DateFin { get; set; }
        public DateTimeOffset DateRetourAbsence { get; set; }

        public string isValid { get; set; }
        public int idUsers{ get; set; }
        public int idtypeAbsence { get; set; }
        public int idEtatAbsence { get; set; }



    }
}
