using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRegistroEnumDeDeduccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "public",
                table: "deductions",
                newName: "status");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_type WHERE typname = 'deduction_status_enum'
                    ) THEN
                        CREATE TYPE deduction_status_enum AS ENUM
                        ('progress', 'completed', 'pending');
                    END IF;
                END$$;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status DROP DEFAULT;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status TYPE deduction_status_enum
                USING (
                    CASE status
                        WHEN 0 THEN 'progress'::deduction_status_enum
                        WHEN 1 THEN 'completed'::deduction_status_enum
                        WHEN 2 THEN 'pending'::deduction_status_enum
                    END
                );
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status SET DEFAULT 'progress';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status DROP DEFAULT;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status TYPE integer
                USING (
                    CASE status
                        WHEN 'progress' THEN 0
                        WHEN 'completed' THEN 1
                        WHEN 'pending' THEN 2
                    END
                );
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE public.deductions
                ALTER COLUMN status SET DEFAULT 0;
            ");

            migrationBuilder.Sql(@"DROP TYPE IF EXISTS deduction_status_enum;");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "public",
                table: "deductions",
                newName: "Status");
        }
    }
}
