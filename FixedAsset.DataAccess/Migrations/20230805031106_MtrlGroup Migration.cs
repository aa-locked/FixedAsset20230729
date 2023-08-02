using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixedAsset.DataAccess.Migrations
{
    public partial class MtrlGroupMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tFAMtrlSubGrp",
                columns: table => new
                {
                    FAMtrlSubGrpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FAMtrlGrpId = table.Column<int>(type: "int", nullable: false),
                    SubGrpShortDesc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SubGrpDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActStatus = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tFAMtrlSubGrp", x => x.FAMtrlSubGrpId);
                    table.ForeignKey(
                        name: "FK_tFAMtrlSubGrp_tFAMtrlGrp_FAMtrlGrpId",
                        column: x => x.FAMtrlGrpId,
                        principalTable: "tFAMtrlGrp",
                        principalColumn: "FAMtrlGrpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tFAMtrlSubGrp_FAMtrlGrpId",
                table: "tFAMtrlSubGrp",
                column: "FAMtrlGrpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tFAMtrlSubGrp");
        }
    }
}
