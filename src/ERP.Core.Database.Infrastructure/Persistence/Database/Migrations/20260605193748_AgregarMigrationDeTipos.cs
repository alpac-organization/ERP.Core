using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMigrationDeTipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Period",
                schema: "public",
                table: "payrolls",
                newName: "period");

            // 1. Drop del DEFAULT integer
            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period DROP DEFAULT;"
            );

            // 2. Cambiar tipo usando CASE con los labels reales del enum
            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period TYPE payroll_period_enum 
                USING CASE period
                    WHEN 0 THEN 'first_period'::payroll_period_enum
                    WHEN 1 THEN 'first_period'::payroll_period_enum
                    WHEN 2 THEN 'second_period'::payroll_period_enum
                    ELSE 'first_period'::payroll_period_enum
                END;"
            );

            // 3. Restaurar DEFAULT como enum
            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period SET DEFAULT 'first_period'::payroll_period_enum;"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period DROP DEFAULT;"
            );

            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period TYPE integer 
                USING CASE period
                    WHEN 'first_period'::payroll_period_enum THEN 1
                    WHEN 'second_period'::payroll_period_enum THEN 2
                END;"
            );

            migrationBuilder.Sql(
                @"ALTER TABLE public.payrolls 
                ALTER COLUMN period SET DEFAULT 1;"
            );

            migrationBuilder.RenameColumn(
                name: "period",
                schema: "public",
                table: "payrolls",
                newName: "Period");
        }
    }
}
