#pragma checksum "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "089d2c3dacf8a5ddc1fbf86528b0087b26a5a64a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gallery_Index), @"mvc.1.0.view", @"/Views/Gallery/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Gallery/Index.cshtml", typeof(AspNetCore.Views_Gallery_Index))]
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
#line 1 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\_ViewImports.cshtml"
using RealEstateAgency;

#line default
#line hidden
#line 2 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\_ViewImports.cshtml"
using RealEstateAgency.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"089d2c3dacf8a5ddc1fbf86528b0087b26a5a64a", @"/Views/Gallery/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcb364b64bc82f8b7b744aeeba18df22c0a97d2c", @"/Views/_ViewImports.cshtml")]
    public class Views_Gallery_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RealEstateAgency.ViewModels.AdvertViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_StatusMessage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateApplicationForRealEstate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
  
    ViewData["Title"] = "Adverts";

#line default
#line hidden
            BeginContext(97, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(104, 17, false);
#line 7 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(121, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
            BeginContext(128, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d9a25ab54840475491f6ffe8321414c5", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 8 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ViewData["MessageState"];

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(195, 7, true);
            WriteLiteral("\r\n<p>\r\n");
            EndContext();
#line 10 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
     if (User.IsInRole("Agent"))
    {

#line default
#line hidden
            BeginContext(243, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(247, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e32f98de47ff4d8f8d478a6442555627", async() => {
                BeginContext(270, 10, true);
                WriteLiteral("Create new");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(284, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(287, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
#line 13 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(297, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(301, 85, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63f945f3f5174fb484b06b60080ccb50", async() => {
                BeginContext(348, 34, true);
                WriteLiteral("Create application for real estate");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(386, 311, true);
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Desctiprion</th>
            <th>Images</th>
            <th>Type</th>
            <th>Rent</th>
            <th>Price</th>
            <th>Date publication</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 29 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
 foreach (Advert advert in Model.Adverts) {

#line default
#line hidden
            BeginContext(742, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(791, 36, false);
#line 32 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.Name));

#line default
#line hidden
            EndContext();
            BeginContext(827, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(883, 43, false);
#line 35 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.Description));

#line default
#line hidden
            EndContext();
            BeginContext(926, 39, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 38 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
                 foreach(var img in advert.CollectionImgs)
                {

#line default
#line hidden
            BeginContext(1044, 24, true);
            WriteLiteral("                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1068, "\"", 1088, 2);
            WriteAttributeValue("", 1074, "imgs/", 1074, 5, true);
#line 40 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
WriteAttributeValue("", 1079, img.Name, 1079, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1089, 17, true);
            WriteLiteral(" width=\"100\" />\r\n");
            EndContext();
#line 41 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1125, 53, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1179, 51, false);
#line 44 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.TypeRealEstate.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1230, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1286, 36, false);
#line 47 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.Rent));

#line default
#line hidden
            EndContext();
            BeginContext(1322, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1378, 37, false);
#line 50 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1415, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1471, 47, false);
#line 53 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
           Write(Html.DisplayFor(item => advert.DatePublication));

#line default
#line hidden
            EndContext();
            BeginContext(1518, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 56 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Gallery\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1557, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RealEstateAgency.ViewModels.AdvertViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
