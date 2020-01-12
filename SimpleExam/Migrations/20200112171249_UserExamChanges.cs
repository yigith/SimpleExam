using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleExam.Migrations
{
    public partial class UserExamChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveTime",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ExtraTimeAllowed",
                table: "Exams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRetakeable",
                table: "Exams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartTimeFlexible",
                table: "Exams",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveTime",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "ExtraTimeAllowed",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IsRetakeable",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IsStartTimeFlexible",
                table: "Exams");
        }
    }
}
