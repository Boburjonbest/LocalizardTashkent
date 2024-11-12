﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Localizard.Migrations
{
    /// <inheritdoc />
    public partial class LargeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDetailTranslation");

            migrationBuilder.DropTable(
                name: "ProjectInfoLanguage");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LanguageId",
                table: "Projects",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Languages_LanguageId",
                table: "Projects",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Languages_LanguageId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LanguageId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectDetailTranslation",
                columns: table => new
                {
                    ProjectDetailId = table.Column<int>(type: "integer", nullable: false),
                    TranslationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDetailTranslation", x => new { x.ProjectDetailId, x.TranslationId });
                    table.ForeignKey(
                        name: "FK_ProjectDetailTranslation_ProjectDetails_ProjectDetailId",
                        column: x => x.ProjectDetailId,
                        principalTable: "ProjectDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDetailTranslation_Translation_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectInfoLanguage",
                columns: table => new
                {
                    ProjectInfoId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectInfoLanguage", x => new { x.ProjectInfoId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ProjectInfoLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectInfoLanguage_Projects_ProjectInfoId",
                        column: x => x.ProjectInfoId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDetailTranslation_TranslationId",
                table: "ProjectDetailTranslation",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectInfoLanguage_LanguageId",
                table: "ProjectInfoLanguage",
                column: "LanguageId");
        }
    }
}
