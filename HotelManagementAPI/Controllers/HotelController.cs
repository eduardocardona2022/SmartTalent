using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {

        private readonly HotelService _hotelService = Singleton.Instance.HotelService;


        [HttpGet("GetAllHotels")]
        public ActionResult<IEnumerable<Hotel>> GetAllHotels()
        {
            try
            {
                return _hotelService.GetAllHotels();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }

        [HttpPost("AddHotel")]
        public ActionResult AddHotel(Hotel hotel)
        {
            try
            {
                _hotelService.AddHotel(hotel);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut("UpdateHotel")]
        public ActionResult UpdateHotel(Hotel hotel)
        {
            try
            {
                _hotelService.UpdateHotel(hotel);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut("{id}/enable-disable")]
        public ActionResult EnableDisableHotel(int id, bool isEnabled)
        {
            try
            {
                _hotelService.EnableDisableHotel(id, isEnabled);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
