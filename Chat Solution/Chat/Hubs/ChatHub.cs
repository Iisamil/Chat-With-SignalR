using Chat.Contexts;
using Chat.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        private readonly ChatDbContext _context;

        public ChatHub(ILogger<ChatHub> logger, ChatDbContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public async Task Send (string user, string message)
        {
            await Clients.All.SendAsync ("ReceiveMessage",user, message);

            ChatMassage massage = new ChatMassage()
            {
                Text = message,
                UserName = user
            };

            _context.Massages.Add (massage);
            await _context.SaveChangesAsync();
        }
    }
}
