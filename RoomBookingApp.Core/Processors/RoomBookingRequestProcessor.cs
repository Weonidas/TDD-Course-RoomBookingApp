using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        public RoomBookingRequestProcessor()
        {
        }

        public RoomBookingResult BookRoom(RoomBookingRequest request)
        {
            return new RoomBookingResult
            {
                Date = request.Date,
                Email = request.Email,
                FullName = request.FullName
            };
        }
    }
}