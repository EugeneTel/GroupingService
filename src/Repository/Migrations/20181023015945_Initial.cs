using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AvgSkillIndex = table.Column<float>(nullable: true),
                    AvgRemoteIndex = table.Column<float>(nullable: true),
                    MaxUsers = table.Column<int>(nullable: true),
                    ConnectedUsers = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    FinishedAt = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    SkillIndex = table.Column<float>(nullable: true),
                    RemoteIndex = table.Column<int>(nullable: true),
                    ConnectedAt = table.Column<DateTime>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                   /* table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);*/
                });


            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "AvgSkillIndex", "AvgRemoteIndex", "MaxUsers", "ConnectedUsers", "CreatedAt", "FinishedAt", "IsActive" },
                values: new object[] 
                    { 1, 0.3f, 80.0f, 5, 3, DateTime.Now.AddMinutes(-20), null, true }
                );

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "AvgSkillIndex", "AvgRemoteIndex", "MaxUsers", "ConnectedUsers", "CreatedAt", "FinishedAt", "IsActive" },
                values: new object[]
                    { 2, 0.8f, 30.0f, 5, 2, DateTime.Now.AddMinutes(-10), null, true }
                );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 1, "John", 0.3f, 80, DateTime.Now.AddMinutes(-18), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 2, "Bob", 0.2f, 70, DateTime.Now.AddMinutes(-12), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 3, "Mike", 0.4f, 90, DateTime.Now.AddMinutes(-2), 1 });


            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 4, "Mark", 0.9f, 40, DateTime.Now.AddMinutes(-8), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 5, "Karl", 0.7f, 20, DateTime.Now.AddMinutes(-1), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
