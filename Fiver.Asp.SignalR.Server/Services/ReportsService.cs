using System;
using System.Collections.Generic;
using System.Text;
using Fiver.Asp.SignalR.Server.Data;
using Fiver.Asp.SignalR.Server.Data.Entities;
using Fiver.Asp.SignalR.Server.Services;

namespace Fiver.Asp.SignalR.Server.Services
{
    public interface IReportsService
    {
        IEnumerable<Report> GetReports();
    }

    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReportsService(ApplicationDbContext applicationDbContext1)
        {
            _applicationDbContext = applicationDbContext1;
        }

        public IEnumerable<Report> GetReports()
        {
            using (var db = _applicationDbContext)
            {
                return db.Reports;
            }
        }
    }
}
