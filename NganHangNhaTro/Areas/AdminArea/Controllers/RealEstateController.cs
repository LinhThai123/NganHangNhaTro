using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NganHangNhaTro.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class RealEstateController : Controller
    {
        private readonly IRealEstateService _services;
        public RealEstateController (IRealEstateService service)
        {
            _services = service;
        }

        [Route("AdminArea/RealEstate/Index")]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Index()
        {
            var list = _services.GetList();
            ViewBag.Message = TempData["Message"];
            return View(list);
        }

        [HttpGet]
        [Route("bai-dang-moi")]
        public IActionResult Create()
        {
            var realEstateTypeList = _services.GetRealEstateTypeList();
            ViewData["RealEstateTypeId"] = new SelectList(realEstateTypeList, "Id", "RealEstateTypeName", realEstateTypeList.First());
            return View();
        }

        [HttpPost]
        [Route("bai-dang-moi")]
        public IActionResult Create(
            [Bind("Title,Address,Price,ContactNumber,Acreage,BeginTime,BackupBeginTime,ExprireTime,BackupExpireTime,RoomNumber,Description,HasPrivateWc,HasMezzanine,AllowCook,FreeTime,SecurityCamera,WaterPrice,ElectronicPrice,WifiPrice,RealEstateTypeId,IsFreeWater,IsFreeElectronic,IsFreeWifi,ImageUrl")]
            VM_RealEstateDetail details, IFormFile? file)
        {
            //int uploadedFilesCount = 0;
            var realEstateTypeList = _services.GetRealEstateTypeList();
            ViewData["RealEstateTypeId"] = new SelectList(realEstateTypeList, "Id", "RealEstateTypeName", details.RealEstateTypeId);

            if (ModelState.IsValid)
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value ?? string.Empty;
                if (userId != string.Empty)
                {
                    var realEstateId = _services.CreateCompleteRealEstate(details, Convert.ToInt32(userId) , file);

                    //tao real estate thanh cong
                    if (realEstateId != -1)
                    {
                        //TempData["Message"] = string.Format("Thêm phòng trọ thành công, uploaded {0} hình ảnh");
                        //TempData["MesageType"] = 1;
                        return RedirectToAction(nameof(ClientRealEstateList));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Có lỗi xảy ra, vui lòng thử lại";
                        return View(details);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "User id không hợp lệ";
                    return View(details);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Có lỗi xảy ra, vui lòng thử lại";
                return View(details);
            }
        }

        //[HttpGet]
        //[Authorize(Roles = "Admin,Manager")]
        //[Route("danh-sach-qua-han")]
        //public IActionResult CustomerExpireList()
        //{
        //    var exprireList = _services.CustomerExpireList();
        //    return View(exprireList);
        //}

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        //[Route("danh-sach-qua-han")]
        public IActionResult CustomerExpireList () 
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        [Route("danh-sach-cho")]
        public IActionResult CustomerConfirmList()
        {
            var confirm = _services.GetCustomerConFirmList();
            return View(confirm);
        }
        

        [HttpGet]
        [Route("danh-sach-bai-viet")]
        public IActionResult ClientRealEstateList()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "UserId").Value ?? string.Empty;

            if (string.IsNullOrEmpty(userId))
            {
                return NotFound();
            }

            var userPosts = _services.GetUserAllPosts(Convert.ToInt32(userId));

            if (userPosts == null) return NotFound();

            ViewBag.Message = TempData["Message"];
            ViewBag.MessageType = TempData["MesageType"];
            return View(userPosts);
        }
        [HttpGet]
        //[Route("update-RealEstate")]
        public async Task<IActionResult> Edit (
            int? id, [FromServices] IAccountService accountService)
        {
            if(id == null)
            {
                return NotFound(); 
            }
            var currentUserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            if (!accountService.IsValidUser(currentUserId, Convert.ToInt32(id)))
            {
                return RedirectToAction("Denied", "Account"); 
            }

            var details = await _services.GetRealEstateDetail(id);
            if (details == null)
            {
                return NotFound();
            }
            var realEstateTypeList = _services.GetRealEstateTypeList();
            ViewData["RealEstateTypeId"] = new SelectList(realEstateTypeList, "Id", "RealEstateTypeName", details.RealEstateTypeId);
            return View(details);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  VM_RealEstateDetail details, IFormFile? file)
        {

            if (id != details.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var isUpdateSuccess = _services.UpdateRealEstate(details , file);
                    if (isUpdateSuccess)
                    {
                        return RedirectToAction(nameof(ClientRealEstateList));
                    }
                    else return View(details);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_services.IsExistRealEstate(details.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRealEsate(int id, int userId)
        {
            var returnCode = _services.DeleteRealEstate(id, userId);

            if (returnCode < 1)
            {
                return Json(new { isSuccess = false, message = "Xảy ra lỗi hệ thống!" });
            }
            else if (returnCode == 2)
            {
                return Json(new { isSuccess = false, message = "User không hợp lệ!" });
            }

            else if (userId != 1)
            {
                return Json(new { isSuccess = true, html = Helper.RenderRazorViewToString(this, "_viewUserAllPosts", _services.GetUserAllPosts(userId)) });
            }
            else
            {
                return Json(new { isSuccess = true, isAdmin = true, html = Helper.RenderRazorViewToString(this, "_viewExpireList", _services.CustomerExpireList()) });
            }

        }


        [HttpPost, ActionName("Confirm")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmRealEstateConfirm(int id, int confirmType, bool isRedirect)
        {
            var isSuccess = _services.ConfirmRealEsate(id, confirmType);

            if (isRedirect)
            {
                return Json(new { isSuccess });
            }
            else
            {
                return Json(new { isSuccess, html = Helper.RenderRazorViewToString(this, "_viewConfirmList", _services.GetCustomerConFirmList()) });
            }
        }

        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public IActionResult DisableRealEsate(int id, int userId, bool isRedirect)
        {
            var isSuccess = _services.DisableRealEstate(id);

            if (isRedirect)
            {
                return Json(new { isSuccess });
            }
            else
            {
                return Json(new { isSuccess, html = Helper.RenderRazorViewToString(this, "_viewUserAllPosts", _services.GetUserAllPosts(userId)) });
            }
        }
    }
}
