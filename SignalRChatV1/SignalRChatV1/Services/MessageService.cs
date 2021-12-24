using Microsoft.AspNetCore.SignalR;
using SignalRChatV1.Dto;
using SignalRChatV1.Hubs;
using SignalRChatV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatV1.Services
{
    public class MessageService
    {
        private readonly IHubContext<ChatHub> chatHub;

        public MessageService(IHubContext<ChatHub> hub) => chatHub = hub;

        public async Task SendMessage(MessageDto messageDto)
        {
            await chatHub.Clients.All.SendAsync("ReceiveMessage", messageDto);
        }
    }
}
