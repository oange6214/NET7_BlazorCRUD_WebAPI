using Shared.Models;

namespace src.Client.Services;

public interface IDriverService
{
    Task<IEnumerable<Driver>?> All();
    Task<Driver?> GetDriver(int id);
    Task<Driver?> AddDriver(Driver driver);
    Task<bool> Update(Driver driver);
    Task<bool> Delete(int id);
}