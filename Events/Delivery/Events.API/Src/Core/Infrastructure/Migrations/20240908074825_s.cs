using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsComments_EventsComments_ParentId",
                table: "EventsComments");

            migrationBuilder.DropIndex(
                name: "IX_EventsComments_ParentId",
                table: "EventsComments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "EventsComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "EventsComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventsComments_ParentId",
                table: "EventsComments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventsComments_EventsComments_ParentId",
                table: "EventsComments",
                column: "ParentId",
                principalTable: "EventsComments",
                principalColumn: "Id");
        }
    }
}
