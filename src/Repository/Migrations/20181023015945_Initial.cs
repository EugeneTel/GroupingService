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
                    BaseSkillIndex = table.Column<double>(nullable: true),
                    BaseRemoteIndex = table.Column<double>(nullable: true),
                    MaxUsers = table.Column<int>(nullable: true),
                    ConnectedUsers = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    IsStarted = table.Column<bool>(defaultValue: false),
                    StartedAt = table.Column<DateTime>(nullable: true)
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
                    SkillIndex = table.Column<double>(nullable: true),
                    RemoteIndex = table.Column<int>(nullable: true),
                    ConnectedAt = table.Column<DateTime>(nullable: true),
                    GroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });


            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "BaseSkillIndex", "BaseRemoteIndex", "MaxUsers", "ConnectedUsers", "CreatedAt", "IsStarted" },
                values: new object[] 
                    { 1, 0.3, 80.0, 5, 3, DateTime.Now.AddMinutes(-20), false }
                );

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "BaseSkillIndex", "BaseRemoteIndex", "MaxUsers", "ConnectedUsers", "CreatedAt", "IsStarted" },
                values: new object[]
                    { 2, 0.8, 30.0, 5, 2, DateTime.Now.AddMinutes(-10), false }
                );

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 1, "John", 0.3, 80, DateTime.Now.AddMinutes(-18), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 2, "Bob", 0.2, 70, DateTime.Now.AddMinutes(-12), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 3, "Mike", 0.4, 90, DateTime.Now.AddMinutes(-2), 1 });


            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 4, "Mark", 0.9, 40, DateTime.Now.AddMinutes(-8), 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "SkillIndex", "RemoteIndex", "ConnectedAt", "GroupId" },
                values: new object[] { 5, "Karl", 0.7, 20, DateTime.Now.AddMinutes(-1), 2 });
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
