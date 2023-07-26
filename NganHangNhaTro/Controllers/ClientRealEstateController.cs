using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Data;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NganHangNhaTro.Controllers
{
    public class ClientRealEstateController : Controller
    {
        private readonly IRealEstateService _services;
        private readonly MyDbContext _context; 
        public ClientRealEstateController(IRealEstateService services, MyDbContext context)
        {
            _services = services;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12; // Số phần tử trên mỗi trang, bạn có thể thay đổi tùy ý.

            var list = _services.GetRealEstateIsActiveList().ToPagedList(pageNumber, pageSize);

            return View(list);
        }
        public IActionResult FilterByName(string searchName, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 12; // Số phần tử trên mỗi trang, bạn có thể thay đổi tùy ý.

            var results = _services.SearchByTitle(searchName).ToPagedList(pageNumber, pageSize);

            if (searchName != null)
            {
                Console.WriteLine("Tên cần tìm: " + searchName);
            }
            else
            {
                Console.WriteLine("Không có giá trị");
            }

            try
            {
                return View("Index", results);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult SearchRealEstate(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu ô input không có dữ liệu, trả về tất cả sản phẩm
                var list = _services.GetRealEstateIsActiveList().Take(8);
                return Json(list);
            }
            else
            {
                // Nếu có tiêu chí tìm kiếm, trả về danh sách sản phẩm phù hợp
                var list = _services.GetRealEstateIsActiveList()
                    .Where(item => item.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .Take(8);
                return Json(list);
            }
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
    }
}
