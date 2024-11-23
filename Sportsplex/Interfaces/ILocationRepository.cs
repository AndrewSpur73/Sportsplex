using Sportsplex.DTO;
using Sportsplex.Models;

namespace Sportsplex.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<Location> CreateLocationAsync(CreateLocationDTO LocationDTO);
        Task<Location> UpdateLocationAsync(int id, UpdateLocationDTO LocationDTO);
        Task<Location> DeleteLocationAsync(int id);
    }
}
