
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using PagedList;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangNhaTro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRealEstateService _services; 

        public HomeController( IRealEstateService service)
        {
            _services = service;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
