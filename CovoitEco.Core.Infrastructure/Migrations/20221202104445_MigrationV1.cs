using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovoitEco.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annonce",
                columns: table => new
                {
                    ANNId = table.Column<int>(name: "ANN_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ANNDatePublication = table.Column<DateTime>(name: "ANN_DatePublication", type: "datetime2", nullable: false),
                    ANNPrix = table.Column<float>(name: "ANN_Prix", type: "real", nullable: false),
                    ANNLocaliteDepart = table.Column<string>(name: "ANN_LocaliteDepart", type: "nvarchar(max)", nullable: false),
                    ANNLocaliteArrive = table.Column<string>(name: "ANN_LocaliteArrive", type: "nvarchar(max)", nullable: false),
                    ANNHeureDepart = table.Column<DateTime>(name: "ANN_HeureDepart", type: "datetime2", nullable: false),
                    ANNHeureArrive = table.Column<DateTime>(name: "ANN_HeureArrive", type: "datetime2", nullable: false),
                    ANNVEHId = table.Column<int>(name: "ANN_VEH_Id", type: "int", nullable: false),
                    ANNSTATANNId = table.Column<int>(name: "ANN_STATANN_Id", type: "int", nullable: false),
                    ANNOPTId = table.Column<int>(name: "ANN_OPT_Id", type: "int", nullable: false),
                    ANNUTLId = table.Column<int>(name: "ANN_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annonce", x => x.ANNId);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    FACTId = table.Column<int>(name: "FACT_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FACTDateCreation = table.Column<DateTime>(name: "FACT_DateCreation", type: "datetime2", nullable: false),
                    FACTDatePayment = table.Column<DateTime>(name: "FACT_DatePayment", type: "datetime2", nullable: false),
                    FACTResolus = table.Column<bool>(name: "FACT_Resolus", type: "bit", nullable: false),
                    FACTRESId = table.Column<int>(name: "FACT_RES_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.FACTId);
                });

            migrationBuilder.CreateTable(
                name: "Modele",
                columns: table => new
                {
                    MODid = table.Column<int>(name: "MOD_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MODMarque = table.Column<string>(name: "MOD_Marque", type: "nvarchar(max)", nullable: false),
                    MODLibelle = table.Column<string>(name: "MOD_Libelle", type: "nvarchar(max)", nullable: false),
                    MODNombrePlace = table.Column<int>(name: "MOD_NombrePlace", type: "int", nullable: false),
                    MODNormeEuro = table.Column<int>(name: "MOD_NormeEuro", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modele", x => x.MODid);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NOTId = table.Column<int>(name: "NOT_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOTCotation = table.Column<float>(name: "NOT_Cotation", type: "real", nullable: false),
                    NOTUTLId = table.Column<int>(name: "NOT_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NOTId);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NOTIFId = table.Column<int>(name: "NOTIF_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ROLUTLId = table.Column<int>(name: "ROL_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NOTIFId);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    OPTId = table.Column<int>(name: "OPT_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPTLibelle = table.Column<string>(name: "OPT_Libelle", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OPTId);
                });

            migrationBuilder.CreateTable(
                name: "Recherche",
                columns: table => new
                {
                    RECHId = table.Column<int>(name: "RECH_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECHDateEnregistrement = table.Column<DateTime>(name: "RECH_DateEnregistrement", type: "datetime2", nullable: false),
                    RECHLocaliteDepart = table.Column<string>(name: "RECH_LocaliteDepart", type: "nvarchar(max)", nullable: false),
                    RECHLocaliteArrvie = table.Column<string>(name: "RECH_LocaliteArrvie", type: "nvarchar(max)", nullable: false),
                    RECHHeureDepart = table.Column<DateTime>(name: "RECH_HeureDepart", type: "datetime2", nullable: false),
                    RECHUTLId = table.Column<int>(name: "RECH_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recherche", x => x.RECHId);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    RESId = table.Column<int>(name: "RES_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RESDateReservation = table.Column<DateTime>(name: "RES_DateReservation", type: "datetime2", nullable: false),
                    RESANNId = table.Column<int>(name: "RES_ANN_Id", type: "int", nullable: false),
                    RESSTATRESId = table.Column<int>(name: "RES_STATRES_Id", type: "int", nullable: false),
                    RESUTLId = table.Column<int>(name: "RES_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.RESId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ROLId = table.Column<int>(name: "ROL_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ROLLibelle = table.Column<string>(name: "ROL_Libelle", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ROLId);
                });

            migrationBuilder.CreateTable(
                name: "StatutAnnonce",
                columns: table => new
                {
                    STATANNId = table.Column<int>(name: "STATANN_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATANNLibelle = table.Column<int>(name: "STATANN_Libelle", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutAnnonce", x => x.STATANNId);
                });

            migrationBuilder.CreateTable(
                name: "StatutResevation",
                columns: table => new
                {
                    STATRESId = table.Column<int>(name: "STATRES_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATRESLibelle = table.Column<string>(name: "STATRES_Libelle", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutResevation", x => x.STATRESId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    UTLId = table.Column<int>(name: "UTL_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UTLNom = table.Column<string>(name: "UTL_Nom", type: "nvarchar(max)", nullable: false),
                    UTLPrenom = table.Column<string>(name: "UTL_Prenom", type: "nvarchar(max)", nullable: false),
                    UTLTelephone = table.Column<string>(name: "UTL_Mail", type: "nvarchar(max)", nullable: false),
                    UTLROLId = table.Column<int>(name: "UTL_IdAuth0", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.UTLId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    VEHId = table.Column<int>(name: "VEH_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VEHImmatriculation = table.Column<string>(name: "VEH_Immatriculation", type: "nvarchar(max)", nullable: false),
                    VEHCouleur = table.Column<string>(name: "VEH_Couleur", type: "nvarchar(max)", nullable: false),
                    VEHMODId = table.Column<int>(name: "VEH_MOD_Id", type: "int", nullable: false),
                    VEHUTLId = table.Column<int>(name: "VEH_UTL_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.VEHId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Annonce");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Modele");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "Recherche");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "StatutAnnonce");

            migrationBuilder.DropTable(
                name: "StatutResevation");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Vehicule");
        }
    }
}
