using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Tache
    {
        [Key]
        public int idTache { get; set; }
        public string nomTache { get; set; }
        public string descriptionTache { get; set; }
        public bool isValidTache { get; set; }
        public DateTime dateDebutTache { get; set; }
        public DateTime dateFinTache { get; set; }
        public DateTime dateCreationTache { get; set; }
        public float estimationTache { get; set; }
        public bool workDoneTache { get; set; }
        public int idProjet { get; set; }
        public int idMession{ get; set; }
        public int idEtatTache { get; set; }

    }
}
