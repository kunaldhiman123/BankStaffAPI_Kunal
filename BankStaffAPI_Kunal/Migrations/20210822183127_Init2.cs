using Microsoft.EntityFrameworkCore.Migrations;

namespace BankStaffAPI_Kunal.Data.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationID",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DesignationID",
                table: "Staffs",
                column: "DesignationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Designations_DesignationID",
                table: "Staffs",
                column: "DesignationID",
                principalTable: "Designations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Designations_DesignationID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DesignationID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DesignationID",
                table: "Staffs");
        }
    }
}
