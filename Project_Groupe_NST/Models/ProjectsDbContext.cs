
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Groupe_NST.Models;

namespace Project_Groupe_NST.Models
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        { }
        public DbSet<Absence> Absence{ get; set; }
        public DbSet<CRA> CRA { get; set; }
        public DbSet<Pointage> Pointage { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<typeAbsence> typeAbsence { get; set; }
        public DbSet<Users> Users { get; set; }
         public DbSet<Projet> Projet{ get; set; }
        public DbSet<Activite> Activite { get; set; }
        public DbSet<Type_Projet> Type_Projet { get; set; }
        public DbSet<TypeActivite> typeActivite { get; set; }
        public DbSet<EtatActivite> EtatActivite { get; set; }
        public DbSet<EtatProjet> EtatProjet { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<EtatMission> EtatMission { get; set; }
        public DbSet<EtatTache> EtatTache { get; set; }
        public DbSet<OrdreMission> OrdreMission { get; set; }
        public DbSet<Tache> Tache { get; set; }
        public DbSet<Project_Groupe_NST.Models.EtatAbsence> EtatAbsence { get; set; }
    }
}
