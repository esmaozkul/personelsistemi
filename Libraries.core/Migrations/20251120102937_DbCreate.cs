using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libraries.core.Migrations
{
    /// <inheritdoc />
    public partial class DbCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MezuniyetTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelDetay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<long>(type: "bigint", nullable: false),
                    AnneAdi = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BabaAdi = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    KanGrubu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailAdresi = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelDetay_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelDetay_PersonelId",
                table: "PersonelDetay",
                column: "PersonelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelDetay");

            migrationBuilder.DropTable(
                name: "Personel");
        }
    }
}
