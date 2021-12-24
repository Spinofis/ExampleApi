using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRChatV1.Dto;
using SignalRChatV1.Services;

namespace SignalRChatV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly MessageService messageService;

        public MessageController(IMapper _mapper, MessageService _messageService)
        {
            mapper = _mapper;
            messageService = _messageService;
        }

        [HttpPost("message")]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            await messageService.SendMessage(message);
            return Ok();
        }
    }
}
