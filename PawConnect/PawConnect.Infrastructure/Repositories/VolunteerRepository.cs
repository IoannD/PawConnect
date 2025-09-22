using Microsoft.EntityFrameworkCore;
using PawConnect.Application;
using PawConnect.Domain.VolunteerModel;

namespace PawConnect.Infrastructure.Repositories;

public class VolunteerRepository : IVolunteerRepository
{
    private readonly AppDbContext _context;

    public VolunteerRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> CreateAsync(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await _context.Volunteers.AddAsync(volunteer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return volunteer.Id;
    }

    public async Task<Volunteer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Volunteers.FirstOrDefaultAsync(v => v.Id == id,  cancellationToken);
    }
}