using NanoidDotNet;
using ERP.Core.Application.Commons.Interfaces;
using System.Text.RegularExpressions;
using ERP.Core.Database.Application.Commons.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.Infrastructure.Services
{
    public partial class CodeGenerator(IUnitOfWork _unitOfWork) : ICodeGenerator
    {
        [GeneratedRegex(@"[^a-zA-Z]")]
        private static partial Regex GenerateModuleCode();
        private readonly IUnitOfWork _unitOfWork = _unitOfWork;


        /// <summary>
        /// Generador de codigo para cotizaciones por sucursal.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public async Task<(bool IsSuccess, string Code)> GenerateUniqueCodeToQuotes(Guid branchId)
        {
            var branch = await _unitOfWork.Branches.Entities
                .FirstOrDefaultAsync(b => b.Id == branchId);

            if (branch == null)
            {
                return (false, string.Empty);
            }

            var lastQuotation = await _unitOfWork.Quotations.Entities
                .Where(q => q.BranchId == branchId)
                .OrderByDescending(q => q.CreatedAt)
                .FirstOrDefaultAsync();

            int nextSequence = 1;

            if (lastQuotation != null && !string.IsNullOrWhiteSpace(lastQuotation.QuotationCode))
            {
                int lastDashIndex = lastQuotation.QuotationCode.LastIndexOf('-');

                if (lastDashIndex > -1 && int.TryParse(lastQuotation.QuotationCode[(lastDashIndex + 1)..], out int lastSequence))
                {
                    nextSequence = lastSequence + 1;
                }
            }

            string sequenceFormatted = nextSequence.ToString().PadLeft(2, '0');
            string code = $"{branch.BranchCode?.ToUpper()}-{sequenceFormatted}";

            return (true, code);
        }

        public string GenerateModuleCode(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return $"GEN-{GetRandomSuffix()}";

            string cleanName = GenerateModuleCode().Replace(subject.Trim().ToUpper(), "");

            string prefix = cleanName.Length >= 3 
                ? cleanName[..3]
                : cleanName.PadRight(3, 'X');

            return $"{prefix}-{GetRandomSuffix()}";
        }

        public string GenerateUsername(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return "user.default";

            string cleanName = RemoveAccents(subject.ToLower().Trim());

            var parts = cleanName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 1) return parts[0];

            string username = $"{parts[0]}.{parts[parts.Length - 1]}";

            return username;   
        }

        #region Metodos Privados
        private static string GetRandomSuffix()
        {
            const string alphabet = "23456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            return Nanoid.Generate(alphabet, size: 4);
        }

        private static string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            var stringBuilder = new System.Text.StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);

                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
        #endregion Metodos Privado
    }
}