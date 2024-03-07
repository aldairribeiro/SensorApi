using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensorApi.Domain.Command;
using SensorApi.Infrastructure.Queue;

namespace SensorApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpPost]
        public ActionResult<NewEventCommand> Post([FromBody] NewEventCommand newEvent, [FromServices] IQueueClient queueClient)
        {
            try
            {
                queueClient.Publish<NewEventCommand>("", "sensor-event", newEvent);
                return newEvent;
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao receber o evento.");
            }
        }
    }
}
