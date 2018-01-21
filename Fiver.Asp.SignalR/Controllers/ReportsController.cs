using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Fiver.Asp.SignalR.Models;
using Fiver.Asp.SignalR.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiver.Asp.SignalR.Controllers
{
    public class ReportsController : Controller
    {
        public async Task<ActionResult> Index()
        {
            const string apiUrl = "http://localhost:58179/api/reports";
            var reports = new List<Report>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    reports = JsonConvert.DeserializeObject<List<Report>>(data);
                }
            }

            var model = new ReportsViewModel { Reports = reports };

            return View(model);
        }
    }
}
