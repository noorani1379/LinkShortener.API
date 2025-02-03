
using LinkShortener.API.Features.Links;

namespace LinkShortener.API.Infrastructure
{
    public class InMemoryLinkStore
    {
        private readonly Dictionary<string, LinkModel> _links = new();

        public void Add(LinkModel link)
        {
            _links[link.ShortKey] = link;
        }

        public bool TryGet(string shortKey, out LinkModel link) =>
            _links.TryGetValue(shortKey, out link);
    }
}
