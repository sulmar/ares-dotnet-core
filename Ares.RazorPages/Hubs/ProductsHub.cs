using Ares.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ares.RazorPages.Hubs
{
    public class ProductsHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            // string groupName = this.Context.User.FindFirst(c => c.Type == "Group").Value;

            string groupName = "Grupa 1";

            this.Groups.AddToGroupAsync(this.Context.ConnectionId, groupName);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string groupName = "Grupa 1";

            this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, groupName);
            
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendProduct(Product product)
        {
            // await this.Clients.Others.SendAsync("ChangedProduct", product);

            // string groupName = this.Context.User.FindFirst(c => c.Type == "Group").Value;
            string groupName = "Grupa 1";

            await this.Clients.Group(groupName).SendAsync("ChangedProduct", product);
        }
    }
}
