using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Services;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var availableRooms = _roomBookingService.GetAvailableRooms(request.Date);

            if(availableRooms.Any())
            {
                var room = availableRooms.First();
                var roomBooking = CreateRoomBookingObject<RoomBooking>(request);
                roomBooking.RoomId = room.Id;
                _roomBookingService.Save(roomBooking);
            }   

            return CreateRoomBookingObject<RoomBookingResult>(request);
        }

        private static TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest bookingRequest) where TRoomBooking : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = bookingRequest.FullName,
                Date = bookingRequest.Date,
                Email = bookingRequest.Email,
            };
        }
    }
}