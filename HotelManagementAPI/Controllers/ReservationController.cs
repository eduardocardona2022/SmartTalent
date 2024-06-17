using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {

        private readonly ReservationService _service = Singleton.Instance.ReservationService;

        [HttpGet("GetAllReservations")]
        public ActionResult<IEnumerable<Reservation>> GetAllReservations()
        {
            try
            {
                return _service.GetAllReservations();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("AddReservation")]
        public ActionResult AddReservation(Reservation reservation)
        {
            try
            {
                _service.AddReservation(reservation);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpGet("GetFilterReservations")]
        public ActionResult<IEnumerable<Reservation>> GetFilterReservations(Reservation filter)
        {
            try
            {
                return _service.GetFilterReservations(filter);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}

