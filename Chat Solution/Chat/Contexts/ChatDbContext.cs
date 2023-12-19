using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Contexts
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }

        public DbSet<ChatMassage> Massages { get; set; }
    }
}
