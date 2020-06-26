using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Hackathon_Team5_19_21.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amministratori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Cognome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PrimaPassword = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amministratori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonaleFitstic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Cognome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PrimaPassword = table.Column<bool>(nullable: false),
                    DataAssunzione = table.Column<DateTime>(nullable: false),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    Docente = table.Column<bool>(nullable: false),
                    Tutor = table.Column<bool>(nullable: false),
                    Organizzatore = table.Column<bool>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    IdAmministratore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaleFitstic", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Amministratore_PersonaFitstic",
                        column: x => x.IdAmministratore,
                        principalTable: "Amministratori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    IdProvincia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citta", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Provincia_Citta",
                        column: x => x.IdProvincia,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    AnnoInizio = table.Column<int>(nullable: false),
                    AnnoFine = table.Column<int>(nullable: false),
                    IdCitta = table.Column<int>(nullable: false),
                    IdOrganizzatore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Corso_Citta",
                        column: x => x.IdCitta,
                        principalTable: "Citta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Corso_Organizzatore",
                        column: x => x.IdOrganizzatore,
                        principalTable: "PersonaleFitstic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Cognome = table.Column<string>(nullable: false),
                    Indirizzo = table.Column<string>(nullable: false),
                    Civico = table.Column<string>(nullable: false),
                    TipoDiploma = table.Column<int>(nullable: false),
                    AnnoDiploma = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: false),
                    DataNascita = table.Column<DateTime>(nullable: false),
                    IdCitta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Studente_Citta",
                        column: x => x.IdCitta,
                        principalTable: "Citta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moduli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    DataInizio = table.Column<DateTime>(nullable: false),
                    DataFine = table.Column<DateTime>(nullable: true),
                    Materia = table.Column<string>(nullable: false),
                    IdCorso = table.Column<int>(nullable: false),
                    IdTutor = table.Column<int>(nullable: false),
                    IdDocente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduli", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Modulo_Corso",
                        column: x => x.IdCorso,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Modulo_Docente",
                        column: x => x.IdDocente,
                        principalTable: "PersonaleFitstic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Modulo_Tutor",
                        column: x => x.IdTutor,
                        principalTable: "PersonaleFitstic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentiIscritti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataIscrizione = table.Column<DateTime>(nullable: false),
                    VotoFinale = table.Column<int>(nullable: false),
                    Ritirato = table.Column<bool>(nullable: false),
                    NonAmmesso = table.Column<bool>(nullable: false),
                    IdStudente = table.Column<int>(nullable: false),
                    IdCorso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentiIscritti", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Corso_StudenteIscritto",
                        column: x => x.IdCorso,
                        principalTable: "Corsi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Studente_StudenteIscritto",
                        column: x => x.IdStudente,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Esami",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Voto = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: true),
                    IdModulo = table.Column<int>(nullable: false),
                    IdStudenteIscritto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Esami", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Modulo_Esame",
                        column: x => x.IdModulo,
                        principalTable: "Moduli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "ForeignKey_Esame_StudenteIscritto",
                        column: x => x.IdStudenteIscritto,
                        principalTable: "StudentiIscritti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amministratori_Email",
                table: "Amministratori",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citta_IdProvincia",
                table: "Citta",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_IdCitta",
                table: "Corsi",
                column: "IdCitta");

            migrationBuilder.CreateIndex(
                name: "IX_Corsi_IdOrganizzatore",
                table: "Corsi",
                column: "IdOrganizzatore");

            migrationBuilder.CreateIndex(
                name: "IX_Esami_IdModulo",
                table: "Esami",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_Esami_IdStudenteIscritto_IdModulo",
                table: "Esami",
                columns: new[] { "IdStudenteIscritto", "IdModulo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moduli_IdCorso",
                table: "Moduli",
                column: "IdCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Moduli_IdDocente",
                table: "Moduli",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Moduli_IdTutor",
                table: "Moduli",
                column: "IdTutor");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaleFitstic_Email",
                table: "PersonaleFitstic",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonaleFitstic_IdAmministratore",
                table: "PersonaleFitstic",
                column: "IdAmministratore");

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_IdCitta",
                table: "Studenti",
                column: "IdCitta");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiIscritti_IdCorso",
                table: "StudentiIscritti",
                column: "IdCorso");

            migrationBuilder.CreateIndex(
                name: "IX_StudentiIscritti_IdStudente",
                table: "StudentiIscritti",
                column: "IdStudente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Esami");

            migrationBuilder.DropTable(
                name: "Moduli");

            migrationBuilder.DropTable(
                name: "StudentiIscritti");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "PersonaleFitstic");

            migrationBuilder.DropTable(
                name: "Citta");

            migrationBuilder.DropTable(
                name: "Amministratori");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
