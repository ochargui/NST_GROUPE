using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class EtatMission
    {
        [Key]
        public int idEtatMission { get; set; }
        public string etatMission { get; set; }
        public bool isValidEtatMission { get; set; }
       
        public string DescriptionEtatMission { get; set; }
        public ICollection<Mission> Missions { get; set; }

    }
}
