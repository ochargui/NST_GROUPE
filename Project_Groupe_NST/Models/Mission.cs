using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Groupe_NST.Models
{
    public class Mission
    {[Key]
     public int idMission { get; set; }
     public string nomMission { get; set; }
     public string descriptionMission { get; set; }
     public DateTime dateDebutMission { get; set; }
     public DateTime dateFinMission { get; set; }
     public DateTime dateCreationMission { get; set; }
     public int idEtatMission { get; set; }
     public int idProjet { get; set; }
     public int idActivite { get; set; }
     public ICollection<OrdreMission> OrdreMissions { get; set; }
     public ICollection<Tache> Taches { get; set; }


    }
}
