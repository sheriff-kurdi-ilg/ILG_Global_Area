#pragma checksum "D:\ILG_Projects\ILG_Global\ILG_Global.Web\Views\Home\_LeaderBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073f4abc96f63c5568d7b77d9f31faaa98704439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__LeaderBoard), @"mvc.1.0.view", @"/Views/Home/_LeaderBoard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"073f4abc96f63c5568d7b77d9f31faaa98704439", @"/Views/Home/_LeaderBoard.cshtml")]
    public class Views_Home__LeaderBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ILG_Projects\ILG_Global\ILG_Global.Web\Views\Home\_LeaderBoard.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""header-banner d-flex justify-content-center align-item-center"">
    <img src=""assets/images/Mask.png"" class=""card-img"" alt=""..."">
    <div class=""overlay""></div>
    <div class=""container mx-auto header-content d-flex flex-column justify-content-center text-white"">
        <h5 class=""card-title pb-5"">About</h5>
        <h1 class=""card-text pt-3 pb-5"">
            <div style=""color:red"">
                ");
#nullable restore
#line 12 "D:\ILG_Projects\ILG_Global\ILG_Global.Web\Views\Home\_LeaderBoard.cshtml"
           Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            Integrated
            <br>
            Legal Group
        </h1>
        <p class=""card-text"">
            We provide various legal services and consultations by a team of
        </p>
        <p class=""card-text"">
            experts in order to reach legal and friendly solutions in the simplest ways.
        </p>

        <div class=""w-100 position-absolute mx-auto d-flex justify-content-center arrow-bottom pb-4"">
            <button");
            BeginWriteAttribute("class", " class=\"", 963, "\"", 971, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-arrow-down\"></i></button>\r\n        </div>\r\n    </div>\r\n\r\n\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
