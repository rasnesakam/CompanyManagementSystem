#pragma checksum "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91d1444fa087f22b5f23ffca6ffab9b8432857d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Definers__StatusPartialView), @"mvc.1.0.view", @"/Areas/Admin/Views/Definers/_StatusPartialView.cshtml")]
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
#line 2 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
using CMS.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91d1444fa087f22b5f23ffca6ffab9b8432857d6", @"/Areas/Admin/Views/Definers/_StatusPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf8eaebb7b37b07f794698d2cacb95e67f5b1dca", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Definers__StatusPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Status>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<li class=\"list-group-item m-4\">\r\n    <div class=\"d-flex justify-content-between state\">\r\n        <!-- names & stuffs -->\r\n        <div class=\"d-flex flex-row justify-content-start\">\r\n            <div class=\"status-flag\"");
            BeginWriteAttribute("style", " style=\"", 269, "\"", 309, 2);
            WriteAttributeValue("", 277, "background-color:", 277, 17, true);
#nullable restore
#line 9 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
WriteAttributeValue("", 294, Model.ColorHex, 294, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            <div class=\"d-flex flex-column justify-content-start\">\r\n                <p class=\"h2 font-weight-bolder\">");
#nullable restore
#line 11 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
                                            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"text-muted\">");
#nullable restore
#line 12 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
                                 Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n        <!-- control things -->\r\n        <div class=\"d-flex justify-content-center\">\r\n            <a data-href=\"");
#nullable restore
#line 17 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
                     Write(Url.Action("Status","Edit",new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-title=\"Durumu Düzenle\" class=\"m-2 btn btn-sm my-auto dialog-link assds\">\r\n                <i class=\"fas fa-edit\"></i>\r\n            </a>\r\n            <a class=\"m-2 my-auto btn btn-sm dialog-link\" data-href=\"");
#nullable restore
#line 20 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Definers\_StatusPartialView.cshtml"
                                                                Write(Url.Action("Status","Delete",new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-title=\"Durumu Düzenle\">\r\n                <i class=\"fa fa-trash\"></i>\r\n            </a>\r\n        </div>\r\n    </div>\r\n\r\n");
            WriteLiteral("</li>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Status> Html { get; private set; }
    }
}
#pragma warning restore 1591
