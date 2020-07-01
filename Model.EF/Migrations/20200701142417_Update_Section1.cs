using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.EF.Migrations
{
    public partial class Update_Section1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Alter Table Section Add Constraint FK_Section_Student_DelegateId Foreign Key (DelegateId) References Student(Id)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Alter Table Section Drop Constraint FK_Section_Student_DelegateId");
        }
    }
}
