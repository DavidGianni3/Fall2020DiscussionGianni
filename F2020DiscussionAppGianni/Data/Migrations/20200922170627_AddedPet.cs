using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppGianni.Data.Migrations
{
    //Inheritance
    //Entity Framework (object Relational Mapper) 
    //Name the migration Classes using the action you are taking 
    //AddedPetColumn 
    public partial class AddedPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    PetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(nullable: true),
                    PetType = table.Column<string>(nullable: false),
                    PetGender = table.Column<string>(nullable: false),
                    PetDateOfBirth = table.Column<DateTime>(nullable: true),
                    PetSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.PetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");
        }
    }
}
