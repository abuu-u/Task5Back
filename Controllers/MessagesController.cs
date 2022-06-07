using Microsoft.AspNetCore.Mvc;
using Task5Back.Authorization;
using Task5Back.Models.Messages;
using Task5Back.Services;

namespace Task5Back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Task5/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(SendMessageRequest model)
        {
            string name = (string)HttpContext.Items["Name"];
            await _messageService.Send(model, name);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            string name = (string)HttpContext.Items["Name"];
            GetReceivedMessagesResponse response = await _messageService.GetReceivedMessages(name);
            return Ok(response);
        }
    }
}