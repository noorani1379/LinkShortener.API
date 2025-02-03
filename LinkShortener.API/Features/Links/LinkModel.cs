namespace LinkShortener.API.Features.Links
{
    public class LinkModel
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortKey { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
