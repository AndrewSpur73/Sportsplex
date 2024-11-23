using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SportsplexDbContext _context;

        public LocationRepository(SportsplexDbContext context)
        {
            _context = context;
        }

        //Get all Locations
        public async Task<List<Location>> GetAllLocationsAsync()
        {
            {

                var Location = await _context.Locations
                    .ToListAsync();

                if (Location == null)
                {
                    return null;
                }

                return Location;

            };
        }


        //Create a Location
        public async Task<Location> CreateLocationAsync(CreateLocationDTO LocationDTO)
        {

            var newLocation = new Location
            {
                Name = LocationDTO.Name
            };

            try
            {
                _context.Locations.Add(newLocation);
                await _context.SaveChangesAsync();
                return newLocation;
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


        //Update a Location
        public async Task<Location> UpdateLocationAsync(int id, UpdateLocationDTO LocationDTO)
        {
            var LocationToUpdate = await _context.Locations.FirstOrDefaultAsync(c => c.Id == id);

            if (LocationToUpdate == null)
            {
                return null;
            }
            LocationToUpdate.Name = LocationDTO.Name;

            try
            {
                await _context.SaveChangesAsync();
                return LocationToUpdate;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }

        //Delete a Location
        public async Task<Location> DeleteLocationAsync(int id)
        {

            var Location = await _context.Locations
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (Location == null)
            {
                return null;
            }

            // Remove the Location
            _context.Locations.Remove(Location);
            _context.SaveChanges();

            return Location;

        }

        //Get a Single Location
        public async Task<Location> GetLocationByIdAsync(int id)
        {

            var singleLocation = await _context.Locations
            .FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                await _context.SaveChangesAsync();
                return singleLocation;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }

        }
    }
}
