using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoRental.Migrations
{
    public partial class AddGenreName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (1,'Action')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2,'Commedy')");
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (3,'Drama')");
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (4,'Family')");
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (5,'Horror')");
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (6,'Romance')");
            migrationBuilder.Sql("INSERT INTO Genre (id, Name) VALUES (7,'Thriller')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
