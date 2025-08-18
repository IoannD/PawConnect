namespace PawConnect.Domain.ValueObjects;

public record SocialNetworks
{
    private List<SocialNetworkDetails> _details;
    public IReadOnlyList<SocialNetworkDetails> Details => _details;
}