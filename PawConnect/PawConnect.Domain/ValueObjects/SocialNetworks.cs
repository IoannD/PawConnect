namespace PawConnect.Domain.ValueObjects;

public record SocialNetworks
{
    [Obsolete("Only for EF Core", true)]
    private SocialNetworks()
    {
    }

    private List<SocialNetworkDetails> _details = [];
    public IReadOnlyList<SocialNetworkDetails> Details => _details;

    public SocialNetworks(List<SocialNetworkDetails> details)
    {
        _details = details;
    }
}