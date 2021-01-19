using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.Server.Migrations
{
    public partial class IngredientRecipesTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipe_IngredientsTable_IngredientId",
                table: "IngredientRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipe_RecipesTable_RecipeId",
                table: "IngredientRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientRecipe",
                table: "IngredientRecipe");

            migrationBuilder.RenameTable(
                name: "IngredientRecipe",
                newName: "IngredientRecipesTable");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipe_RecipeId",
                table: "IngredientRecipesTable",
                newName: "IX_IngredientRecipesTable_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipe_IngredientId",
                table: "IngredientRecipesTable",
                newName: "IX_IngredientRecipesTable_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientRecipesTable",
                table: "IngredientRecipesTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipesTable_IngredientsTable_IngredientId",
                table: "IngredientRecipesTable",
                column: "IngredientId",
                principalTable: "IngredientsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipesTable_RecipesTable_RecipeId",
                table: "IngredientRecipesTable",
                column: "RecipeId",
                principalTable: "RecipesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipesTable_IngredientsTable_IngredientId",
                table: "IngredientRecipesTable");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipesTable_RecipesTable_RecipeId",
                table: "IngredientRecipesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientRecipesTable",
                table: "IngredientRecipesTable");

            migrationBuilder.RenameTable(
                name: "IngredientRecipesTable",
                newName: "IngredientRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipesTable_RecipeId",
                table: "IngredientRecipe",
                newName: "IX_IngredientRecipe_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipesTable_IngredientId",
                table: "IngredientRecipe",
                newName: "IX_IngredientRecipe_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientRecipe",
                table: "IngredientRecipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipe_IngredientsTable_IngredientId",
                table: "IngredientRecipe",
                column: "IngredientId",
                principalTable: "IngredientsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipe_RecipesTable_RecipeId",
                table: "IngredientRecipe",
                column: "RecipeId",
                principalTable: "RecipesTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
