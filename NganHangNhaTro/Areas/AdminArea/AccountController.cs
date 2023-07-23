using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;

namespace NganHangNhaTro.Areas.AdminArea
{
    public class AccountController : Controller
    {
        private readonly IAccountService _services;

        public AccountController(IAccountService services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("dang-nhap")]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new VM_Login { ReturnUrl = returnUrl };
            ViewBag.RegisterMessage = TempData["RegisterMessage"];
            return View(model);
        }
    }
}
