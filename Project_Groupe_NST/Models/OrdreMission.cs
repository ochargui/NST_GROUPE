using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class OrdreMission
    {
        [Key]
        public int idOrdreMission { get; set; }
        public string FonctionOrdreMission { get; set; }
        public DateTime dateDebutOrdreMission { get; set; }
        public DateTime dateFinOrdreMission { get; set; }
        public int idMission { get; set; }


    }
}
