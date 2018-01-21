using System;
using System.Threading.Tasks;
using Fiver.Asp.SignalR.Server.Data;
using Fiver.Asp.SignalR.Server.Data.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Fiver.Asp.SignalR.Server
{
    public class ReportsPublisher : Hub
    {
        private readonly ApplicationDbContext _applicationDbContext;

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
    }
}
