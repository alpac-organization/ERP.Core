using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Manager.Api.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatosEnums : Migration
    {
        /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "public",
                table: "deductions_payment_histories",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "DoesWorkSaturdays",
                schema: "public",
                table: "collaborators",
                newName: "does_work_saturdays");

            // 1. Eliminar la restricción del valor por defecto actual (ej: DEFAULT 0)
            migrationBuilder.Sql("ALTER TABLE public.deductions_payment_histories ALTER COLUMN status DROP DEFAULT;");

            // 2. Cambiar el tipo de dato usando la conversión (USING)
            migrationBuilder.Sql(
                @"ALTER TABLE public.deductions_payment_histories 
                ALTER COLUMN status TYPE deduction_payment_status 
                USING status::text::deduction_payment_status;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Quitar el valor por defecto del Enum
            migrationBuilder.Sql("ALTER TABLE public.deductions_payment_histories ALTER COLUMN status DROP DEFAULT;");

            // 2. Cambiar de vuelta a entero
            migrationBuilder.Sql(
                @"ALTER TABLE public.deductions_payment_histories 
                ALTER COLUMN status TYPE integer 
                USING status::text::integer;");

            // 3. (Opcional) Devolver el valor por defecto numérico que tenía originalmente (ej: 0)
            // migrationBuilder.Sql("ALTER TABLE public.deductions_payment_histories ALTER COLUMN status SET DEFAULT 0;");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "public",
                table: "deductions_payment_histories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "does_work_saturdays",
                schema: "public",
                table: "collaborators",
                newName: "DoesWorkSaturdays");
        }
    }
}