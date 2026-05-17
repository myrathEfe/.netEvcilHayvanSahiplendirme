using Microsoft.EntityFrameworkCore;
using PetAdoptionSystem.Data;
using PetAdoptionSystem.Models;
using PetAdoptionSystem.Models.Enums;
using PetAdoptionSystem.Services.Models;

namespace PetAdoptionSystem.DataAccess.Repositories;

public class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _context;

    public PetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pet>> SearchAsync(PetSearchRequest request)
    {
        var query = _context.Pets.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(x => x.Name.Contains(request.Name));
        }

        if (!string.IsNullOrWhiteSpace(request.Breed))
        {
            query = query.Where(x => x.Breed.Contains(request.Breed));
        }

        if (!string.IsNullOrWhiteSpace(request.City))
        {
            query = query.Where(x => x.City.Contains(request.City));
        }

        if (request.Species.HasValue)
        {
            query = query.Where(x => x.Species == request.Species.Value);
        }

        if (request.AdoptionStatus.HasValue)
        {
            query = query.Where(x => x.AdoptionStatus == request.AdoptionStatus.Value);
        }

        if (request.DisabilityStatus.HasValue)
        {
            query = query.Where(x => x.DisabilityStatus == request.DisabilityStatus.Value);
        }

        if (request.OnlyDisabled)
        {
            query = query.Where(x => x.DisabilityStatus == DisabilityStatus.Yes);
        }

        if (request.MinAge.HasValue)
        {
            query = query.Where(x => x.Age >= request.MinAge.Value);
        }

        if (request.MaxAge.HasValue)
        {
            query = query.Where(x => x.Age <= request.MaxAge.Value);
        }

        return await query
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();
    }

    public async Task<List<Pet>> GetRecentAsync(int count)
    {
        return await _context.Pets.AsNoTracking()
            .OrderByDescending(x => x.CreatedDate)
            .Take(count)
            .ToListAsync();
    }

    public async Task<Pet?> GetByIdAsync(int id)
    {
        return await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pet pet)
    {
        _context.Pets.Update(pet);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Pet pet)
    {
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Pets.CountAsync();
    }

    public async Task<int> CountByStatusAsync(AdoptionStatus status)
    {
        return await _context.Pets.CountAsync(x => x.AdoptionStatus == status);
    }
}
