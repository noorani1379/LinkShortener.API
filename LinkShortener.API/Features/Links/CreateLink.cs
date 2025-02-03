
using LinkShortener.API.Infrastructure;

namespace LinkShortener.API.Features.Links
{
    public static class CreateLink
    {
        // مدل درخواست ایجاد لینک به صورت record (فقط خواندنی)
        public record CreateLinkRequest(string OriginalUrl);

        // متدی برای ثبت endpoint ایجاد لینک
        public static IEndpointRouteBuilder MapCreateLinkEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/links", async (CreateLinkRequest request, InMemoryLinkStore store) =>
            {
                // اعتبارسنجی URL ورودی
                if (!Uri.TryCreate(request.OriginalUrl, UriKind.Absolute, out var _))
                {
                    return Results.BadRequest("آدرس URL معتبر نیست.");
                }

                var shortKey = GenerateShortKey();

                var link = new LinkModel
                {
                    Id = Guid.NewGuid(),
                    OriginalUrl = request.OriginalUrl,
                    ShortKey = shortKey,
                    CreatedAt = DateTime.UtcNow
                };

                store.Add(link);

                return Results.Ok(new { link.OriginalUrl, link.ShortKey });
            });

            return routes;
        }

        // متدی برای تولید کلید کوتاه به صورت تصادفی (6 کاراکتر)
        private static string GenerateShortKey()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
