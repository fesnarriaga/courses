#pragma checksum "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5383efaf6c117f1f202d71a272d2d0226597cc5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\_ViewImports.cshtml"
using NerdStore.WebApp.Mvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\_ViewImports.cshtml"
using NerdStore.WebApp.Mvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\_ViewImports.cshtml"
using NerdStore.Catalog.Application.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\_ViewImports.cshtml"
using NerdStore.Sales.Application.Queries.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5383efaf6c117f1f202d71a272d2d0226597cc5b", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cb4d89bae4a28a7bfaf4e65607a7480e40d75ce", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartViewModel>
    {
        private global::AspNetCore.Views_Cart_Index.__Generated__SummaryViewComponentTagHelper __SummaryViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Store", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ApplyVoucher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReviewCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Cart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 col-md-10 offset-md-1\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:summary", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5383efaf6c117f1f202d71a272d2d0226597cc5b7932", async() => {
            }
            );
            __SummaryViewComponentTagHelper = CreateTagHelper<global::AspNetCore.Views_Cart_Index.__Generated__SummaryViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__SummaryViewComponentTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 12 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
              
                if (Model.Items != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Quantity</th>
                                <th class=""text-center"">Price</th>
                                <th class=""text-center"">Total</th>
                                <th> </th>
                            </tr>
                        </thead>

                        <tbody>
");
#nullable restore
#line 27 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                              
                                foreach (var item in Model.Items)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <tr>
                                        <td class=""col-sm-5"">
                                            <div class=""media"">
                                                <div class=""media-body"">
                                                    <h4>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b10298", async() => {
#nullable restore
#line 34 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                                                                                                       Write(item.ProductName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                                                                               WriteLiteral(item.ProductId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</h4>
                                                </div>
                                            </div>
                                        </td>

                                        <td class=""col-sm-2 text-center"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b13364", async() => {
                WriteLiteral("\r\n                                                <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 1743, "\"", 1766, 1);
#nullable restore
#line 41 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1751, item.ProductId, 1751, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                <div class=\"row\" style=\"float: left\">\r\n                                                    <input type=\"text\" class=\"form-control\" name=\"quantity\"");
                BeginWriteAttribute("value", " value=\"", 1966, "\"", 1988, 1);
#nullable restore
#line 43 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1974, item.Quantity, 1974, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""width: 70px;"" />
                                                </div>
                                                <div class=""row"" style=""float: right"">
                                                    <button type=""submit"" class=""btn btn-success"">
                                                        <span class=""fas fa-sync""></span>
                                                    </button>
                                                </div>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td class=\"col-sm-1 text-center\"><strong>");
#nullable restore
#line 53 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                                            Write(item.Price.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                                        <td class=\"col-sm-1 text-center\"><strong>");
#nullable restore
#line 54 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                                            Write(item.Total.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n\r\n                                        <td class=\"col-sm-1\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b17908", async() => {
                WriteLiteral("\r\n                                                <input type=\"hidden\" name=\"productId\"");
                BeginWriteAttribute("value", " value=\"", 3077, "\"", 3100, 1);
#nullable restore
#line 58 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
WriteAttributeValue("", 3085, item.ProductId, 3085, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                                <button type=""submit"" class=""btn btn-danger"">
                                                    <span class=""fas fa-trash-alt""></span>
                                                </button>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 65 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <tr>
                                <td> </td>
                                <td> </td>
                                <td> </td>
                                <td><h5>Subtotal</h5></td>
                                <td class=""text-right""><h5><strong>");
#nullable restore
#line 73 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                              Write(Model.SubTotal.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h5></td>\r\n                            </tr>\r\n\r\n                            <tr>\r\n                                <td> </td>\r\n                                <td colspan=\"2\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b21794", async() => {
                WriteLiteral("\r\n                                        <div class=\"row\" style=\"float: left;\">\r\n                                            <input type=\"text\" class=\"form-control\" name=\"code\"");
                BeginWriteAttribute("value", " value=\"", 4352, "\"", 4378, 1);
#nullable restore
#line 81 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
WriteAttributeValue("", 4360, Model.VoucherCode, 4360, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Voucher"" style=""width: 150px;"" />
                                        </div>
                                        <div class=""row"" style=""float: right"">
                                            <button type=""submit"" class=""btn btn-success"">
                                                <span class=""fas fa-sync""></span>
                                            </button>
                                        </div>
                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td><h5>Discount</h5></td>\r\n                                <td class=\"text-right\"><h5><strong>");
#nullable restore
#line 91 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                              Write(Model.Discount.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h5></td>
                            </tr>

                            <tr>
                                <td> </td>
                                <td> </td>
                                <td> </td>
                                <td><h3>Total</h3></td>
                                <td class=""text-right""><h3><strong>");
#nullable restore
#line 99 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                                                              Write(Model.Total.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></h3></td>
                            </tr>

                            <tr>
                                <td> </td>
                                <td> </td>
                                <td> </td>
                                <td>
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b26211", async() => {
                WriteLiteral("\r\n                                        <span class=\"fa fa-shopping-cart\"></span> Back to store\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5383efaf6c117f1f202d71a272d2d0226597cc5b27908", async() => {
                WriteLiteral("\r\n                                        <span class=\"fas fa-play\"></span> Place order\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 119 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div>\r\n                        <p>Empty Cart</p>\r\n                    </div>\r\n");
#nullable restore
#line 125 "C:\Projects\courses\desenvolvedor-io\06_dominios-ricos\NerdStore\src\NerdStore.WebApp.Mvc\Views\Cart\Index.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartViewModel> Html { get; private set; }
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:summary")]
        public class __Generated__SummaryViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__SummaryViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("Summary", new {  });
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
        }
    }
}
#pragma warning restore 1591
