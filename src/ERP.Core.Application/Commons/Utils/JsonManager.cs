using System.Text.Json;

namespace ERP.Core.Application.Commons.Utils
{
    public static class JsonManager
    {
        public static readonly JsonSerializerOptions SnakeCaseOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }
}