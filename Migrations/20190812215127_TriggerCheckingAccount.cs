using Microsoft.EntityFrameworkCore.Migrations;

namespace DistripackAPI.Migrations
{
    public partial class TriggerCheckingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"" +
                " CREATE TRIGGER [CheckingAccountBalance] ON [dbo].[Transactions] " +
                " AFTER INSERT AS " +
                " BEGIN " +
                " UPDATE ca " +
                " SET   UpdatedAt = GETDATE(), " +
                "       CurrentBalance = (ca.CurrentBalance - total.payments + total.receipts) " +
                " FROM CheckingAccount ca " +
                " JOIN  (SELECT i.CheckingAccountId as accountId, " +
                "           SUM(CASE WHEN i.Type = 'Receipt' THEN i.Amount ELSE 0 END) as receipts, " +
                "           SUM(CASE WHEN i.Type = 'Payment' THEN i.Amount ELSE 0 END) as payments " +
                "        FROM INSERTED i GROUP BY i.CheckingAccountId) AS total " +
                " ON total.accountId = ca.Id " +
                " END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("BEGIN DROP TRIGGER[dbo].[CheckingAccountBalance] END ");
        }
    }
}
