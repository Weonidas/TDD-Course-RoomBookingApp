using RoomBookingApp.Core.Enums;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Services;
using RoomBookingApp.Domain;
using RoomBookingApp.Domain.BaseModels;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor : IRoomBookingRequestProcessor
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
            var roomBookingResult = CreateRoomBookingObject<RoomBookingResult>(request);

            if (availableRooms.Any())
            {
                var room = availableRooms.First();
                var roomBooking = CreateRoomBookingObject<RoomBooking>(request);
                roomBooking.RoomId = room.Id;
                _roomBookingService.Save(roomBooking);

                roomBookingResult.RoomBookingId = roomBooking.Id;
                roomBookingResult.ResultFlag = BookingResultFlag.Success;
            }
            else
                roomBookingResult.ResultFlag = BookingResultFlag.Failure;

            return roomBookingResult;
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