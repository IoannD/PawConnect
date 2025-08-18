namespace PawConnect.Domain.ValueObjects;

public record Donation
{
    private List<DonationDetails> _details = [];
    public IReadOnlyList<DonationDetails> DonationDetails => _details;
}