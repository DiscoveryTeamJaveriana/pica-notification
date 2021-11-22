using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.DTO;

namespace C3P_Notification_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public NotificationController(IEmailService EmailService){

            _emailService = EmailService;
        }

        [Consumes("application/json")]
        [Route("email")]
        [ProducesResponseType(typeof(NotificationResponse), 200)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> sendEmail(EmailMessage message){
            return Ok( await _emailService.SendEmail(message));
        }

        [Consumes("application/json")]
        [Route("health")]
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet]
        public string checkApi() {
            return "API NOTIFICACIONES C3P - OK";
        }
    }
}
