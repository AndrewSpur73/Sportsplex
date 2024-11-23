using Moq;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;
using Sportsplex.Services;


namespace Sportsplex.Tests.CallTests
{
    public class LocationTests
    {
        private readonly Mock<ILocationRepository> _mockLocationRepository;
        private readonly ILocationService _LocationService;

        public LocationTests()
        {
            _mockLocationRepository = new Mock<ILocationRepository>();
            _LocationService = new LocationService(_mockLocationRepository.Object);
        }


        [Fact]
        public async Task GetLocationsAsync_WhenCalled_ReturnLocationsAsync()
        {
            var Locations = new List<Location>
            {
                new Location {Id = 1 },
                new Location {Id = 2 },
                new Location {Id = 3 }
            };

            _mockLocationRepository.Setup(x => x.GetAllLocationsAsync()).ReturnsAsync(Locations);

            var result = await _LocationService.GetAllLocationsAsync();

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CreateLocationAsync_WhenCalled_ReturnNewLocationAsync()
        {

            var LocationDTO = new CreateLocationDTO
            {
                Name = "Lebanon"
            };

            var Location = new Location
            {
                Name = LocationDTO.Name
            };

            _mockLocationRepository.Setup(x => x.CreateLocationAsync(LocationDTO)).ReturnsAsync(Location);

            var result = await _LocationService.CreateLocationAsync(LocationDTO);

            Assert.NotNull(result);
            Assert.Equal(LocationDTO.Name, result.Name);
        }

        [Fact]
        public async Task UpdateLocationAsync_WhenCalled_ReturnUpdateLocationAsync()
        {

            int LocationId = 1;

            var Location = new Location
            {
                Name = "Madison"
            };

            var editLocationDTO = new UpdateLocationDTO
            {
                Name = "Goodlettsville"
            };

            var updatedLocation = new Location
            {
                Name = editLocationDTO.Name
            };

            _mockLocationRepository.Setup(x => x.GetLocationByIdAsync(LocationId)).ReturnsAsync(Location);
            _mockLocationRepository.Setup(x => x.UpdateLocationAsync(LocationId, editLocationDTO)).ReturnsAsync(updatedLocation);

            var result = await _LocationService.UpdateLocationAsync(LocationId, editLocationDTO);

            Assert.NotNull(result);
            Assert.Equal(editLocationDTO.Name, result.Name);
        }

        [Fact]
        public async Task GetLocationByIdAsync_WhenCalled_ReturnLocationByIdAsync()
        {

            var Location = new Location
            {
                Id = 1,
                Name = "Bowling Green"
            };

            _mockLocationRepository.Setup(x => x.GetLocationByIdAsync(Location.Id)).ReturnsAsync(Location);

            var result = await _LocationService.GetLocationByIdAsync(Location.Id);

            Assert.NotNull(result);
            Assert.Equal(Location.Id, result.Id);
            Assert.Equal(Location.Name, result.Name);
        }

        [Fact]
        public async Task DeleteLocationAsync_WhenCalled_ReturnDeletedLocationAsync()
        {

            var Location = new Location
            {
                Id = 1,
                Name = "Bowling Green"
            };

            _mockLocationRepository.Setup(x => x.GetLocationByIdAsync(Location.Id)).ReturnsAsync(Location);

            await _LocationService.DeleteLocationAsync(Location.Id);

            _mockLocationRepository.Verify(x => x.DeleteLocationAsync(Location.Id), Times.Once);

            _mockLocationRepository.Setup(x => x.GetLocationByIdAsync(Location.Id)).ReturnsAsync((Location)null);
        }
    }
}
