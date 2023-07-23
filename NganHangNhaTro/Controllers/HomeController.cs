using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using PagedList;
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int page = 1, int size = 12)
        {
            var list = _services.GetRealEstateIsActiveList();

            // Chuyển đổi danh sách list sang dạng IPagedList<VM_RealEstateIsActive>
            IPagedList<VM_RealEstateIsActive> pagedList = list.ToPagedList(page, size);

            // Truyền pagedList vào view để hiển thị phân trang
            return View(pagedList);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("thong-tin-chi-tiet")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var details = await _services.GetRealEstateDetail(id);
            if (details == null)
            {
                return NotFound();
            }
            else
            {
                //get recommend list
                var recommendList = _services.GetRecommendList(id);
                details.RecommmendList = recommendList;
            }
            return View(details);
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
