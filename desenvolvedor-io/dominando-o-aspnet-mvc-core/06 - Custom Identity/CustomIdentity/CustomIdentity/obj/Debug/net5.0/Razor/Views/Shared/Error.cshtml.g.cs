#pragma checksum "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70338c8e429af705e3de1b867e0a9c6ff0ee681d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\_ViewImports.cshtml"
using CustomIdentity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\_ViewImports.cshtml"
using CustomIdentity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70338c8e429af705e3de1b867e0a9c6ff0ee681d", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"982b5ea8f0e3abe8d36d312de6db8cf37f7b71e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = Model != null ? Model.Title : "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
  
    if (Model == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            <h2>Ooops! Something went wrong. We are already working on it...</h2>\r\n        </div>\r\n");
#nullable restore
#line 12 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>");
#nullable restore
#line 15 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
       Write(Html.Raw(Model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <h2 class=\"text-danger\">");
#nullable restore
#line 16 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
                           Write(Html.Raw(Model.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 17 "C:\Projects\courses\desenvolvedor-io\dominando-o-aspnet-mvc-core\06 - Custom Identity\CustomIdentity\CustomIdentity\Views\Shared\Error.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
