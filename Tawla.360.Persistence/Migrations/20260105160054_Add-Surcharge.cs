using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tawla._360.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSurcharge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MaxDiscountLimit",
                table: "Discounts",
                type: "numeric",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Surcharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AmountType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsTaxable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surcharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surcharges_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurchargeTranslations",
                columns: table => new
                {
                    PropertyName = table.Column<string>(type: "text", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    SurchargeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurchargeTranslations", x => new { x.SurchargeId, x.PropertyName, x.LanguageCode });
                    table.ForeignKey(
                        name: "FK_SurchargeTranslations_Surcharges_SurchargeId",
                        column: x => x.SurchargeId,
                        principalTable: "Surcharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surcharges_BranchId",
                table: "Surcharges",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurchargeTranslations");

            migrationBuilder.DropTable(
                name: "Surcharges");

            migrationBuilder.DropColumn(
                name: "MaxDiscountLimit",
                table: "Discounts");
        }
    }
}
