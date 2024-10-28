using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LimitsAndTransactionsApi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "api_key",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    encrypted_api_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_key", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    currency_pair = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    close = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    datetime_rate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "api_key",
                columns: new[] { "Id", "active", "created_time", "description", "encrypted_api_path" },
                values: new object[] { new Guid("d05eca88-8ddb-4576-b2a8-7415f358364a"), true, new DateTimeOffset(new DateTime(2024, 10, 27, 10, 19, 1, 124, DateTimeKind.Unspecified).AddTicks(9356), new TimeSpan(0, 0, 0, 0, 0)), "twelve", "F5z8tDG0AI0Xon4zLcuLZsXXPAbiMkYDQJHBzYUOLXGHRFDqq4AWvWxil+mRt0+w" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_key");

            migrationBuilder.DropTable(
                name: "exchange_rates");
        }
    }
}
