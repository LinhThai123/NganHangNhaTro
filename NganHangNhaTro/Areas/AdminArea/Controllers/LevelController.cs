using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Data;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Service;
using static NganHangNhaTro.Helpers.Helper;

namespace NganHangNhaTro.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    //[Authorize(Roles = "Admin")]
    public class LevelController : Controller
    {
        private readonly ILevelService _services;
        public LevelController(ILevelService services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var levels = _services.GetListLevels();
            return View(levels);
        }

        [NoDirectAccess]
        public IActionResult CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Level());
            }
            else
            {
                var level = _services.GetDetails(id);
                if (level == null)
                {
                    return NotFound();
                }
                return View(level);
            }

        }

        [HttpPost]
        public IActionResult CreateOrEdit(int id, [Bind("Id,LevelName")] Level level)
        {
            if (ModelState.IsValid)
            {
                //insert
                if (id == 0)
                {
                    _services.Create(level);
                }

                //update
                else
                {
                    try
                    {
                        _services.UpdateLevel(level);
                    }
                    catch (Exception)
                    {
                        if (!_services.IsExist(level.Id))
                        {
                            return NotFound();
                        }
                        else throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllLevels", _services.GetListLevels()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateOrEdit", level) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            _services.DeleteLevel(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAllLevels", _services.GetListLevels()) });
        }
    }
}
