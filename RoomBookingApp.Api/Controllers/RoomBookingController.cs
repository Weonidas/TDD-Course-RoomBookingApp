using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBookingApp.Core.Enums;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;

namespace RoomBookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly IRoomBookingRequestProcessor _processor;

        public RoomBookingController(IRoomBookingRequestProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> BookRoom(RoomBookingRequest bookingRequest)
        {
            if(ModelState.IsValid)
            {
                var result = _processor.BookRoom(bookingRequest);
                if (result.ResultFlag == BookingResultFlag.Success)
                    return Ok(result);
                else
                    ModelState.AddModelError(nameof(RoomBookingRequest.Date), "No Rooms Available for this specific Date");
            }

            return BadRequest(ModelState);
        }
    }
}
