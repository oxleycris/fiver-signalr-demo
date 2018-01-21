using System.Collections.Generic;
using Fiver.Asp.SignalR.Server.Data.Entities;
using Fiver.Asp.SignalR.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Asp.SignalR.Server.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet]
        public IEnumerable<Report> GetAll()
        {
            return _reportsService.GetReports();
        }
    }
}