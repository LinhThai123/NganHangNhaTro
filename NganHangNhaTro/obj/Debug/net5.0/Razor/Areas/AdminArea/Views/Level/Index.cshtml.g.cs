#pragma checksum "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d01f89ed3ac83ff3e5acd4bd9612456c4a8342b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Level_Index), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Level/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d01f89ed3ac83ff3e5acd4bd9612456c4a8342b", @"/Areas/AdminArea/Views/Level/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9280a51607c9797db9363d618a4628c8ce6e46", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_Level_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NganHangNhaTro.Models.DataModels.Level>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"view-all\">\r\n    ");
#nullable restore
#line 8 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\Index.cshtml"
Write(await Html.PartialAsync("_ViewAllLevels", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NganHangNhaTro.Models.DataModels.Level>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
