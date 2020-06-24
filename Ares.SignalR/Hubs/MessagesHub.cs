using Ares.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ares.SignalR.Hubs
{
   // [Authorize]
    public class MessagesHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            string connectionId = this.Context.ConnectionId;

            ClaimsPrincipal principal = this.Context.User;

            return base.OnConnectedAsync();
        }

        public async Task SendMessage(Message message)
        {
            await this.Clients.All.SendAsync("YouHaveGotMessage", message);
        }

        public async Task Ping()
        {
            await Clients.Caller.SendAsync("Pong");
        }
    }
}
