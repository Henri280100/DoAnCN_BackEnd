using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umeAPI.Data;
using umeAPI.Service;

namespace umeSn.Hubs
{

    public class ChatHub : Hub
    {
       // chatsService chats = new chatsService();

        public async Task SendMessage( string friends,string user, string message)
        {
           // Message message1 = new Message { idUser = 0, toUserId =1, content = message };
            await Clients.All.SendAsync("ReceiveMessage", friends, user, message);
           // chats.SendMess(message1);

            
        }
    }
    
}
