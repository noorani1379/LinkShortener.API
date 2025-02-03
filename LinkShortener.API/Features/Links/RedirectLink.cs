using LinkShortener.API.Infrastructure;

namespace LinkShortener.API.Features.Links
{
    public static class RedirectLink
    {
        public static IEndpointRouteBuilder MapRedirectLinkEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/api/links/{shortKey}", (string shortKey, InMemoryLinkStore store) =>
            {
                if (store.TryGet(shortKey, out var link))
                {
                    return Results.Redirect(link.OriginalUrl);
                }
                return Results.NotFound();
            });

            return routes;
        }
    }
}
