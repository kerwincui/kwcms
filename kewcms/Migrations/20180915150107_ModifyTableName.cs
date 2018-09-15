using Microsoft.EntityFrameworkCore.Migrations;

namespace kewcms.Migrations
{
    public partial class ModifyTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendLinks",
                table: "FriendLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "FriendLinks",
                newName: "FriendLink");

            migrationBuilder.RenameTable(
                name: "Feedbacks",
                newName: "Feedback");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Article",
                newName: "IX_Article_ArticleCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendLink",
                table: "FriendLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ArticleCategory_ArticleCategoryId",
                table: "Article",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ArticleCategory_ArticleCategoryId",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendLink",
                table: "FriendLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleCategory",
                table: "ArticleCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "FriendLink",
                newName: "FriendLinks");

            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Feedbacks");

            migrationBuilder.RenameTable(
                name: "ArticleCategory",
                newName: "ArticleCategories");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Article_ArticleCategoryId",
                table: "Articles",
                newName: "IX_Articles_ArticleCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendLinks",
                table: "FriendLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedbacks",
                table: "Feedbacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleCategories",
                table: "ArticleCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
