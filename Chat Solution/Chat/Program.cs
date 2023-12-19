using Chat.Contexts;
using Chat.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Chat
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region Configration Services

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ChatDbContext>(Option =>
            {
                Option.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnections"));
            });

            builder.Services.AddSignalR();
            #endregion

            var app = builder.Build();

            #region App Configration

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/Chat");
            });

            #endregion

            app.Run();
        }
    }
}