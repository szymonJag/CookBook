using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBook.Server.Migrations
{
    public partial class nameOfTablesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipesTable_IngredientsTable_IngredientId",
                table: "IngredientRecipesTable");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipesTable_RecipesTable_RecipeId",
                table: "IngredientRecipesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipesTable",
                table: "RecipesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsTable",
                table: "IngredientsTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientRecipesTable",
                table: "IngredientRecipesTable");

            migrationBuilder.RenameTable(
                name: "RecipesTable",
                newName: "Recipes");

            migrationBuilder.RenameTable(
                name: "IngredientsTable",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "IngredientRecipesTable",
                newName: "IngredientRecipes");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipesTable_RecipeId",
                table: "IngredientRecipes",
                newName: "IX_IngredientRecipes_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipesTable_IngredientId",
                table: "IngredientRecipes",
                newName: "IX_IngredientRecipes_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientRecipes",
                table: "IngredientRecipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipes_Ingredients_IngredientId",
                table: "IngredientRecipes",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecipes_Recipes_RecipeId",
                table: "IngredientRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipes_Ingredients_IngredientId",
                table: "IngredientRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecipes_Recipes_RecipeId",
                table: "IngredientRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientRecipes",
                table: "IngredientRecipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "RecipesTable");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "IngredientsTable");

            migrationBuilder.RenameTable(
                name: "IngredientRecipes",
                newName: "IngredientRecipesTable");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipes_RecipeId",
                table: "IngredientRecipesTable",
                newName: "IX_IngredientRecipesTable_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientRecipes_IngredientId",
                table: "IngredientRecipesTable",
                newName: "IX_IngredientRecipesTable_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipesTable",
                table: "RecipesTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsTable",
                table: "IngredientsTable",
                column: "Id");

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
    }
}
