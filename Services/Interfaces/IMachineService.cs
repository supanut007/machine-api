using MachineMaster.Models;

namespace MachineMaster.Services.Interfaces;

public interface IMachineService
{
    Task<List<Machine>> GetAllAsync();

    Task<Machine?> GetByIdAsync(int id);

    Task<Machine> CreateAsync(Machine machine);

    Task<bool> DeleteAsync(int id);

    Task<List<Machine>> SearchAsync(string? keyword);
}