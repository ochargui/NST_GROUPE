using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Groupe_NST.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CRA",
                columns: table => new
                {
                    idCRA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    dure_conge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conge_paye = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    conge_non_paye = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRA", x => x.idCRA);
                });

            migrationBuilder.CreateTable(
                name: "EtatActivite",
                columns: table => new
                {
                    idEActivite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtatActivite", x => x.idEActivite);
                });

            migrationBuilder.CreateTable(
                name: "EtatMission",
                columns: table => new
                {
                    idEtatMission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etatMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isValidEtatMission = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionEtatMission = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtatMission", x => x.idEtatMission);
                });

            migrationBuilder.CreateTable(
                name: "EtatProjet",
                columns: table => new
                {
                    idEProjet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtatProjet", x => x.idEProjet);
                });

            migrationBuilder.CreateTable(
                name: "EtatTache",
                columns: table => new
                {
                    idEtatTache = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    etatTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionEtatTache = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtatTache", x => x.idEtatTache);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Type_Projet",
                columns: table => new
                {
                    idTProjet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Projet", x => x.idTProjet);
                });

            migrationBuilder.CreateTable(
                name: "typeAbsence",
                columns: table => new
                {
                    idTAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeAbsence", x => x.idTAbsence);
                });

            migrationBuilder.CreateTable(
                name: "typeActivite",
                columns: table => new
                {
                    idTActivite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeActivite", x => x.idTActivite);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    idCRA = table.Column<int>(type: "int", nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false),
                    CRAidCRA = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_CRA_CRAidCRA",
                        column: x => x.CRAidCRA,
                        principalTable: "CRA",
                        principalColumn: "idCRA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Role_roleid",
                        column: x => x.roleid,
                        principalTable: "Role",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activite",
                columns: table => new
                {
                    idActivite = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomActivite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebutAct = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateCreactionAct = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isValid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idtypeActivite = table.Column<int>(type: "int", nullable: false),
                    idEtatActivite = table.Column<int>(type: "int", nullable: false),
                    EtatActiviteidEActivite = table.Column<int>(type: "int", nullable: true),
                    TypeActiviteidTActivite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activite", x => x.idActivite);
                    table.ForeignKey(
                        name: "FK_Activite_EtatActivite_EtatActiviteidEActivite",
                        column: x => x.EtatActiviteidEActivite,
                        principalTable: "EtatActivite",
                        principalColumn: "idEActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activite_typeActivite_TypeActiviteidTActivite",
                        column: x => x.TypeActiviteidTActivite,
                        principalTable: "typeActivite",
                        principalColumn: "idTActivite",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Absence",
                columns: table => new
                {
                    idAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtatAbsence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebutAbsence = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateFin = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateRetourAbsence = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isValid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idUsers = table.Column<int>(type: "int", nullable: false),
                    idtypeAbsence = table.Column<int>(type: "int", nullable: false),
                    idEtatAbsence = table.Column<int>(type: "int", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: true),
                    typeAbsenceidTAbsence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absence", x => x.idAbsence);
                    table.ForeignKey(
                        name: "FK_Absence_typeAbsence_typeAbsenceidTAbsence",
                        column: x => x.typeAbsenceidTAbsence,
                        principalTable: "typeAbsence",
                        principalColumn: "idTAbsence",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absence_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    idNot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUserAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserReception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateNotif = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    idUsers = table.Column<int>(type: "int", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.idNot);
                    table.ForeignKey(
                        name: "FK_Notification_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pointage",
                columns: table => new
                {
                    idPointage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateConnexion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeconnexion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    idUsers = table.Column<int>(type: "int", nullable: false),
                    Usersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pointage", x => x.idPointage);
                    table.ForeignKey(
                        name: "FK_Pointage_Users_Usersid",
                        column: x => x.Usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    idProjet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomProjet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebutA = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateCreaction = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isValid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idActivite = table.Column<int>(type: "int", nullable: false),
                    idtypeProjet = table.Column<int>(type: "int", nullable: false),
                    idEtatProjet = table.Column<int>(type: "int", nullable: false),
                    ActiviteidActivite = table.Column<int>(type: "int", nullable: true),
                    EtatProjetidEProjet = table.Column<int>(type: "int", nullable: true),
                    Type_ProjetidTProjet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.idProjet);
                    table.ForeignKey(
                        name: "FK_Projet_Activite_ActiviteidActivite",
                        column: x => x.ActiviteidActivite,
                        principalTable: "Activite",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projet_EtatProjet_EtatProjetidEProjet",
                        column: x => x.EtatProjetidEProjet,
                        principalTable: "EtatProjet",
                        principalColumn: "idEProjet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projet_Type_Projet_Type_ProjetidTProjet",
                        column: x => x.Type_ProjetidTProjet,
                        principalTable: "Type_Projet",
                        principalColumn: "idTProjet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    idMission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateDebutMission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateFinMission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateCreationMission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idEtatMission = table.Column<int>(type: "int", nullable: false),
                    idProjet = table.Column<int>(type: "int", nullable: false),
                    idActivite = table.Column<int>(type: "int", nullable: false),
                    ActiviteidActivite = table.Column<int>(type: "int", nullable: true),
                    EtatMissionidEtatMission = table.Column<int>(type: "int", nullable: true),
                    ProjetidProjet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.idMission);
                    table.ForeignKey(
                        name: "FK_Mission_Activite_ActiviteidActivite",
                        column: x => x.ActiviteidActivite,
                        principalTable: "Activite",
                        principalColumn: "idActivite",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mission_EtatMission_EtatMissionidEtatMission",
                        column: x => x.EtatMissionidEtatMission,
                        principalTable: "EtatMission",
                        principalColumn: "idEtatMission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mission_Projet_ProjetidProjet",
                        column: x => x.ProjetidProjet,
                        principalTable: "Projet",
                        principalColumn: "idProjet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdreMission",
                columns: table => new
                {
                    idOrdreMission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FonctionOrdreMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateDebutOrdreMission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateFinOrdreMission = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idMission = table.Column<int>(type: "int", nullable: false),
                    MissionidMission = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdreMission", x => x.idOrdreMission);
                    table.ForeignKey(
                        name: "FK_OrdreMission_Mission_MissionidMission",
                        column: x => x.MissionidMission,
                        principalTable: "Mission",
                        principalColumn: "idMission",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tache",
                columns: table => new
                {
                    idTache = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionTache = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isValidTache = table.Column<bool>(type: "bit", nullable: false),
                    dateDebutTache = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateFinTache = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateCreationTache = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estimationTache = table.Column<float>(type: "real", nullable: false),
                    workDoneTache = table.Column<bool>(type: "bit", nullable: false),
                    idProjet = table.Column<int>(type: "int", nullable: false),
                    idMession = table.Column<int>(type: "int", nullable: false),
                    idEtatTache = table.Column<int>(type: "int", nullable: false),
                    EtatTacheidEtatTache = table.Column<int>(type: "int", nullable: true),
                    MissionidMission = table.Column<int>(type: "int", nullable: true),
                    ProjetidProjet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tache", x => x.idTache);
                    table.ForeignKey(
                        name: "FK_Tache_EtatTache_EtatTacheidEtatTache",
                        column: x => x.EtatTacheidEtatTache,
                        principalTable: "EtatTache",
                        principalColumn: "idEtatTache",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tache_Mission_MissionidMission",
                        column: x => x.MissionidMission,
                        principalTable: "Mission",
                        principalColumn: "idMission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tache_Projet_ProjetidProjet",
                        column: x => x.ProjetidProjet,
                        principalTable: "Projet",
                        principalColumn: "idProjet",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Absence_typeAbsenceidTAbsence",
                table: "Absence",
                column: "typeAbsenceidTAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_Absence_Usersid",
                table: "Absence",
                column: "Usersid");

            migrationBuilder.CreateIndex(
                name: "IX_Activite_EtatActiviteidEActivite",
                table: "Activite",
                column: "EtatActiviteidEActivite");

            migrationBuilder.CreateIndex(
                name: "IX_Activite_TypeActiviteidTActivite",
                table: "Activite",
                column: "TypeActiviteidTActivite");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_ActiviteidActivite",
                table: "Mission",
                column: "ActiviteidActivite");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_EtatMissionidEtatMission",
                table: "Mission",
                column: "EtatMissionidEtatMission");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_ProjetidProjet",
                table: "Mission",
                column: "ProjetidProjet");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Usersid",
                table: "Notification",
                column: "Usersid");

            migrationBuilder.CreateIndex(
                name: "IX_OrdreMission_MissionidMission",
                table: "OrdreMission",
                column: "MissionidMission");

            migrationBuilder.CreateIndex(
                name: "IX_Pointage_Usersid",
                table: "Pointage",
                column: "Usersid");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_ActiviteidActivite",
                table: "Projet",
                column: "ActiviteidActivite");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_EtatProjetidEProjet",
                table: "Projet",
                column: "EtatProjetidEProjet");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_Type_ProjetidTProjet",
                table: "Projet",
                column: "Type_ProjetidTProjet");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_EtatTacheidEtatTache",
                table: "Tache",
                column: "EtatTacheidEtatTache");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_MissionidMission",
                table: "Tache",
                column: "MissionidMission");

            migrationBuilder.CreateIndex(
                name: "IX_Tache_ProjetidProjet",
                table: "Tache",
                column: "ProjetidProjet");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CRAidCRA",
                table: "Users",
                column: "CRAidCRA");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleid",
                table: "Users",
                column: "roleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absence");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrdreMission");

            migrationBuilder.DropTable(
                name: "Pointage");

            migrationBuilder.DropTable(
                name: "Tache");

            migrationBuilder.DropTable(
                name: "typeAbsence");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EtatTache");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "CRA");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "EtatMission");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Activite");

            migrationBuilder.DropTable(
                name: "EtatProjet");

            migrationBuilder.DropTable(
                name: "Type_Projet");

            migrationBuilder.DropTable(
                name: "EtatActivite");

            migrationBuilder.DropTable(
                name: "typeActivite");
        }
    }
}
