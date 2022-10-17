using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingApp.Core
{
    public class RoomBookingRequestProcessorTest
    {
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            var request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@mail.com",
                Date = new DateTime(2022, 10, 15)
            };

            var processor = new RoomBookingRequestProcessor();

            RoomBookingResult result = processor.BookRoom(request);

            Assert.NotNull(result);
            Assert.Equal(request.FullName, result.FullName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }
    }
}
