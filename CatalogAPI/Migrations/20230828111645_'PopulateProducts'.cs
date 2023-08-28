﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations {
    /// <inheritdoc />
    public partial class PopulateProducts : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("INSERT INTO products (Name, Description, Price, ImagePath, Stock, RegisterDate, CategoryId) VALUES ('Coca-cola Diet', 'Refrigerante de Cola 350ml', 5.45, 'cocacola.jpg', 50, now(), 1);");
            migrationBuilder.Sql("INSERT INTO products (Name, Description, Price, ImagePath, Stock, RegisterDate, CategoryId) VALUES ('Lanche de Atum', 'Lanche de Atum com maionese', 8.50, 'atum.jpg', 50, now(), 2);");
            migrationBuilder.Sql("INSERT INTO products (Name, Description, Price, ImagePath, Stock, RegisterDate, CategoryId) VALUES ('Pudim 100 g', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 50, now(), 3);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("DELETE FROM products");
        }
    }
}
