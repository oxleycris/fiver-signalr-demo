﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Asp.SignalR.Controllers
{
    public class KeyLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}