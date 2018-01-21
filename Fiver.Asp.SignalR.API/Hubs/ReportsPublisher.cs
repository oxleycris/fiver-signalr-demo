using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Fiver.Asp.SignalR.API.Data;
using Fiver.Asp.SignalR.API.Data.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Fiver.Asp.SignalR.API.Hubs
{
    public class ReportsPublisher : Hub
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private static readonly ConcurrentDictionary<string, string> Connections = new ConcurrentDictionary<string, string>();

        public ReportsPublisher(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task PublishReport(string reportName)
        {
            using (var db = _applicationDbContext)
            {
                var report = new Report { Id = Guid.NewGuid().ToString(), Name = reportName };

                db.Reports.Add(report);
                db.SaveChanges();
            }

            return Clients.All.InvokeAsync("OnReportPublished", reportName);
        }

        public override Task OnConnectedAsync()
        {
            Connections.TryAdd(Context.ConnectionId, Context.User.Identity.Name);
            Clients.All.InvokeAsync("BroadcastMessage", $"{Context.ConnectionId} joined the conversation");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var identityName = Context.User.Identity.Name;

            Connections.TryRemove(Context.ConnectionId, out identityName);
            Clients.All.InvokeAsync("BroadcastMessage", $"{Context.ConnectionId} left the conversation");

            return base.OnDisconnectedAsync(exception);
        }
    }
}
