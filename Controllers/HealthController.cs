using Microsoft.AspNetCore.Mvc;

namespace GotaNotificationMS.Controllers
{
    [Route("/")]
    public class HealthController : Controller {
        public IActionResult Get() {
            return Ok("OK");
        }
    }
}