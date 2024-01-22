﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc1.Migrations
{
    public partial class PopularCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category(CategoryName, Description) " + "VALUES('Normal', 'Lanche feito com ingredientes normais')");

            migrationBuilder.Sql("INSERT INTO Category(CategoryName, Description) " + "VALUES('Natural', 'Lanche feito com ingredientes integrais e naturais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Category");
        }
    }
}
