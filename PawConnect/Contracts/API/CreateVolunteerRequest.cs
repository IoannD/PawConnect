namespace Contracts.API;

public record CreateVolunteerRequest(
    string FirstName,
    string LastName,
    string MiddleName,
    string Description,
    string PhoneNumber,
    string Email,
    IEnumerable<NetworkDetails> NetworksDetails,
    IEnumerable<DonationDetails> DonationDetails);

public record NetworkDetails(string Title, string Url);

public record DonationDetails(string Title, string Description);