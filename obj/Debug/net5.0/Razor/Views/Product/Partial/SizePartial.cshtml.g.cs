#pragma checksum "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\SizePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c0000bd66b8334b556d8b6ed538883b3bf0ca10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Partial_SizePartial), @"mvc.1.0.view", @"/Views/Product/Partial/SizePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c0000bd66b8334b556d8b6ed538883b3bf0ca10", @"/Views/Product/Partial/SizePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd9ef5fea05026372bffc29321a6b8ed10f827ae", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Partial_SizePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<int>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""product-selecters__item product-selecter"" id=""size-selecter"">
    <div class=""product-selecter__button"">
        <div class=""product-selecter__title"">Размер</div>
        <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" class=""product-selecter__icon"" viewBox=""0 0 284.929 284.929"" style=""enable-background:new 0 0 284.929 284.929;"" xml:space=""preserve"">
            <path d="" M282.082,76.511l-14.274-14.273c-1.902-1.906-4.093-2.856-6.57-2.856c-2.471,0-4.661,0.95-6.563,2.856L142.466,174.441   L30.262,62.241c-1.903-1.906-4.093-2.856-6.567-2.856c-2.475,0-4.665,0.95-6.567,2.856L2.856,76.515C0.95,78.417,0,80.607,0,83.082   c0,2.473,0.953,4.663,2.856,6.565l133.043,133.046c1.902,1.903,4.093,2.854,6.567,2.854s4.661-0.951,6.562-2.854L282.082,89.647   c1.902-1.903,2.847-4.093,2.847-6.565C284.929,80.607,283.984,78.417,282.082,76.511z"" />
        </svg>
    </div>
    <div class=""product-selecter__choice selecter-choice"" id=""size"">
");
#nullable restore
#line 11 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\SizePartial.cshtml"
         foreach (var p in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"selecter-choice__item selecter-choice__item_check-box\">");
#nullable restore
#line 12 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\SizePartial.cshtml"
                                                                          Write(p);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 13 "C:\Users\user\source\repos\ollok\Ollok\Views\Product\Partial\SizePartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"selecter-choice__button\" id=\"size-selecter-button\">Выбрать</div>\r\n    </div>\r\n</div> \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<int>> Html { get; private set; }
    }
}
#pragma warning restore 1591
