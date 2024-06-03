using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace HotelManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _service = Singleton.Instance.RoomService;

        [HttpGet("GetAllRooms")]
        public ActionResult<IEnumerable<Room>> GetAllRooms()
        {
            try
            {
                return _service.GetAllRooms();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("AddRoom")]
        public ActionResult AddRoom(Room room)
        {
            try
            {
                _service.AddRoom(room);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut("UpdateRoom")]
        public ActionResult UpdateRoom(Room room)
        {
            try
            {
                _service.UpdateRoom(room);
                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut("{id}/enable-disable")]
        public ActionResult EnableDisableRoom(int id, bool isEnabled)
        {
            _service.EnableDisableRoom(id, isEnabled);
            return Ok();
        }
    }
}
