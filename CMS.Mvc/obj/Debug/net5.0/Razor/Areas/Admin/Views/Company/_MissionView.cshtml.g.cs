#pragma checksum "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "244c2713776f7d31cd2a5dea5f7a642c20a5c6f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Company__MissionView), @"mvc.1.0.view", @"/Areas/Admin/Views/Company/_MissionView.cshtml")]
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
#line 1 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
using CMS.Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"244c2713776f7d31cd2a5dea5f7a642c20a5c6f0", @"/Areas/Admin/Views/Company/_MissionView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Company__MissionView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CMS.Entities.Concrete.Mission>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <li id=""mission-<? echo $mission->getId() ?>"" class="" task-list-item done"" :class=""parentClass"">

        <!-- Görev etiketleri -->
        <div class=""task-icon"">
            <div class=""btn-group dropdown"">

                <button class=""btn btn-sm-toggle"" aria-haspopup=""true"" aria-expanded=""false"" data-toggle=""dropdown"">
                    <i class=""fa fa-tags""></i>
                </button>
                <ul class=""dropdown-menu dropdown-menu-sm text-center"" role=""menu"" style="" right: 0; left: auto; padding-left: 1px; padding-right: 1px;"">
");
#nullable restore
#line 14 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                     foreach(MissionTag mt in Model.MissionTags)
                    {
                        Tag t = mt.Entity2;

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>#");
#nullable restore
#line 17 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                        Write(t.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 18 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        
                </ul>
            </div>
        </div>
        <div class=""task-status"">
            <!-- Görev düzenleme Şeysi -->
            <a class=""list-toggle-container dialog-link"" data-title=""Görevi Düzenle"" data-href=""");
#nullable restore
#line 25 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                                                                                           Write(Url.Action("Mission","Add",new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <i class=\"fas fa-edit\"></i>\r\n            </a>\r\n            <!-- Yorumları açma kapama şeysi -->\r\n            <a id=\"comments-toggle-<? echo $mission->getId ?>\" class=\"list-toggle-container\" data-toggle=\"collapse\" data-parent=\"#mission-");
#nullable restore
#line 29 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                                                                                                                                     Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("href", " href=\"", 1413, "\"", 1439, 2);
            WriteAttributeValue("", 1420, "#comments-", 1420, 10, true);
#nullable restore
#line 29 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
WriteAttributeValue("", 1430, Model.Id, 1430, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-expanded=\"false\">\r\n                <i class=\"fa fa-comment\"></i>\r\n            </a>\r\n            <!-- Görevi silme butonu -->\r\n            <a class=\"pending dialog-link\" data-title=\"Görev silinecek\" data-href=\"");
#nullable restore
#line 33 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                                                                              Write(Url.Action("Mission","Delete",new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <i class=\"fa fa-trash\"></i>\r\n            </a>\r\n        </div>\r\n        <!-- Görev içeriği -->\r\n        <div class=\"task-content d-flex flex-row\">\r\n            <div class=\"status-flag\"");
            BeginWriteAttribute("style", " style=\"", 1911, "\"", 1959, 2);
            WriteAttributeValue("", 1919, "background-color:#", 1919, 18, true);
#nullable restore
#line 39 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
WriteAttributeValue("", 1937, Model.Status.ColorHex, 1937, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            <div>\r\n                <h4 class=\"uppercase\">\r\n                    <a>");
#nullable restore
#line 42 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </h4>\r\n                <p>");
#nullable restore
#line 44 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
              Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
        </div>
        <!-- Yorumlar Bölmesi -->
        <div class=""task-list panel-collapse collapse"" id=""comments-<? echo $mission->getId() ?>"">
            <div class=""container"">
                <div class=""row text-lg-center text-uppercase font-weight-boldest border border-1"">
                    <div class=""col-lg-12"">
                        <span class=""text-darkest mr-3"">
                            ");
#nullable restore
#line 53 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </span>
                        <span class=""text-dark"">için yapılan yorumlar</span>
                    </div>
                </div>
                <div class=""row border border-1"">

                    <div class=""col-lg-12"">

                        <!-- See comments -->
                        <div class=""flex-column mb-10"" id=""comments-<? echo $mission->getId() ?>"">
                            
");
#nullable restore
#line 65 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                             if(Model.MissionComments != null) 
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                                 foreach (MissionComment comment in Model.MissionComments) {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                               Write(await Html.PartialAsync("_CommentView", comment));

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                                                                                     ;
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                             
                            else {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"text-center\">Bu görev için yorum yok</span>\r\n");
#nullable restore
#line 72 "C:\Users\ASUS\source\repos\CMS\CMS.Mvc\Areas\Admin\Views\Company\_MissionView.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            ?>
                        </div>
                        <!-- Make Comment -->
                        <div class=""row"">
                            <div class=""col-lg-12"">

                                <div class=""form-group"" id=""comment-<? echo $mission->getID() ?>"">
                                    <!-- Begin::Media files -->
                                    <div id=""media-files-<? echo $mission->getId() ?>"" class=""task-list panel-collapse collapse"">
                                        <div id=""dropzone-<? echo $mission->getId() ?>"" class=""cdropzone dropzone dropzone-default"" id=""dz-<? echo $mission->getId() ?>"">
                                            <div class=""dropzone-msg dz-message needsclick"">
                                                <h3 class=""dropzone-msg-title"">Dosyaları eklemek için sürükleyin</h3>
                                                <span class=""dropzone-msg-desc"">Ve ya buraya dokunun</span>
                        ");
            WriteLiteral(@"                    </div>
                                        </div>
                                    </div>

                                    <!-- End::Media files -->
                                    <!-- Action Buttons -->
                                    <div class=""row"">
                                        <div class=""col-lg-12"">
                                            <!-- send button -->
                                            <button id=""send-<? echo $mission->getId() ?>"" type=""button"" class=""btn-sbmt btn btn-hover-secondary pull-right"">
                                                <i class=""fa fa-paper-plane""></i>
                                            </button>
                                            <!-- media files toggler -->
                                            <button type=""button"" class="" list-toggle-container btn btn-hover-secondary pull-right"" data-toggle=""collapse"" data-parent=""#comment-<? echo $mission->getId() ?>"" href=""#media-f");
            WriteLiteral(@"iles-<? echo $mission->getId() ?>"" aria-expanded=""false"">
                                                <i class=""fa fa-paperclip""></i>
                                            </button>

                                        </div>
                                    </div>
                                    <!-- Comment area -->
                                    <div class=""row"">
                                        <div class=""col-lg-12"">
                                            <textarea class=""form-control border-0 p-1 w-100 h-75px"" id=""comment-text<?php echo $mission->getId() ?>"" placeholder=""<?php echo strtoupper($_SESSION['username']) . "" olarak yorum yap"" ?>""></textarea>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CMS.Entities.Concrete.Mission> Html { get; private set; }
    }
}
#pragma warning restore 1591
