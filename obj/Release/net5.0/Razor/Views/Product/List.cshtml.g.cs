#pragma checksum "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea2586516eb7f0c72fbef165a22e664975e2cbed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea2586516eb7f0c72fbef165a22e664975e2cbed", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9ef5fea05026372bffc29321a6b8ed10f827ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml"
   ViewBag.Title = "Ollok";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml"
Write(await Component.InvokeAsync("CategoryList"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"products-name content__products-name\">\r\n    <div class=\"products-name__name\">");
#nullable restore
#line 7 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml"
                                Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"products-name__line\"></div>\r\n</div>\r\n<div class=\"filter-button\">Фильтры</div>\r\n<div class=\"ajax-product\">\r\n    ");
#nullable restore
#line 12 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml"
Write(await Html.PartialAsync("Partial/ProductPartial.cshtml", Model.ProductsInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div class=\"category\" style=\"display: none;\" data-category-select=\"");
#nullable restore
#line 14 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\List.cshtml"
                                                              Write(ViewBag.selecteCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591