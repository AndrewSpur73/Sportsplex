using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _LocationRepo;

        public LocationService(ILocationRepository LocationRepo)
        {
            _LocationRepo = LocationRepo;
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var singleLocation = _LocationRepo.GetLocationByIdAsync(id);

            if (singleLocation == null)
            {
                throw new ArgumentException("Location not found.");
            }

            return await _LocationRepo.GetLocationByIdAsync(id);
        }

        public async Task<Location> CreateLocationAsync(CreateLocationDTO LocationDTO)
        {
            return await _LocationRepo.CreateLocationAsync(LocationDTO);
        }

        public async Task<Location> DeleteLocationAsync(int id)
        {
            return await _LocationRepo.DeleteLocationAsync(id);
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            return await _LocationRepo.GetAllLocationsAsync();
        }

        public async Task<Location> UpdateLocationAsync(int id, UpdateLocationDTO LocationDTO)
        {
            return await _LocationRepo.UpdateLocationAsync(id, LocationDTO);

        }
    }
}
