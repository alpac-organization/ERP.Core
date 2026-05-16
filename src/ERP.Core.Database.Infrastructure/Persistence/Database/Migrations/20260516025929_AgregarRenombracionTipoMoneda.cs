using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    public partial class AgregarRenombracionTipoMoneda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "currency_enum",
                schema: "public",
                table: "deductions_payment_histories",
                newName: "currency");

            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency DROP DEFAULT;
            """);

            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency
                TYPE currency_enum
                USING (
                    CASE
                        WHEN currency = 0 THEN 'nio'::currency_enum
                        WHEN currency = 1 THEN 'usd'::currency_enum
                    END
                );
            """);

            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency
                SET DEFAULT 'nio'::currency_enum;
            """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency DROP DEFAULT;
            """);

            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency
                TYPE integer
                USING (
                    CASE
                        WHEN currency = 'nio' THEN 0
                        WHEN currency = 'usd' THEN 1
                    END
                );
            """);

            migrationBuilder.Sql("""
                ALTER TABLE public.deductions_payment_histories
                ALTER COLUMN currency
                SET DEFAULT 0;
            """);

            migrationBuilder.RenameColumn(
                name: "currency",
                schema: "public",
                table: "deductions_payment_histories",
                newName: "currency_enum");
        }
    }
}