using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.EF.Migrations
{
    public partial class Update_Student3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateCheckConstraint(
                name: "CK_Student_YearResult",
                table: "Students",
                sql: "YearResult Between 0 and 20");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_YearResult",
                table: "Students");
        }
    }
}
