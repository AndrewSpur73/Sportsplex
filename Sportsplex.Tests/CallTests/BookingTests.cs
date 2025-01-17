﻿using Moq;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;
using Sportsplex.Services;

namespace Sportsplex.Tests.CallTests
{
    public class BookingTests
    {

        private readonly Mock<IBookingRepository> _mockBookingRepository;
        private readonly IBookingService _BookingService;

        public BookingTests()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
            _BookingService = new BookingService(_mockBookingRepository.Object);
        }

        [Fact]
        public async Task GetBookingsAsync_WhenCalled_ReturnBookingsAsync()
        {
            // Arrange: Set up mock data and repository behavior
            var Bookings = new List<Booking>
    {
        new Booking {Id = 1 },
        new Booking {Id = 2 },
        new Booking {Id = 3 }
    };

            _mockBookingRepository.Setup(x => x.GetAllBookingsAsync()).ReturnsAsync(Bookings);

            // Act: Call the service method
            var result = await _BookingService.GetAllBookingsAsync();

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CreateBookingAsync_WhenCalled_ReturnNewBookingAsync()
        {
            // Arrange: Set up DTO, expected entity, and repository behavior
            var BookingDTO = new CreateBookingDTO
            {
                OwnerId = 1,
                Image = "string",
                Description = "more string",
                Rsvps = 7,
                ReservedDate = DateTime.Now,
                CategoryId = 2
            };

            var Booking = new Booking
            {
                OwnerId = BookingDTO.OwnerId,
                Image = BookingDTO.Image,
                Description = BookingDTO.Description,
                Rsvps = BookingDTO.Rsvps,
                ReservedDate = BookingDTO.ReservedDate,
                CategoryId = BookingDTO.CategoryId,
            };

            _mockBookingRepository.Setup(x => x.CreateBookingAsync(BookingDTO)).ReturnsAsync(Booking);

            // Act: Call the service method
            var result = await _BookingService.CreateBookingAsync(BookingDTO);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(BookingDTO.OwnerId, result.OwnerId);
            Assert.Equal(BookingDTO.Image, result.Image);
            Assert.Equal(BookingDTO.Description, result.Description);
            Assert.Equal(BookingDTO.Rsvps, result.Rsvps);
            Assert.Equal(BookingDTO.ReservedDate, result.ReservedDate);
            Assert.Equal(BookingDTO.CategoryId, result.CategoryId);
        }

        [Fact]
        public async Task UpdateBookingAsync_WhenCalled_ReturnUpdateBookingAsync()
        {
            // Arrange: Set up the ID, original entity, DTO, updated entity, and repository behavior
            int Bookingid = 1;

            var Booking = new Booking
            {
                OwnerId = Bookingid,
                Image = "original string",
                Description = "more string",
                Rsvps = 7,
                ReservedDate = DateTime.Now,
                CategoryId = 2
            };

            var editBookingDTO = new UpdateBookingDTO
            {
                Image = "not string",
                Description = "less string",
                ReservedDate = DateTime.Now,
                CategoryId = 3
            };

            var updatedBooking = new Booking
            {
                Image = editBookingDTO.Image,
                Description = editBookingDTO.Description,
                ReservedDate = editBookingDTO.ReservedDate,
                CategoryId = editBookingDTO.CategoryId
            };

            _mockBookingRepository.Setup(x => x.GetBookingByIdAsync(Bookingid)).ReturnsAsync(Booking);
            _mockBookingRepository.Setup(x => x.UpdateBookingAsync(Bookingid, editBookingDTO)).ReturnsAsync(updatedBooking);

            // Act: Call the service method
            var result = await _BookingService.UpdateBookingAsync(Bookingid, editBookingDTO);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(editBookingDTO.Image, result.Image);
            Assert.Equal(editBookingDTO.Description, result.Description);
            Assert.Equal(editBookingDTO.ReservedDate, result.ReservedDate);
            Assert.Equal(editBookingDTO.CategoryId, result.CategoryId);
        }

        [Fact]
        public async Task DeleteBookingAsync_WhenCalled_ReturnDeletedBookingAsync()
        {
            // Arrange: Set up the ID, entity, and repository behavior
            int BookingId = 1;

            var Booking = new Booking
            {
                Id = BookingId
            };

            _mockBookingRepository.Setup(x => x.GetBookingByIdAsync(BookingId)).ReturnsAsync(Booking);

            // Act: Call the service method
            await _BookingService.DeleteBookingAsync(BookingId);

            // Assert: Verify the deletion
            _mockBookingRepository.Verify(x => x.DeleteBookingAsync(BookingId), Times.Once);
            _mockBookingRepository.Setup(x => x.GetBookingByIdAsync(BookingId)).ReturnsAsync((Booking)null);
        }

        [Fact]
        public async Task GetSingleBookingAsync_WhenCalled_ReturnsBooking()
        {
            // Arrange: Set up the ID, entity, and repository behavior
            int BookingId = 1;
            var Booking = new Booking
            {
                Id = 1,
                OwnerId = 2,
                Image = "image",
                Description = "Description",
                Rsvps = 10,
                ReservedDate = DateTime.Now,
                CategoryId = 2
            };

            _mockBookingRepository.Setup(x => x.GetBookingByIdAsync(BookingId)).ReturnsAsync(Booking);

            // Act: Call the service method
            var result = await _BookingService.GetBookingByIdAsync(BookingId);

            // Assert: Verify the result
            Assert.NotNull(result);
            Assert.Equal(Booking.Id, result.Id);
            Assert.Equal(Booking.Description, result.Description);
            Assert.Equal(Booking.Image, result.Image);
            Assert.Equal(Booking.Rsvps, result.Rsvps);
            Assert.Equal(Booking.ReservedDate, result.ReservedDate);
            Assert.Equal(Booking.CategoryId, result.CategoryId);
        }
    }
}
