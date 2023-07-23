using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models.ViewModels;
using NganHangNhaTro.Service;
using System.Threading.Tasks;

namespace NganHangNhaTro.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _services; 

        public AccountController (IAccountService services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl = "")
        {
            var model = new VM_Login { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(VM_Login account, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var member = _services.GetUser(account);
                if (member != null)
                {
                    // Tạo User Principal dựa trên thông tin đăng nhập của người dùng
                    var userPrincipal = Helper.GenerateIdentity(member);

                    // Đăng nhập người dùng
                    await HttpContext.SignInAsync(
                        scheme: "MyCookieScheme",
                        principal: userPrincipal,
                        properties: new AuthenticationProperties
                        {
                            IsPersistent = account.IsRememberMe
                        }
                    );

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid user or password!";
                }
            }
            return View(account);
        }

        public IActionResult Register(string returnUrl = "")
        {
            var model = new VM_Register
            {
                ReturnUrl = returnUrl,
            }; 
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(VM_Register registerAccount)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = await _services.RegisterUser(registerAccount);
                if (isSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(registerAccount);
        }
        public IActionResult Denied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            scheme: "MyCookieScheme"
            );

            return RedirectToAction("Index", "Home");
        }
    }
}
