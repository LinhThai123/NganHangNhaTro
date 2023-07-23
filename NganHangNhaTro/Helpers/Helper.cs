using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using NganHangNhaTro.Models.DataModels;
using NganHangNhaTro.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Claims;

namespace NganHangNhaTro.Helpers
{
    public static class Helper
    {
        public static ClaimsPrincipal GenerateIdentity(Agent user)
        {
            var role = user.LevelId switch
            {
                1 => "Admin",
                2 => "Manager",
                3 => "Customer",
                _ => "Customer",
            };

            var claims = new List<Claim>()
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("UserName",user.AgentName),
                new Claim("Phone",user.PhoneNumber),
                new Claim(ClaimTypes.Role , role),
                new Claim("LevelId", user.LevelId.ToString())
            };

            var identity = new ClaimsIdentity(claims, "User Identity");
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
        public static string IsActiveLink(this IHtmlHelper htmlHelper, string controller, string action = "")
        {
            bool returnActive;
            var routeData = htmlHelper.ViewContext.RouteData;

            var routeController = routeData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(action))
            {
                returnActive = (controller == routeController);
            }
            else
            {
                var routeAction = routeData.Values["action"].ToString();
                returnActive = (controller == routeController && action == routeAction);
            }

            return returnActive ? "active" : "";
        }
        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetRequiredService<ICompositeViewEngine>();
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                if (!viewResult.Success)
                {
                    throw new InvalidOperationException($"View '{viewName}' not found.");
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );

                var view = viewResult.View;
                var task = view.RenderAsync(viewContext);
                task.Wait();

                return sw.GetStringBuilder().ToString();
            }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class NoDirectAccessAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (filterContext.HttpContext.Request.GetTypedHeaders().Referer == null ||
                    filterContext.HttpContext.Request.GetTypedHeaders().Host.Host.ToString() != filterContext.HttpContext.Request.GetTypedHeaders().Referer.Host.ToString())
                {
                    filterContext.Result = new RedirectToRouteResult(new
                           RouteValueDictionary(new { area = "AdminArea", controller = "RealEstate", action = "ClientRealEstateList" }));
                }
            }
        }
        public static string VNCurrencyFormat(string money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return double.Parse(money).ToString("#,###", cul.NumberFormat);
        }

        public static string GetStatus(RealEstate realEstate)
        {
            //neu rt chua di disable => kiem tra het han hay chua
            if (realEstate.IsActive)
            {
                if (!realEstate.IsConfirm)
                {
                    return "Chờ xác nhận";
                }
                else if (realEstate.ConfirmStatus > 1)
                {
                    return "Bị từ chối";
                }

                if (realEstate.IsAvaiable)
                {
                    if (realEstate.ExprireTime == null)
                    {
                        return realEstate.PostTime.AddDays(30) < DateTime.Now ? "Hết hạn" : "Còn phòng";
                    }

                    //truong hop co ngay het han
                    else
                    {
                        //neu ngay het han < ngay hien tai thi het han
                        return realEstate.ExprireTime < DateTime.Now ? "Hết hạn" : "Còn phòng";
                    }
                }
                else return "Hết phòng";
            }
            else return "Đã khóa";
        }

        public static VM_RealEstateDetail MappingFromRealEstate(RealEstate info)
        {
            var result = new VM_RealEstateDetail()
            {
                Id = info.Id,
                Title = info.Title ?? string.Empty,
                Address = info.Address ?? string.Empty,
                Price = info.Price,
                Acreage = info.Acreage,
                ContactNumber = info.ContactNumber,
                PostTime = info.PostTime.ToString("dd/MM/yyyy"),
                LastUpdate = info.LastUpdate?.ToString("dd/MM/yyyy"),
                BeginTime = info.BeginTime.ToString("dd/MM/yyyy"),
                ExprireTime = info.ExprireTime?.ToString("dd/MM/yyyy"),
                RoomNumber = info.RoomNumber,
                Description = info.Description,
                AgentId = info.Agent.Id,
                AgentName = info.Agent.AgentName,
                HasPrivateWc = info.HasPrivateWc,
                HasMezzanine = info.HasMezzanine,
                AllowCook = info.AllowCook,
                FreeTime = info.FreeTime,
                SecurityCamera = info.SecurityCamera,
                WaterPrice = info.WaterPrice ?? 0,
                ElectronicPrice = info.ElectronicPrice ?? 0,
                WifiPrice = info.WifiPrice ?? 0,       
                RealEstateTypeId = info.Id,
                IsActive = info.IsActive,
                IsConfirm = info.IsConfirm,
                ViewCount = info.ViewCount ?? 0,
                imageUrl = info.imageUrl, 
                Status = GetStatus(info)

            };
            return result;
        }

        public static decimal[] GetPriceRange(int priceRange)
        {
            decimal min;
            decimal max;

            if (priceRange == 1) //duoi 1tr
            {
                min = 0;
                max = 1000000;
            }
            else if (priceRange == 2) //1tr-2tr
            {
                min = 1000000;
                max = 2000000;
            }
            else if (priceRange == 3) //2tr-3tr
            {
                min = 2000000;
                max = 3000000;
            }
            else if (priceRange == 4) //3tr-5tr
            {
                min = 3000000;
                max = 5000000;
            }
            else if (priceRange == 5) //5tr-7tr
            {
                min = 5000000;
                max = 7000000;
            }
            else if (priceRange == 6) //7tr-10tr
            {
                min = 7000000;
                max = 10000000;
            }
            else if (priceRange == 7) //tren 10tr
            {
                min = 10000000;
                max = decimal.MaxValue;
            }
            else //chon tat ca
            {
                min = 0;
                max = decimal.MaxValue;
            }
            var result = new decimal[] { min, max };

            return result;
        }
        public static string GetStreet(string address)
        {
            return address.Split(",")[0];
        }

        public static int[] GetAcreageRange(int acreageRange)
        {

            int min;
            int max;
            if (acreageRange == 1) //duoi 20m2
            {
                min = 0;
                max = 20;
            }
            else if (acreageRange == 2) //20m2-30m2
            {
                min = 20;
                max = 30;
            }
            else if (acreageRange == 3) //30-50m2
            {
                min = 30;
                max = 50;
            }
            else if (acreageRange == 4) //50-60m2
            {
                min = 50;
                max = 60;
            }
            else if (acreageRange == 5) //60-70m2
            {
                min = 60;
                max = 70;
            }
            else if (acreageRange == 6) //70-80m2
            {
                min = 70;
                max = 80;
            }
            else if (acreageRange == 7) //80-90m2
            {
                min = 80;
                max = 90;
            }
            else if (acreageRange == 8) //90-100m2
            {
                min = 90;
                max = 100;
            }
            else if (acreageRange == 9) //tren 100m2
            {
                min = 100;
                max = int.MaxValue;
            }
            else //chon tat ca
            {
                min = 0;
                max = 999;
            }
            var result = new int[] { min, max };

            return result;
        }

        public static Dictionary<string, int> GetAcreageRangeForView()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"Tất cả",0 },
                {"Dưới 20m2",1 },
                {"20m2 - 30m2",2 },
                {"30m2 - 50m2",3 },
                { "50m2 - 60m2",4},
                { "60m2 - 70m2",5},
                {"70m2 - 80m2",6 },
                {"80m2 - 90m2",7 },
                {"90m2 - 100m2",8 },
                {"Trên 100m2",9 }
            };
            return dictionary;
        }

        public static Dictionary<string, int> GetPriceRangeForView()
        {
            var dictionary = new Dictionary<string, int>
            {
                {"Tất cả",0 },
                {"Dưới 1 triệu",1 },
                {"1 triệu - 2 triệu",2 },
                {"2 triệu - 3 triệu",3 },
                {"3 triệu - 5 triệu",4 },
                {"5 triệu - 7 triệu",5 },
                {"7 triệu - 10 triệu",6 },
                {"Trên 10 triệu",7 }
            };
            return dictionary;
        }
    }
}
