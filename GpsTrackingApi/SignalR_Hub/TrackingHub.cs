using GpsTrackingApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace GpsTrackingApi.SignalR_Hub
{
    public class TrackingHub : Hub
    {
        public async Task SendLocation(Location loc)
        {
            await Clients.All.SendAsync("ReceiveLocation", loc);
        }
    }
}
