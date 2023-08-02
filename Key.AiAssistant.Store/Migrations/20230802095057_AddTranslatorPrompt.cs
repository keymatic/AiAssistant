using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Key.AiAssistant.Store.Migrations
{
    /// <inheritdoc />
    public partial class AddTranslatorPrompt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Messages", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, "System", new DateTimeOffset(new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new[] { "I want you to act as an English-to-Russian translator, spelling corrector and improver. I will speak to you in English and you will translate it to Russian and answer in the corrected and improved version of my text. I want you to replace my simplified A0-level words and sentences with more beautiful and elegant, upper level Russian words and sentences. Keep the meaning same, but make them more literary. I want you to only reply the correction, the improvements and nothing else, do not write explanations." }, "English to Russian translator", "System", new DateTimeOffset(new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prompts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
