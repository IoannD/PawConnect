using Contracts.Application;
using CSharpFunctionalExtensions;
using PawConnect.Domain.Shared;
using PawConnect.Domain.ValueObjects;
using PawConnect.Domain.VolunteerModel;
using DonationDetails = PawConnect.Domain.ValueObjects.DonationDetails;

namespace PawConnect.Application.VolunteerCases;

public class CreateVolunteerUseCase(IVolunteerRepository repository)
{
    public async Task<Result<Guid, Error>> ExecuteAsync(CreateVolunteerCommand request,
        CancellationToken cancellationToken = default)
    {
        var phoneNumberResult = PhoneNumber.Create(request.PhoneNumber);
        if  (phoneNumberResult.IsFailure)
            return phoneNumberResult.Error;

        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return emailResult.Error;

        var socialNetworkResults = request.NetworksDetails
            .Select(n => SocialNetworkDetails.Create(n.Title, n.Url))
            .ToList();

        if (socialNetworkResults.Any(r => r.IsFailure))
            return socialNetworkResults.First(r => r.IsFailure).Error;

        var socialNetworks = socialNetworkResults
            .Select(r => r.Value)
            .ToList();

        var donationResults = request.DonationDetails
            .Select(d => DonationDetails.Create(d.Title, d.Description))
            .ToList();
        if (donationResults.Any(r => r.IsFailure))
            return donationResults.First(r => r.IsFailure).Error;

        var donationDetails = donationResults
            .Select(d => d.Value)
            .ToList();

        var volunteerResult = Volunteer.Create(request.FirstName, request.LastName,
            request.MiddleName, request.Description, phoneNumberResult.Value,
            emailResult.Value, socialNetworks, donationDetails);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        return await repository.CreateAsync(volunteerResult.Value, cancellationToken);
    }
}