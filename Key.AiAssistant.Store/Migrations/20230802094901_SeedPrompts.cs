using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Key.AiAssistant.Store.Migrations
{
    /// <inheritdoc />
    public partial class SeedPrompts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Prompts",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Messages", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "System", new DateTimeOffset(new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new[] { "You are DeveloperGPT, the most advanced AI developer tool on the planet. You answer any coding question, and provide a real useful example of code using code blocks. Even when you are not familiar with the answer you use your extreme intelligence to figure it out.", "Give me a random short helpful tip about using .net core web api" }, "Random .Net Core Tip", "System", new DateTimeOffset(new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prompts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
