#pragma checksum "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_FlashPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b01cf7f11a1d27db4db9262a5c7ae06cb59f345f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FlashPartial), @"mvc.1.0.view", @"/Views/Shared/_FlashPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_FlashPartial.cshtml", typeof(AspNetCore.Views_Shared__FlashPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b01cf7f11a1d27db4db9262a5c7ae06cb59f345f", @"/Views/Shared/_FlashPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92dd7acc71680614a25ea1911fe6f35a41d0d535", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__FlashPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_FlashPartial.cshtml"
 foreach (var key in TempData.Keys)
{

#line default
#line hidden
            BeginContext(40, 61, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n        $(function() {\r\n");
            EndContext();
            BeginContext(154, 47, true);
            WriteLiteral("            swal({\r\n                    type: \'");
            EndContext();
            BeginContext(203, 3, false);
#line 7 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_FlashPartial.cshtml"
                       Write(key);

#line default
#line hidden
            EndContext();
            BeginContext(207, 36, true);
            WriteLiteral("\',\r\n                        title: \'");
            EndContext();
            BeginContext(244, 13, false);
#line 8 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_FlashPartial.cshtml"
                           Write(TempData[key]);

#line default
#line hidden
            EndContext();
            BeginContext(257, 143, true);
            WriteLiteral("\',\r\n                        showConfirmButton: true,\r\n                        width: \"60%\"\r\n                });\r\n        });\r\n\r\n    </script>\r\n");
            EndContext();
#line 15 "C:\Users\ABSA391\Documents\AGL Repository\Skylark\Skylark\Views\Shared\_FlashPartial.cshtml"
}

#line default
#line hidden
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