using System.Collections.Generic;
using Fiver.Asp.SignalR.API.Data;
using Fiver.Asp.SignalR.API.Data.Entities;

namespace Fiver.Asp.SignalR.API.Services
{
    public interface IReportsService
    {
        IEnumerable<Report> GetReports();
        void AddReport(Report result);
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

        public void AddReport(Report report)
        {
            using (var db = _applicationDbContext)
            {
                db.Reports.Add(report);
                db.SaveChanges();
            }
        }
    }
}
