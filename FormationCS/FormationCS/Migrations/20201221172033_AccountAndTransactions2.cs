using Microsoft.EntityFrameworkCore.Migrations;

namespace FormationCS.Migrations
{
    public partial class AccountAndTransactions2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_AccountId",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "transaction",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_AccountId",
                table: "transaction",
                newName: "IX_transaction_accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_accountId",
                table: "transaction",
                column: "accountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_accountId",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "transaction",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_accountId",
                table: "transaction",
                newName: "IX_transaction_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_AccountId",
                table: "transaction",
                column: "AccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
