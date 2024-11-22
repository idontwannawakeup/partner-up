using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartnerUp.Identity.Persistence.People.Migrations
{
    public partial class UserRecommendationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecommendationId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommendationId",
                table: "AspNetUsers");
        }
    }
}
