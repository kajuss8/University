using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Migrations
{
    public partial class changedletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmentSubjects_Departments_DepartmentId",
                table: "departmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_departmentSubjects_Subjects_SubjectId",
                table: "departmentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects");

            migrationBuilder.RenameTable(
                name: "departmentSubjects",
                newName: "DepartmentSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_departmentSubjects_SubjectId",
                table: "DepartmentSubjects",
                newName: "IX_DepartmentSubjects_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSubjects",
                table: "DepartmentSubjects",
                columns: new[] { "DepartmentId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectId",
                table: "DepartmentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Departments_DepartmentId",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectId",
                table: "DepartmentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSubjects",
                table: "DepartmentSubjects");

            migrationBuilder.RenameTable(
                name: "DepartmentSubjects",
                newName: "departmentSubjects");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentSubjects_SubjectId",
                table: "departmentSubjects",
                newName: "IX_departmentSubjects_SubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentSubjects",
                table: "departmentSubjects",
                columns: new[] { "DepartmentId", "SubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_departmentSubjects_Departments_DepartmentId",
                table: "departmentSubjects",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departmentSubjects_Subjects_SubjectId",
                table: "departmentSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
