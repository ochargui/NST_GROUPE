using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class typeAbsence
    {
        [Key]
        public int idTAbsence { get; set; }

        public string code { get; set; }
        public string label { get; set; }
        public ICollection<Absence> Absences { get; set; }





    }
}
