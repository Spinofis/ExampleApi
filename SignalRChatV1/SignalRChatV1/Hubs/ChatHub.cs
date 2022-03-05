using Microsoft.AspNetCore.SignalR;
using SignalRChatV1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatV1.Hubs
{
    public class ChatHub : Hub
    {
        public Task NewMessage(Message message)
        {
            return Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
