#pragma checksum "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\RealEstateType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "87d9ce63239bd583bcb3a3107cb53fac28723762"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_RealEstateType_Index), @"mvc.1.0.view", @"/Areas/AdminArea/Views/RealEstateType/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\_ViewImports.cshtml"
using NganHangNhaTro;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\_ViewImports.cshtml"
using NganHangNhaTro.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\_ViewImports.cshtml"
using NganHangNhaTro.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87d9ce63239bd583bcb3a3107cb53fac28723762", @"/Areas/AdminArea/Views/RealEstateType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9280a51607c9797db9363d618a4628c8ce6e46", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_RealEstateType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NganHangNhaTro.Models.DataModels.RealEstateType>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\RealEstateType\Index.cshtml"
   ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div id=\"view-all\">\n    ");
#nullable restore
#line 6 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\RealEstateType\Index.cshtml"
Write(await Html.PartialAsync("_ViewAllTypes", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NganHangNhaTro.Models.DataModels.RealEstateType>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
