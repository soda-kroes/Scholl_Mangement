#pragma checksum "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\Deposit\ViewDeposit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb8baf68eaf88088a38a9b2022a2bc376552bcd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Deposit_ViewDeposit), @"mvc.1.0.view", @"/Views/Deposit/ViewDeposit.cshtml")]
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
#line 1 "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\_ViewImports.cshtml"
using KSD_SCHOOL_SYSTEM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\_ViewImports.cshtml"
using KSD_SCHOOL_SYSTEM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb8baf68eaf88088a38a9b2022a2bc376552bcd8", @"/Views/Deposit/ViewDeposit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32f79689ee582436c9ac7483db55e1047df40b94", @"/Views/_ViewImports.cshtml")]
    public class Views_Deposit_ViewDeposit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateDeposit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Deposit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\Deposit\ViewDeposit.cshtml"
  
    ViewData["Title"] = "View Deposit";
    DateTime dt = DateTime.Now;
    ViewBag.dt = dt.ToShortDateString();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js""></script>
<script src=""https://cdn.datatables.net/1.13.6/js/dataTables.bootstrap4.min.js""></script>
<link href="" https://cdn.datatables.net/1.13.6/css/dataTables.bootstrap4.min.css"" rel=""stylesheet"">
<style>
    .select {
        background-color: #68B6DE;
    }

    .table-responsive {
        white-space: nowrap;
        overflow-x: auto;
    }
</style>
<div class=""container"">
    <div class=""row"">
        <div class=""col-sm-12"">
            <h5><i class=""fas fa-home""></i>Home <i class=""fas fa-arrow-right""></i> User <i class=""fas fa-arrow-right""></i> View Deposit</h5>
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-sm-4"">
            <b>Date From: </b>
            <input type=""date"" class=""form-control"" id=""idDateFrom"" />

        </div>

        <div class=""col-sm-4"">
            <b>Date From: </b>
            <input type=""date"" class=""form-control"" id=""idDateTo"" />
");
            WriteLiteral(@"
        </div>

    </div>
    <br />
    <div class=""table-responsive"">
        <div class=""row"">
            <div class=""col-sm-12"">
                <table id=""idTableDeposit"" class=""table  table-bordered table-hover"" style=""width:100%;"">
                    <thead style="" background-color:#FBC576"">
                        <tr>
                            <th>No</th>
                            <th>Invoice No.</th>
                            <th>Student Name</th>
                            <th>Posting Date</th>
                            <th>Total</th>
                            <th>Deposit</th>
                            <th>Balance</th>
                            <th>Command</th>
                        </tr>
                    </thead>
                    <tfoot style="" background-color:#FBC576"">
                        <tr>
                            <th>No</th>
                            <th>Invoice No.</th>
                            <th>Student Name</th>
          ");
            WriteLiteral(@"                  <th>Posting Date</th>
                            <th>Total</th>
                            <th>Deposit</th>
                            <th>Balance</th>
                            <th>Command</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </div>
    <hr />
    <div class=""row"">
        <div class=""col-sm-12"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb8baf68eaf88088a38a9b2022a2bc376552bcd87038", async() => {
                WriteLiteral("Add new");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<script type=\"text/javascript\">\r\n    $(\'#idTableDeposit\').DataTable();\r\n\r\n</script>\r\n\r\n");
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
