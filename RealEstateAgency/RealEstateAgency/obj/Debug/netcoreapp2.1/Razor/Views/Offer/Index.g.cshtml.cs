#pragma checksum "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cf1d17968303d017da32f11ee502d48d2ffb376"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Offer_Index), @"mvc.1.0.view", @"/Views/Offer/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Offer/Index.cshtml", typeof(AspNetCore.Views_Offer_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cf1d17968303d017da32f11ee502d48d2ffb376", @"/Views/Offer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcb364b64bc82f8b7b744aeeba18df22c0a97d2c", @"/Views/_ViewImports.cshtml")]
    public class Views_Offer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RealEstateAgency.Models.OfferRealEstate>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
  
    ViewData["Title"] = "Offer";

#line default
#line hidden
            BeginContext(89, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(96, 17, false);
#line 6 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(113, 129, true);
            WriteLiteral("</h2>\r\n\r\n<div class=\"card\">\r\n    <h5 class=\"card-header\">Offer</h5>\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">");
            EndContext();
            BeginContext(243, 17, false);
#line 11 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
                          Write(Model.Advert.Name);

#line default
#line hidden
            EndContext();
            BeginContext(260, 36, true);
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">");
            EndContext();
            BeginContext(297, 24, false);
#line 12 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
                        Write(Model.Advert.Description);

#line default
#line hidden
            EndContext();
            BeginContext(321, 112, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <ul class=\"list-group list-group-flush\">\r\n        <li class=\"list-group-item\">Total area: ");
            EndContext();
            BeginContext(434, 22, false);
#line 15 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
                                           Write(Model.Advert.TotalArea);

#line default
#line hidden
            EndContext();
            BeginContext(456, 50, true);
            WriteLiteral("</li>\r\n        <li class=\"list-group-item\">Price: ");
            EndContext();
            BeginContext(507, 18, false);
#line 16 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
                                      Write(Model.Advert.Price);

#line default
#line hidden
            EndContext();
            BeginContext(525, 95, true);
            WriteLiteral("</li>\r\n    </ul><div style=\"justify-content: space-around; display: flex;\" class=\"card-body\">\r\n");
            EndContext();
#line 18 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
     if (Model.TypeStatusOffer == TypeStatusOffer.waiting)
    {
        

#line default
#line hidden
            BeginContext(696, 111, false);
#line 20 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
   Write(Html.ActionLink("Resolve", "Resolve", new { id = Model.OfferRealEstateId }, new { @class = "btn btn-success" }));

#line default
#line hidden
            EndContext();
            BeginContext(818, 109, false);
#line 21 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
   Write(Html.ActionLink("Reject", "Reject", new { id = Model.OfferRealEstateId }, new { @class = "btn btn-warning" }));

#line default
#line hidden
            EndContext();
#line 21 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
                                                                                                                      
    }
    else if(Model.TypeStatusOffer == TypeStatusOffer.resolved)
    {

#line default
#line hidden
            BeginContext(1007, 46, true);
            WriteLiteral("        <p class=\"text-success\">Resolved</p>\r\n");
            EndContext();
#line 26 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
    }
    else if(Model.TypeStatusOffer == TypeStatusOffer.rejected)
    {

#line default
#line hidden
            BeginContext(1131, 46, true);
            WriteLiteral("        <p class=\"text-warning\">Rejected</p>\r\n");
            EndContext();
#line 30 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1201, 38, true);
            WriteLiteral("        <p class=\"text-info\">Off</p>\r\n");
            EndContext();
#line 34 "D:\MyProject\Project_BaseCamp\RealEstateAgency\RealEstateAgency\Views\Offer\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1246, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RealEstateAgency.Models.OfferRealEstate> Html { get; private set; }
    }
}
#pragma warning restore 1591
