using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vega.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-Model-A',(select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-Model-B',(select Id from Makes where Name='Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make1-Model-C',(select Id from Makes where Name='Make1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-Model-A',(select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-Model-B',(select Id from Makes where Name='Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make2-Model-C',(select Id from Makes where Name='Make2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-Model-A',(select Id from Makes where Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-Model-B',(select Id from Makes where Name='Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES ('Make3-Model-C',(select Id from Makes where Name='Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes where Name IN('Make1','Make2','Make3')");
        }
    }
}
