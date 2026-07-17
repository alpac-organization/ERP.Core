using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Core.Database.Infrastructure.Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixTimeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "closed_at",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "gate_entrance_time",
                schema: "public",
                table: "reception_entrance");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "start_time",
                schema: "public",
                table: "step_execution_logs",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "end_time",
                schema: "public",
                table: "step_execution_logs",
                type: "time without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "end_date",
                schema: "public",
                table: "step_execution_logs",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "start_date",
                schema: "public",
                table: "step_execution_logs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "closed_at_date",
                schema: "public",
                table: "record_entrances",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "closed_at_time",
                schema: "public",
                table: "record_entrances",
                type: "time without time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_date",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "start_date",
                schema: "public",
                table: "step_execution_logs");

            migrationBuilder.DropColumn(
                name: "closed_at_date",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.DropColumn(
                name: "closed_at_time",
                schema: "public",
                table: "record_entrances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_time",
                schema: "public",
                table: "step_execution_logs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_time",
                schema: "public",
                table: "step_execution_logs",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "closed_at",
                schema: "public",
                table: "record_entrances",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "gate_entrance_time",
                schema: "public",
                table: "reception_entrance",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
