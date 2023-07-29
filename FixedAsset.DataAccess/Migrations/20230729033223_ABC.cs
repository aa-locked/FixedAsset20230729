using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixedAsset.DataAccess.Migrations
{
    public partial class ABC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tFAMtrlGrp",
                columns: table => new
                {
                    FAMtrlGrpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrpShortDesc = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GrpDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActStatus = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tFAMtrlGrp", x => x.FAMtrlGrpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tFAMtrlGrp");
        }
    }
}
