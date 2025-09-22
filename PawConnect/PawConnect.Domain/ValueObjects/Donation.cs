namespace PawConnect.Domain.ValueObjects;

public record Donation
{
    [Obsolete("Only for EF Core", true)]
    private Donation()
    {
    }

    private List<DonationDetails> _details = [];
    public IReadOnlyList<DonationDetails> DonationDetails => _details;

    public Donation(List<DonationDetails> details)
    {
        _details = details;
    }
}