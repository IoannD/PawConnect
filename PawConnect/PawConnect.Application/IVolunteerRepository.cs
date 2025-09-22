using PawConnect.Domain.VolunteerModel;

namespace PawConnect.Application;

public interface IVolunteerRepository
{
    Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken cancellationToken = default);

    Task<Volunteer> GetByIdAsync(Guid id,  CancellationToken cancellationToken = default);
}