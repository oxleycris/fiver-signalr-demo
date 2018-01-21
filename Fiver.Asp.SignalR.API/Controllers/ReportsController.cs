using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiver.Asp.SignalR.API.Data;
using Fiver.Asp.SignalR.API.Data.Entities;
using Fiver.Asp.SignalR.API.Services;
using Fiver.Asp.SignalR.API.Models;

namespace Fiver.Asp.SignalR.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IReportsService _reportsService;

        public ReportsController(ApplicationDbContext dbContext, IReportsService reportsService)
        {
            _dbContext = dbContext;
            _reportsService = reportsService;
        }

        // GET: api/Reports
        [HttpGet]
        public IEnumerable<Report> GetReports()
        {
            return _dbContext.Reports;
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _dbContext.Reports.SingleOrDefaultAsync(m => m.Id == id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        //POST: api/Reports
        [HttpPost]
        public IActionResult PostReport([FromBody] ReportPostRequest report)
        {
            if (string.IsNullOrWhiteSpace(report.Name))
            {
                ModelState.AddModelError("Name", "Report name is required");

                return BadRequest(ModelState);
            }

            var result = new Report { Name = report.Name };

            _reportsService.AddReport(result);

            return CreatedAtAction("GetReport", new { id = result.Id }, result);
        }

        //// DELETE: api/Reports/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteReport([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var report = await _context.Reports.SingleOrDefaultAsync(m => m.Id == id);
        //    if (report == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reports.Remove(report);
        //    await _context.SaveChangesAsync();

        //    return Ok(report);
        //}

        //// PUT: api/Reports/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReport([FromRoute] string id, [FromBody] Report report)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != report.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(report).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReportExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        private bool ReportExists(string id)
        {
            return _dbContext.Reports.Any(e => e.Id == id);
        }
    }
}
