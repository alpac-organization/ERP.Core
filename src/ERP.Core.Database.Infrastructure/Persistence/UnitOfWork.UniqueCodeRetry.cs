
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ERP.Core.Database.Infrastructure.Persistence
{
    public partial class UnitOfWork
    {
        private static readonly HashSet<string> UniqueCodeIndexNames =
        [
            "ux_purchase_requests_code",
            "ux_purchase_orders_code",
            "ux_products_code",
            "ux_payment_requests_code"
        ];

        // aqui Ejecuta una acción dentro de una transaction, haciendo retry si ocurre una violación de código único.
        public async Task ExecuteWithUniqueCodeRetryAsync(
            Func<CancellationToken, Task> action,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(action);

            const int maxAttempts = 3;

            for (var attempt = 1; attempt <= maxAttempts; attempt++)
            {
                await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    await action(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                    return;
                }
                catch (DbUpdateException ex) when (
                    attempt < maxAttempts
                    && IsUniqueCodeConstraintViolation(ex))
                {
                    await transaction.RollbackAsync(cancellationToken);
                    _context.ChangeTracker.Clear();
                }
                catch
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }

            throw new InvalidOperationException("No se pudo reservar un código único tras los reintentos.");
        }

        // se Determina si la excepción corresponde a una violación de constraint  única del código.
        private static bool IsUniqueCodeConstraintViolation(DbUpdateException exception)
        {
            if (exception.InnerException is not PostgresException postgresException)
            {
                return false;
            }

            if (postgresException.SqlState != PostgresErrorCodes.UniqueViolation)
            {
                return false;
            }

            var constraintName = postgresException.ConstraintName;
            return !string.IsNullOrEmpty(constraintName)
                && UniqueCodeIndexNames.Contains(constraintName);
        }
    }
}
