using Contracts.API;
using Contracts.Application;
using Microsoft.AspNetCore.Mvc;
using PawConnect.API.Extensions;
using PawConnect.Application.VolunteerCases;
using NetworkDetails = Contracts.Application.NetworkDetails;
using DonationDetails = Contracts.Application.DonationDetails;

namespace PawConnect.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(
        CreateVolunteerRequest createVolunteerRequest,
        [FromServices] CreateVolunteerUseCase createVolunteerUseCase,
        CancellationToken cancellationToken)
    {
        var createCommand = new CreateVolunteerCommand(
            createVolunteerRequest.FirstName,
            createVolunteerRequest.LastName,
            createVolunteerRequest.MiddleName,
            createVolunteerRequest.Description,
            createVolunteerRequest.PhoneNumber,
            createVolunteerRequest.Email,
            createVolunteerRequest.NetworksDetails
                .Select(s => new NetworkDetails(s.Title, s.Url)),
            createVolunteerRequest.DonationDetails
                .Select(s => new DonationDetails(s.Title, s.Description)));

        var createResult = await createVolunteerUseCase
            .ExecuteAsync(createCommand,  cancellationToken);

        return createResult.ToResponse();
    }
}