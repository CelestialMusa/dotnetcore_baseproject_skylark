#pragma checksum "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_SidebarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c988ce08a7a1869846667f92b9c9772412dbac8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SidebarPartial), @"mvc.1.0.view", @"/Views/Shared/_SidebarPartial.cshtml")]
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
#line 1 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\_ViewImports.cshtml"
using Skylark;

#line default
#line hidden
#line 2 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\_ViewImports.cshtml"
using Skylark.Models;

#line default
#line hidden
#line 3 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\_ViewImports.cshtml"
using Skylark.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c988ce08a7a1869846667f92b9c9772412dbac8c", @"/Views/Shared/_SidebarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92dd7acc71680614a25ea1911fe6f35a41d0d535", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SidebarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "small", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "medium", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "large", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"customizer border-left-blue-grey border-left-lighten-4 d-none d-sm-none d-md-block\">\r\n    <a class=\"customizer-close\"><i class=\"ft-x font-medium-3\"></i></a><a id=\"rtl-icon\"");
            BeginWriteAttribute("href", " href=\"", 184, "\"", 191, 0);
            EndWriteAttribute();
            WriteLiteral(@" target=""_blank"" class=""bg-dark customizer-toggle""><span class=""font-medium-1 white align-middle"">RTL</span></a><a id=""customizer-toggle-icon"" class=""customizer-toggle bg-danger""><i class=""ft-settings font-medium-4 fa fa-spin white align-middle""></i></a>
    <div data-ps-id=""df6a5ce4-a175-9172-4402-dabd98fc9c0a"" class=""customizer-content p-3 ps-container ps-theme-dark"">
        <h4 class=""text-uppercase mb-0 text-bold-400"">Theme Customizer</h4>
        <p>Customize & Preview in Real Time</p>
        <hr>
        <!-- Layout Options-->
        <h6 class=""text-center text-bold-500 mb-3 text-uppercase"">Layout Options</h6>
        <div class=""layout-switch ml-4"">
            <div class=""custom-control custom-radio d-inline-block custom-control-inline light-layout"">
                <input id=""ll-switch"" type=""radio"" name=""layout-switch"" checked class=""custom-control-input"">
                <label for=""ll-switch"" class=""custom-control-label"">Light</label>
            </div>
            <div class=""custo");
            WriteLiteral(@"m-control custom-radio d-inline-block custom-control-inline dark-layout"">
                <input id=""dl-switch"" type=""radio"" name=""layout-switch"" class=""custom-control-input"">
                <label for=""dl-switch"" class=""custom-control-label"">Dark</label>
            </div>
            <div class=""custom-control custom-radio d-inline-block custom-control-inline transparent-layout"">
                <input id=""tl-switch"" type=""radio"" name=""layout-switch"" class=""custom-control-input"">
                <label for=""tl-switch"" class=""custom-control-label"">Transparent</label>
            </div>
        </div>
        <hr>
        <!-- Sidebar Options Starts-->
        <h6 class=""text-center text-bold-500 mb-3 text-uppercase sb-options"">Sidebar Color Options</h6>
        <div class=""cz-bg-color sb-color-options"">
            <div class=""row p-1"">
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""pomegranate"" class=""gradient-pomegranate d-block rounded-circle""></span>");
            WriteLiteral(@"</div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""king-yna"" class=""gradient-king-yna d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""ibiza-sunset"" class=""gradient-ibiza-sunset d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""flickr"" class=""gradient-flickr d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""purple-bliss"" class=""gradient-purple-bliss d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""man-of-steel"" class=""gradient-man-of-steel d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""purple-love"" class=""gradient-purple-love d-block rounded-circle""></span></div>
            </div>
    ");
            WriteLiteral(@"        <div class=""row p-1"">
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""black"" class=""bg-black d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""white"" class=""bg-grey d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""primary"" class=""bg-primary d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""success"" class=""bg-success d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""warning"" class=""bg-warning d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""info"" class=""bg-info d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""dan");
            WriteLiteral(@"ger"" class=""bg-danger d-block rounded-circle""></span></div>
            </div>
        </div>
        <!-- Sidebar Options Ends-->
        <!-- Transparent Layout Bg color Options-->
        <h6 class=""text-center text-bold-500 mb-3 text-uppercase tl-color-options d-none"">Background Colors</h6>
        <div class=""cz-tl-bg-color d-none"">
            <div class=""row p-1"">
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""hibiscus"" class=""bg-hibiscus d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""bg-purple-pizzazz"" class=""bg-purple-pizzazz d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""bg-blue-lagoon"" class=""bg-blue-lagoon d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""bg-electric-viloet"" class=""bg-electric-violet d-block rounded-circ");
            WriteLiteral(@"le""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""bg-protage"" class=""bg-portage d-block rounded-circle""></span></div>
                <div class=""col""><span style=""width:20px; height:20px;"" data-bg-color=""bg-tundora"" class=""bg-tundora d-block rounded-circle""></span></div>
            </div>
        </div>
        <!-- Transparent Layout Bg color Ends-->
        <hr>
        <!-- Sidebar BG Image Starts-->
        <h6 class=""text-center text-bold-500 mb-3 text-uppercase sb-bg-img"">Sidebar Bg Image</h6>
        <div class=""cz-bg-image row sb-bg-img"">
            <div class=""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/01.jpg"" width=""90"" class=""rounded sb-bg-01""></div>
            <div class=""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/02.jpg"" width=""90"" class=""rounded sb-bg-02""></div>
            <div class=""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/03.jpg"" width=""90"" class=""rounded sb-bg-03""></div>
            <div class=");
            WriteLiteral(@"""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/04.jpg"" width=""90"" class=""rounded sb-bg-04""></div>
            <div class=""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/05.jpg"" width=""90"" class=""rounded sb-bg-05""></div>
            <div class=""col-sm-2 mb-3""><img src=""app-assets/img/sidebar-bg/06.jpg"" width=""90"" class=""rounded sb-bg-06""></div>
        </div>
        <!-- Transparent BG Image Ends-->
        <div class=""tl-bg-img d-none"">
            <h6 class=""text-center text-bold-500 text-uppercase"">Background Images</h6>
            <div class=""cz-tl-bg-image row"">
                <div class=""col-sm-3""><img src=""app-assets/img/gallery/bg-glass-1.jpg"" width=""90"" class=""rounded bg-glass-1 selected""></div>
                <div class=""col-sm-3""><img src=""app-assets/img/gallery/bg-glass-2.jpg"" width=""90"" class=""rounded bg-glass-2""></div>
                <div class=""col-sm-3""><img src=""app-assets/img/gallery/bg-glass-3.jpg"" width=""90"" class=""rounded bg-glass-3""></div>
                <div cla");
            WriteLiteral(@"ss=""col-sm-3""><img src=""app-assets/img/gallery/bg-glass-4.jpg"" width=""90"" class=""rounded bg-glass-4""></div>
            </div>
        </div>
        <!-- Transparent BG Image Ends    -->
        <hr>
        <!-- Sidebar BG Image Toggle Starts-->
        <div class=""togglebutton toggle-sb-bg-img"">
            <div class=""switch"">
                <span>Sidebar Bg Image</span>
                <div class=""float-right"">
                    <div class=""custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0"">
                        <input id=""sidebar-bg-img"" type=""checkbox"" checked class=""custom-control-input cz-bg-image-display"">
                        <label for=""sidebar-bg-img"" class=""custom-control-label""></label>
                    </div>
                </div>
            </div>
            <hr>
        </div>
        <!-- Sidebar BG Image Toggle Ends-->
        <!-- Compact Menu Starts-->
        <div class=""togglebutton"">
            <div class=""switch"">
                <span>Compact ");
            WriteLiteral(@"Menu</span>
                <div class=""float-right"">
                    <div class=""custom-control custom-checkbox mb-2 mr-sm-2 mb-sm-0"">
                        <input id=""cz-compact-menu"" type=""checkbox"" class=""custom-control-input cz-compact-menu"">
                        <label for=""cz-compact-menu"" class=""custom-control-label""></label>
                    </div>
                </div>
            </div>
        </div>
        <!-- Compact Menu Ends-->
        <hr>
        <!-- Sidebar Width Starts-->
        <div>
            <label for=""cz-sidebar-width"">Sidebar Width</label>
            <select id=""cz-sidebar-width"" class=""custom-select cz-sidebar-width float-right"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c988ce08a7a1869846667f92b9c9772412dbac8c14296", async() => {
                WriteLiteral("Small");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c988ce08a7a1869846667f92b9c9772412dbac8c15471", async() => {
                WriteLiteral("Medium");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c988ce08a7a1869846667f92b9c9772412dbac8c16730", async() => {
                WriteLiteral("Large");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </select>\r\n        </div>\r\n        <!-- Sidebar Width Ends-->\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591