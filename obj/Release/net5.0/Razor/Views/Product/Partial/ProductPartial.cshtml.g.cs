#pragma checksum "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcc4519bd90399cffbab300fbb345c8a96e0cc43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Partial_ProductPartial), @"mvc.1.0.view", @"/Views/Product/Partial/ProductPartial.cshtml")]
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
#line 1 "C:\Users\user\source\repos\ollok\Ollok\Views\_ViewImports.cshtml"
using Ollok.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\ollok\Ollok\Views\_ViewImports.cshtml"
using Ollok.Models.ViewsModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcc4519bd90399cffbab300fbb345c8a96e0cc43", @"/Views/Product/Partial/ProductPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9ef5fea05026372bffc29321a6b8ed10f827ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Partial_ProductPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductsInfo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"product-selecters content__product-selecter\">\r\n    ");
#nullable restore
#line 3 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
Write(await Html.PartialAsync("SizePartial.cshtml", Model.FiltrInfo.Sizes));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""product-selecters__item product-selecter"" id=""price-selecter"">
        <div class=""product-selecter__button"">
            <div class=""product-selecter__title"">Цена</div>
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" class=""product-selecter__icon"" viewBox=""0 0 284.929 284.929"" style=""enable-background:new 0 0 284.929 284.929;"" xml:space=""preserve"">
            <path d="" M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z"" />
            </svg>
        </div>
        <div class=""product-selecter__choice selecter-choice"">
            <input ty");
            WriteLiteral("pe=\"text\" class=\"js-range-slider\" />\r\n            <div class=\"selecter-choice__inputs\">\r\n                <input class=\"selecter-choice__input\" id=\"from\" value=\"0\" data-min=\"");
#nullable restore
#line 14 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                               Write(Model?.FiltrInfo?.MinPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <input class=\"selecter-choice__input\" id=\"to\" value=\"0\" data-max=\"");
#nullable restore
#line 15 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                             Write(Model?.FiltrInfo?.MaxPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            </div>\r\n            <div class=\"selecter-choice__button\" id=\"price-selecter-button\">Выбрать</div>\r\n        </div>\r\n    </div>\r\n    ");
#nullable restore
#line 20 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
Write(await Html.PartialAsync("ColorPartial.cshtml", Model.FiltrInfo.Colors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 22 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
 if (Model.Products.Count() != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"product-list\">\r\n");
#nullable restore
#line 25 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
         foreach (var p in Model.Products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"product-item\">\r\n");
#nullable restore
#line 28 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
             if (Model.WishlistProductsId == null || !Model.WishlistProductsId.Any(t => t == p.Id))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"product-item__heart\">\r\n                    <div class=\"product-item__heart-quantity\">");
#nullable restore
#line 31 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                         Write(p.Like);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <svg xmlns=\"http://www.w3.org/2000/svg\" data-id=\"");
#nullable restore
#line 32 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""heart-notfull heart"" viewBox=""0 0 16 16"">
                        <path d=""m8 2.748-.717-.737C5.6.281 2.514.878 1.4 3.053c-.523 1.023-.641 2.5.314 4.385.92 1.815 2.834 3.989 6.286 6.357 3.452-2.368 5.365-4.542 6.286-6.357.955-1.886.838-3.362.314-4.385C13.486.878 10.4.28 8.717 2.01L8 2.748zM8 15C-7.333 4.868 3.279-3.04 7.824 1.143c.06.055.119.112.176.171a3.12 3.12 0 0 1 .176-.17C12.72-3.042 23.333 4.867 8 15z"" />
                    </svg>
                </div>
");
#nullable restore
#line 36 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"product-item__heart\">\r\n                    <div class=\"product-item__heart-quantity\">");
#nullable restore
#line 40 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                         Write(p.Like);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <svg xmlns=\"http://www.w3.org/2000/svg\" data-id=\"");
#nullable restore
#line 41 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                Write(p.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"heart-full heart\" viewBox=\"0 0 16 16\">\r\n                        <path d=\"M8 1.314C12.438-3.248 23.534 4.735 8 15-7.534 4.736 3.562-3.248 8 1.314z\" />\r\n                    </svg>\r\n                </div>\r\n");
#nullable restore
#line 45 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc4519bd90399cffbab300fbb345c8a96e0cc4310835", async() => {
                WriteLiteral("\r\n                <div class=\"product-item__img-block\">\r\n                    <div class=\"product-item__price\">");
#nullable restore
#line 48 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                Write(p.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" UAH</div>\r\n                    <div class=\"product-item__img\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dcc4519bd90399cffbab300fbb345c8a96e0cc4311536", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3488, "~/img/products-photo/medium/", 3488, 28, true);
#nullable restore
#line 49 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
AddHtmlAttributeValue("", 3516, p?.Photos?.First()?.PhotoWay, 3516, 29, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\r\n\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-category", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                            WriteLiteral(p.Category.LatinName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-category", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["category"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                                          WriteLiteral(p.LatinName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                                                                             WriteLiteral(p.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <div class=\"product-item__name\">");
#nullable restore
#line 53 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                       Write(p.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        </div>\r\n");
#nullable restore
#line 55 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    <div class=\"product-item\">\r\n    </div>\r\n    <div class=\"product-pages\">\r\n");
#nullable restore
#line 60 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
         for (int i = 1; i <= Model.PagingInfo.TotalPages; i++)
        {
            if (i == Model.PagingInfo.CurrentPage)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc4519bd90399cffbab300fbb345c8a96e0cc4317769", async() => {
                WriteLiteral("<div class=\"product-pages__item product-pages__item_active\">");
#nullable restore
#line 64 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                                                                                                Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                         WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productPage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productPage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productPage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 65 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc4519bd90399cffbab300fbb345c8a96e0cc4320867", async() => {
                WriteLiteral("<div class=\"product-pages__item\">");
#nullable restore
#line 68 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                                                                     Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productPage", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
                                                                         WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productPage"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productPage", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productPage"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 69 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 73 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"product-none-alert\">\r\n        <h1>Товары не найдены</h1>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc4519bd90399cffbab300fbb345c8a96e0cc4324184", async() => {
                WriteLiteral("Вернуться на главную");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 80 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 82 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\ProductPartial.cshtml"
Write(await Html.PartialAsync("MobileFilterPartial.cshtml", Model.FiltrInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductsInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591