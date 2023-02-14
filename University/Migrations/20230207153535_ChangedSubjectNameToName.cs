using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Migrations
{
    public partial class ChangedSubjectNameToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Subjects",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subjects",
                newName: "SubjectName");
        }
    }
}
