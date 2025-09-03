using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizzando.Migrations
{
    /// <inheritdoc />
    public partial class couseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Discipline_DisciplineId",
                table: "Question");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineId",
                table: "Question",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoursesId",
                table: "Discipline",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionsId",
                table: "Discipline",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "Course",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Discipline_DisciplineId",
                table: "Question",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Discipline_DisciplineId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "QuestionsId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Course");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplineId",
                table: "Question",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Discipline_DisciplineId",
                table: "Question",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id");
        }
    }
}
