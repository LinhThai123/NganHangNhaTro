using HakunaMatata.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangNhaTro.Controllers
{
    public class ClientRealEstateController : Controller
    {
        private readonly IRealEstateService _services; 

        public ClientRealEstateController(IRealEstateService services)
        {
            _services = services;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var list = _services.GetRealEstateIsActiveList();
           return View(list);
        }
    }
}
