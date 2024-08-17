using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2406ede0-d9cf-4b68-9b50-4d80d1ea32ee"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7664a382-88fc-4097-b1af-9b47c9a5be53"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dd2fe52b-59f4-4f31-958d-5e455b52c9bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2f62abd7-2bf7-4541-80fc-2ce434b97944"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4cc739c9-f727-4e3a-a027-7d148f15bfa0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("605ffffe-6cfa-4c05-805f-5900f668827b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6337285d-2293-4806-adf2-40dda746ca52"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("93ea44e5-1f57-46d6-bcf9-8696e85aa066"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c9c576b6-55db-48e7-8e4d-57190d81c2e1"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInByte = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00a96cb6-a018-4667-8a16-1c40f82cefe2"), "Easy" },
                    { new Guid("62e4b818-20f3-4d10-89d3-ffd3ffb79d20"), "Medium" },
                    { new Guid("6cf5fe11-aebe-4dcd-addd-baafe65cd8f2"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0943b078-7003-4c0a-b108-f75bd36d6438"), "BOP", "Bay Of Plenty", null },
                    { new Guid("4032aaa3-60e2-4f28-b98d-0b3ec40710cb"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("4ea59c56-0294-4546-99e2-db867a417972"), "NTL", "Northland", null },
                    { new Guid("6ae07a6c-633e-403b-8c3e-ea1be60e5398"), "STL", "Southland", null },
                    { new Guid("c26e1ce0-d8de-459c-8223-00f3115a0f95"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("de557756-c0c5-437f-a8b1-37264a0f2833"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("00a96cb6-a018-4667-8a16-1c40f82cefe2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("62e4b818-20f3-4d10-89d3-ffd3ffb79d20"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6cf5fe11-aebe-4dcd-addd-baafe65cd8f2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0943b078-7003-4c0a-b108-f75bd36d6438"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4032aaa3-60e2-4f28-b98d-0b3ec40710cb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4ea59c56-0294-4546-99e2-db867a417972"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6ae07a6c-633e-403b-8c3e-ea1be60e5398"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c26e1ce0-d8de-459c-8223-00f3115a0f95"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("de557756-c0c5-437f-a8b1-37264a0f2833"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2406ede0-d9cf-4b68-9b50-4d80d1ea32ee"), "Hard" },
                    { new Guid("7664a382-88fc-4097-b1af-9b47c9a5be53"), "Easy" },
                    { new Guid("dd2fe52b-59f4-4f31-958d-5e455b52c9bc"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2f62abd7-2bf7-4541-80fc-2ce434b97944"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("4cc739c9-f727-4e3a-a027-7d148f15bfa0"), "NTL", "Northland", null },
                    { new Guid("605ffffe-6cfa-4c05-805f-5900f668827b"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6337285d-2293-4806-adf2-40dda746ca52"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("93ea44e5-1f57-46d6-bcf9-8696e85aa066"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c9c576b6-55db-48e7-8e4d-57190d81c2e1"), "STL", "Southland", null }
                });
        }
    }
}
