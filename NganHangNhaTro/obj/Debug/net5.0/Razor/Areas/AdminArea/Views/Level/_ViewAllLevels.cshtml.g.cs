#pragma checksum "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec71f4679f4aca7b0b3ad83b7be4124cb3299d8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Level__ViewAllLevels), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Level/_ViewAllLevels.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec71f4679f4aca7b0b3ad83b7be4124cb3299d8f", @"/Areas/AdminArea/Views/Level/_ViewAllLevels.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d9280a51607c9797db9363d618a4628c8ce6e46", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_Level__ViewAllLevels : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NganHangNhaTro.Models.DataModels.Level>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "AdminArea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""wrapper wrapper-content animated fadeInRight"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""ibox "">
                <div class=""ibox-title"">
                    <h5>Chức vụ trong hệ thống</h5>
                </div>
                <div class=""ibox-content"">
                    <div class=""row mb-2 ml-0"">
                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 449, "\"", 570, 5);
            WriteAttributeValue("", 459, "showInPopup(\'", 459, 13, true);
#nullable restore
#line 12 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
WriteAttributeValue("", 472, Url.Action("CreateOrEdit","Level",new { id = 0 },Context.Request.Scheme), 472, 73, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 545, "\',\'New", 545, 6, true);
            WriteAttributeValue(" ", 551, "Level", 552, 6, true);
            WriteAttributeValue(" ", 557, "Permission\')", 558, 13, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-yellow col-lg-1 mr-2 text-white\">Thêm mới</a>\r\n");
            WriteLiteral(@"                    </div>

                    <table class=""table table-hover table-bordered"">
                        <thead>
                            <tr>
                                <th class=""text-center"">
                                    Id
                                </th>
                                <th class=""text-center"">
                                    Tên chức vụ
                                </th>
                                <th class=""text-center"">Thao tác</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 29 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"text-center\">\r\n                                        ");
#nullable restore
#line 33 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td class=\"text-center\">");
#nullable restore
#line 35 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
                                                       Write(item.LevelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"text-center\">\r\n                                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1829, "\"", 1949, 5);
            WriteAttributeValue("", 1839, "showInPopup(\'", 1839, 13, true);
#nullable restore
#line 37 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
WriteAttributeValue("", 1852, Url.Action("CreateOrEdit","Level",new {id=item.Id},Context.Request.Scheme), 1852, 75, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1927, "\',\'Update", 1927, 9, true);
            WriteAttributeValue(" ", 1936, "level", 1937, 6, true);
            WriteAttributeValue(" ", 1942, "name\')", 1943, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-blue btn-circle text-white\"><i class=\"fas fa-pen\"></i></a>\r\n\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec71f4679f4aca7b0b3ad83b7be4124cb3299d8f9261", async() => {
                WriteLiteral(@"
                                            <button class=""btn btn-danger btn-circle"" type=""submit"">
                                                <i class=""fas fa-times""></i>
                                            </button>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 46 "D:\BackEnd\NganHangNhaTro\NganHangNhaTro\Areas\AdminArea\Views\Level\_ViewAllLevels.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
