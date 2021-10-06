#pragma checksum "D:\Project1\MVC-Assignments\TimeEntryApp\Presentation\Views\Timesheet\ViewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "853983d27411a345dfa93ba3626e7f123fc24b28"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Timesheet_ViewDetails), @"mvc.1.0.view", @"/Views/Timesheet/ViewDetails.cshtml")]
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
#line 1 "D:\Project1\MVC-Assignments\TimeEntryApp\Presentation\Views\_ViewImports.cshtml"
using Presentation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project1\MVC-Assignments\TimeEntryApp\Presentation\Views\_ViewImports.cshtml"
using DA.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"853983d27411a345dfa93ba3626e7f123fc24b28", @"/Views/Timesheet/ViewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fb432bf6a31ef49a8fdafca5f3c5a148564ceb8", @"/Views/_ViewImports.cshtml")]
    public class Views_Timesheet_ViewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--");
            WriteLiteral(@"



<div class=""container"">
    <div class=""row justify-content-center"">
        <div class=""col-md-6"">
            <div class=""card my-3 p-2"">
                <div class=""card-header"">
                    <h3 class=""mb-0"">Details</h3>
                </div>
                <div class=""card-body"">
                    <form asp-action=""Create"" method=""post"">
                        <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
                        <div class=""form-group row"">
                            <label class=""col-lg-3 col-form-label form-control-label"" asp-for=""Date"">Date</label>
                            <div class=""col-lg-9"">
                                <input class=""form-control"" type=""date"" asp-for=""Date"" readonly>
                                <span asp-validation-for=""Date"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                         ");
            WriteLiteral(@"   <label class=""col-lg-3 col-form-label form-control-label"" asp-for=""InTime"">In-Time</label>
                            <div class=""col-lg-9"">
                                <input class=""form-control"" asp-for=""InTime"" readonly>
                                <span asp-validation-for=""InTime"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-lg-3 col-form-label form-control-label"" asp-for=""OutTime"">Out-Time</label>
                            <div class=""col-lg-9"">
                                <input class=""form-control"" asp-for=""OutTime"" readonly>
                                <span asp-validation-for=""OutTime"" class=""text-danger""></span>
                            </div>
                        </div>
                        <button class=""btn btn-sm"" type=""button"" data-toggle=""collapse"" data-target=""#collapseExample"" aria-expanded=""false"" aria");
            WriteLiteral(@"-controls=""collapseExample"">
                            Breaks Taken
                        </button>
                        <div class=""collapse"" id=""collapseExample"">
                            <div class=""card card-body"">
                                <div class=""form-group row"">
                                    <label class=""col-lg-3 col-form-label form-control-label"" asp-for=""BreakIn"">Break-In</label>
                                    <div class=""col-lg-9"">
                                        <input class=""form-control"" asp-for=""BreakIn"" readonly>
                                        <span asp-validation-for=""BreakIn"" class=""text-danger""></span>
                                    </div>
                                </div>
                                <div class=""form-group row"">
                                    <label class=""col-lg-3 col-form-label form-control-label"" asp-for=""BreakOut"">Break-Out</label>
                                    <div class=""col-lg-9"">");
            WriteLiteral(@"
                                        <input class=""form-control"" asp-for=""BreakOut"" readonly>
                                        <span asp-validation-for=""BreakOut"" class=""text-danger""></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""form-group row"">
                            <label class=""col-lg-3 col-form-label form-control-label""></label>
                            <div class=""col-lg-9"">
                                <input class=""btn btn-secondary"" type=""reset"" value=""Back"">
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>-->



");
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
