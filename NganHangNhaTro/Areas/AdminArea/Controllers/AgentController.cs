using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Data;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;

namespace NganHangNhaTro.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    //[Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService _services;
        public AgentController(IAgentService services)
        {
            _services = services;
        }

        // GET: AdminArea/Agent
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var agents = await _services.GetListAgent();
            return View(agents);
        }

        [HttpGet]
        [Route("thong-tin-ca-nhan")]
        public IActionResult UpdateProfile()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value ?? string.Empty;

            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            var userInfo = _services.GetUserInfo(Convert.ToInt32(userId));

            ViewBag.UpdatePassStatus = TempData["UpdatePassStatus"];

            return View(userInfo);
        }
        [HttpPost]
        [Route("thong-tin-ca-nhan")]
        public IActionResult UpdateProfile(VM_Agent updateProfile)
        {
            if (ModelState.IsValid)
            {
                var status = _services.UpdateProfile(updateProfile);

                return Json(new { status });
            }

            return View(updateProfile);
        }

        [HttpGet]
        [Route("doi-mat-khau")]
        public IActionResult UpdatePassword()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value ?? string.Empty;

            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            var viewmodel = new VM_ChangePassword() { Id = Convert.ToInt32(userId) };
            return View(viewmodel);
        }

        [HttpPost]
        [Route("doi-mat-khau")]
        public IActionResult UpdatePassword(VM_ChangePassword data)
        {
            if (ModelState.IsValid)
            {
                int resultCode = _services.UpdatePassword(data);

                if (resultCode == 1)
                {
                    TempData["UpdatePassStatus"] = "Cập nhật mật khẩu thành công!";

                    return RedirectToAction("UpdateProfile");
                }
                else if (resultCode == 0)
                {
                    ViewBag.Message = "Mật khẩu cũ không chính xác!";
                    ViewBag.MesasageCode = 0;
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra, vui lòng thử lại!";
                    ViewBag.MesasageCode = -1;
                }
                return View(data);
            }

            return View(data);
        }
        // Đang làm đến đây

        //[Authorize(Roles = "Admin")]
        //[HttpPost, ActionName("Disable")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DisableConfirm(int id)
        //{
        //    var isSuccess = await _services.Disable(id);
        //    return Json(new { isSuccess, html = Helper.RenderRazorViewToString(this, "_ViewAllAgents", await _services.GetListAgent()) });
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirm(int id)
        //{
        //    var isSuccess = await _services.Delete(id);
        //    return Json(new { isSuccess, html = Helper.RenderRazorViewToString(this, "_ViewAllAgents", await _services.GetListAgent()) });
        //}

    }
}
