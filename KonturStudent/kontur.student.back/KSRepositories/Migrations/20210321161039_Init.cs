#region using

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#endregion

namespace KSRepositories.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Mentors",
                table => new
                {
                    Id = table.Column<string>("text", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Mentors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Projects",
                table => new
                {
                    Id = table.Column<string>("text", nullable: false),
                    Title = table.Column<string>("text", nullable: false),
                    ShortDescription = table.Column<string>("text", nullable: false),
                    BeginningDate = table.Column<DateTimeOffset>("timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>("timestamp with time zone", nullable: false),
                    LongDescription = table.Column<string>("text", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Projects", x => x.Id); });

            migrationBuilder.CreateTable(
                "Technologies",
                table => new
                {
                    Id = table.Column<string>("text", nullable: false),
                    Title = table.Column<string>("text", nullable: true),
                    Icon = table.Column<byte[]>("bytea", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Technologies", x => x.Id); });

            migrationBuilder.CreateTable(
                "MentorProject",
                table => new
                {
                    MentorsId = table.Column<string>("text", nullable: false),
                    ProjectsId = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorProject", x => new {x.MentorsId, x.ProjectsId});
                    table.ForeignKey(
                        "FK_MentorProject_Mentors_MentorsId",
                        x => x.MentorsId,
                        "Mentors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_MentorProject_Projects_ProjectsId",
                        x => x.ProjectsId,
                        "Projects",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ProjectTechnology",
                table => new
                {
                    ProjectsId = table.Column<string>("text", nullable: false),
                    TechnologiesId = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnology", x => new {x.ProjectsId, x.TechnologiesId});
                    table.ForeignKey(
                        "FK_ProjectTechnology_Projects_ProjectsId",
                        x => x.ProjectsId,
                        "Projects",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ProjectTechnology_Technologies_TechnologiesId",
                        x => x.TechnologiesId,
                        "Technologies",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_MentorProject_ProjectsId",
                "MentorProject",
                "ProjectsId");

            migrationBuilder.CreateIndex(
                "IX_ProjectTechnology_TechnologiesId",
                "ProjectTechnology",
                "TechnologiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "MentorProject");

            migrationBuilder.DropTable(
                "ProjectTechnology");

            migrationBuilder.DropTable(
                "Mentors");

            migrationBuilder.DropTable(
                "Projects");

            migrationBuilder.DropTable(
                "Technologies");
        }
    }
}