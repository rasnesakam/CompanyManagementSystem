#pragma checksum "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6427e198dbe9db5a9a63f2e89b090b9b9eba7ebb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
#line 4 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Home\Index.cshtml"
using CMS.Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Home\Index.cshtml"
using CMS.Mvc.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6427e198dbe9db5a9a63f2e89b090b9b9eba7ebb", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CompanyListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<!--begin::Row::DC-->
<div class=""row"">

    <!--Santraller-->
    <div class=""col-lg-6"">
        <!--begin::List Widget 4-->
        <div class=""card card-custom card-stretch gutter-b"">
            <!--begin::Header-->
            <div class=""card-header border-0"">
                <h3 class=""card-title font-weight-bolder text-dark"">Santraller</h3>
                <div class=""card-toolbar"">

                    <div class=""btn-group dropleft"" data-toggle=""tooltip"" title=""Detay"">
                        <!-- Ekleme Kısmı -->
                        <a href=""#"" class=""btn btn-sm-toggle btn-hover-light-primary "" aria-haspopup=""true"" aria-expanded=""false"" data-toggle=""dropdown"">
                            <span class=""svg-icon svg-icon-primary svg-icon-2x"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                    <g stroke=""none"" stroke-w");
            WriteLiteral(@"idth=""1"" fill=""none"" fill-rule=""evenodd"">
                                        <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                        <circle fill=""#000000"" cx=""5"" cy=""12"" r=""2"" />
                                        <circle fill=""#000000"" cx=""12"" cy=""12"" r=""2"" />
                                        <circle fill=""#000000"" cx=""19"" cy=""12"" r=""2"" />
                                    </g>
                                </svg>
                            </span>
                        </a>
                        <ul class=""dropdown-menu dropdown-menu-sm text-center"" role=""menu"" aria-labelledby=""dropdownmenu"" style="" right: 0; left: auto; padding-left: 1px; padding-right: 1px;"">

                            <li>
                                <button class=""dropdown-item dialog-link"" data-href=""");
#nullable restore
#line 38 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Home\Index.cshtml"
                                                                                Write(Url.Action("Central","Add"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" data-title=""Yeni Santral Ekle"">Yeni Ekle</button>
                            </li>

                        </ul>

                    </div>


                </div>
            </div>
            <!--end::Header-->
            <!--begin::Body-->
            <div class=""card-body pt-2 table-responsive"">

                <table class=""table table-borderless"" id=""centralTable"">

                    <thead>
                        <tr>
                            <th scope=""col"">Santral Bilgisi</th>
                            <th scope=""col"">Santral Açıklaması</th>
                            <th></th>
                        </tr>
                    </thead>

                    <tbody id=""loadFromApi"" api-url=""https://localhost:44310/api/Central"">
                        
                        <tr class=""template"">
                            <td>${entry.name}</td>
                            <td>${entry.description}</td>
                            <td>
                  ");
            WriteLiteral(@"              <div class=""btn-group dropleft"" data-toggle=""tooltip"" title=""Detay"">

                                    <a href=""#"" class=""btn btn-sm btn-icon btn-hover-light-primary "" aria-haspopup=""true"" aria-expanded=""false"" data-toggle=""dropdown"">
                                        <span class=""svg-icon svg-icon-primary svg-icon-2x"">
                                            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                                <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                    <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                                    <circle fill=""#000000"" cx=""5"" cy=""12"" r=""2"" />
                                                    <circle fill=""#000000"" cx=""12"" cy=""12"" r=""2"" />
                                                    <circle fill=""#0000");
            WriteLiteral(@"00"" cx=""19"" cy=""12"" r=""2"" />
                                                </g>
                                            </svg>
                                            <!--end::Svg Icon-->
                                        </span>
                                    </a>
                                    <div class=""dropdown-menu dropdown-menu-xsm dropdown-menu-right"">
                                        <ul class=""navi navi-hover text-center"" style="" right: 0; left: auto; padding-left: 1px; padding-right: 1px;"">

                                            <li class=""navi-item"">

                                                <!-- Öge düzenleme -->
                                                <a class=""navi-link dialog-link"" data-href=""/content/includes/edit-central.php/?id=<?php echo $central['id'] ?>"" data-title=""Ögeyi Düzenle"">
                                                    <span class=""navi-icon svg-icon svg-icon-primary svg-icon-sm"">
                          ");
            WriteLiteral(@"                              <!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-03-114926/theme/html/demo1/dist/../src/media/svg/icons/Design/Edit.svg--><svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                                <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                                                <path d=""M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182");
            WriteLiteral(@" Z"" fill=""#000000"" fill-rule=""nonzero"" transform=""translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) "" />
                                                                <rect fill=""#000000"" opacity=""0.3"" x=""5"" y=""20"" width=""15"" height=""2"" rx=""1"" />
                                                            </g>
                                                        </svg>
                                                        <!--end::Svg Icon-->
                                                    </span>
                                                    <span class=""navi-text"">Düzenle</span>

                                                </a>

                                            </li>



                                            <li class=""navi-item"">

                                                <!-- Öge Silme -->
                                                <a class=""navi-link"">
                                                    ");
            WriteLiteral(@"<span class=""navi-icon svg-icon svg-icon-primary svg-icon-sm"">
                                                        <!--begin::Svg Icon | path:/var/www/preview.keenthemes.com/metronic/releases/2020-08-03-114926/theme/html/demo1/dist/../src/media/svg/icons/Home/Trash.svg--><svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                                                            <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                                <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                                                                <path d=""M6,8 L18,8 L17.106535,19.6150447 C17.04642,20.3965405 16.3947578,21 15.6109533,21 L8.38904671,21 C7.60524225,21 6.95358004,20.3965405 6.89346498,19.6150447 L6,8 Z M8,10 L8.45438229,14.0894406 L15.5517885,14.0339036 L16,10 L8,10 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                     ");
            WriteLiteral(@"                                           <path d=""M14,4.5 L14,3.5 C14,3.22385763 13.7761424,3 13.5,3 L10.5,3 C10.2238576,3 10,3.22385763 10,3.5 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z"" fill=""#000000"" opacity=""0.3"" />
                                                            </g>
                                                        </svg>
                                                        <!--end::Svg Icon-->
                                                    </span>
                                                    <span class=""navi-text"">Sil</span>
                                                </a>

                                            </li>

                                        </ul>
                                    </div>

                                </div>
                            </td>


                  ");
            WriteLiteral("      </tr>\r\n                        \r\n                    </tbody>\r\n\r\n                </table>\r\n\r\n\r\n\r\n            </div>\r\n            <!--end::Body-->\r\n        </div>\r\n        <!--end:List Widget 4-->\r\n    </div>\r\n\r\n");
            WriteLiteral("\r\n</div>\r\n<!--end::Row-->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CompanyListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
