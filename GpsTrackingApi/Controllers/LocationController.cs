using GpsTrackingApi.Data;
using GpsTrackingApi.Models;
using GpsTrackingApi.SignalR_Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GpsTrackingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<TrackingHub> _hub;

        public LocationController(AppDbContext context, IHubContext<TrackingHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Location loc)
        {
            _context.Locations.Add(loc);
            await _context.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("ReceiveLocation", loc);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Locations.OrderBy(x => x.CreatedAt));
        }
    }
}
