using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSAContestWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocSearch",
                columns: table => new
                {
                    DocSearchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInvoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirdFindLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorApt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SumGifted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxReceipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftConsideration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocSearch", x => x.DocSearchId);
                });

            migrationBuilder.InsertData(
                table: "DocSearch",
                columns: new[] { "DocSearchId", "BirdFindLocation", "DateInvoice", "DonorAddress", "DonorApt", "DonorCity", "DonorEmail", "DonorName", "DonorPostal", "DonorTel", "GiftConsideration", "ReceiverBy", "StoragePath", "SumGifted", "TaxReceipt" },
                values: new object[] { 1, "Dallas", "05/09/2022", "", "", "", "", "Kone", "", "", "", "nape", "kljghdgfsgfjhjh", "", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocSearch");
        }
    }
}
