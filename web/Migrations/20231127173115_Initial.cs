using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avtor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_rojstva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avtor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letnica_izdaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zalozba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stevilo_strani = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uporabnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uporabnisko_ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    geslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_rojstva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime_zanra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga_avtor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    knjigaId = table.Column<int>(type: "int", nullable: false),
                    avtorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga_avtor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjiga_avtor_Avtor_avtorId",
                        column: x => x.avtorId,
                        principalTable: "Avtor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjiga_avtor_Knjiga_knjigaId",
                        column: x => x.knjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izposoja_nakup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum_izposoje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Datum_vrnitve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    knjigaId = table.Column<int>(type: "int", nullable: false),
                    uporabnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izposoja_nakup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izposoja_nakup_Knjiga_knjigaId",
                        column: x => x.knjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izposoja_nakup_Uporabnik_uporabnikID",
                        column: x => x.uporabnikID,
                        principalTable: "Uporabnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocene_komentarji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum_ocene = table.Column<DateTime>(type: "datetime2", nullable: false),
                    knjigaId = table.Column<int>(type: "int", nullable: false),
                    uporabnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene_komentarji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocene_komentarji_Knjiga_knjigaId",
                        column: x => x.knjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocene_komentarji_Uporabnik_uporabnikID",
                        column: x => x.uporabnikID,
                        principalTable: "Uporabnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Knjiga_zanr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    knjigaId = table.Column<int>(type: "int", nullable: false),
                    zanrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjiga_zanr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knjiga_zanr_Knjiga_knjigaId",
                        column: x => x.knjigaId,
                        principalTable: "Knjiga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Knjiga_zanr_Zanr_zanrId",
                        column: x => x.zanrId,
                        principalTable: "Zanr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izposoja_nakup_knjigaId",
                table: "Izposoja_nakup",
                column: "knjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Izposoja_nakup_uporabnikID",
                table: "Izposoja_nakup",
                column: "uporabnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_avtor_avtorId",
                table: "Knjiga_avtor",
                column: "avtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_avtor_knjigaId",
                table: "Knjiga_avtor",
                column: "knjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_zanr_knjigaId",
                table: "Knjiga_zanr",
                column: "knjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjiga_zanr_zanrId",
                table: "Knjiga_zanr",
                column: "zanrId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_komentarji_knjigaId",
                table: "Ocene_komentarji",
                column: "knjigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_komentarji_uporabnikID",
                table: "Ocene_komentarji",
                column: "uporabnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izposoja_nakup");

            migrationBuilder.DropTable(
                name: "Knjiga_avtor");

            migrationBuilder.DropTable(
                name: "Knjiga_zanr");

            migrationBuilder.DropTable(
                name: "Ocene_komentarji");

            migrationBuilder.DropTable(
                name: "Avtor");

            migrationBuilder.DropTable(
                name: "Zanr");

            migrationBuilder.DropTable(
                name: "Knjiga");

            migrationBuilder.DropTable(
                name: "Uporabnik");
        }
    }
}
