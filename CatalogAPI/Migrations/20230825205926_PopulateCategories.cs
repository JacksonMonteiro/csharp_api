using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations {
    /// <inheritdoc />
    public partial class PopulateCategories : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("INSERT INTO categories (Name, ImagePath) VALUES ('Drinks', 'drinks.jpg')");
            migrationBuilder.Sql("INSERT INTO categories (Name, ImagePath) VALUES ('Snacks', 'snacks.jpg')");
            migrationBuilder.Sql("INSERT INTO categories (Name, ImagePath) VALUES ('Desserts', 'desserts.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql("DELETE FROM categories");
        }
    }
}
