using Microsoft.EntityFrameworkCore;
// using MachineMaster.Data;
using MachineMaster.Models;
using MachineMaster.Services.Interfaces;
using MyApi.Data;

namespace MachineMaster.Services;

public class MachineService : IMachineService
{
    private readonly AppDbContext _context;

    public MachineService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Machine>> GetAllAsync()
    {
        return await _context.Machines.ToListAsync();
    }

    public async Task<Machine?> GetByIdAsync(int id)
    {
        return await _context.Machines.FindAsync(id);
    }

    public async Task<Machine> CreateAsync(Machine machine)
    {
        var exists = await _context.Machines
        .AnyAsync(x => x.MachineNo == machine.MachineNo);

        if (exists)
        {
            throw new Exception("Machine No already exists.");
        }

        _context.Machines.Add(machine);

        await _context.SaveChangesAsync();

        return machine;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var machine = await _context.Machines.FindAsync(id);

        if (machine == null)
            return false;

        _context.Machines.Remove(machine);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Machine>> SearchAsync(string? keyword)
    {
        var query = _context.Machines.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();

            query = query.Where(x =>
                x.MachineNo.Contains(keyword) ||
                x.MachineName.Contains(keyword) ||
                x.Plant.Contains(keyword) ||
                x.Status.Contains(keyword));
        }

        return await query.ToListAsync();
    }
}