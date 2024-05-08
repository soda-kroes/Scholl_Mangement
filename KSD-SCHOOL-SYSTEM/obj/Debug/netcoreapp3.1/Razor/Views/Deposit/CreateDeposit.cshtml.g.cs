#pragma checksum "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\Deposit\CreateDeposit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17e9ebc920db546e6c4f11c3c0fe0e89c56cbe66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Deposit_CreateDeposit), @"mvc.1.0.view", @"/Views/Deposit/CreateDeposit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17e9ebc920db546e6c4f11c3c0fe0e89c56cbe66", @"/Views/Deposit/CreateDeposit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32f79689ee582436c9ac7483db55e1047df40b94", @"/Views/_ViewImports.cshtml")]
    public class Views_Deposit_CreateDeposit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\Deposit\CreateDeposit.cshtml"
  
    ViewData["Title"] = "Create Deposit";


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

    .bgcolor.active {
        background - color: #007bff;
        color: #fff;
    }
</style>

<div class=""row"">
    <div class=""col-sm-12"">
        <ul class=""nav nav-tabs"">
            <li class=""nav-tabs nav-item active"">
                <a class=""nav-link bgcolor active"" data-toggle=""tab"" href=""#student"">Student Information</a>
            </li>
            <li class=""nav-tabs nav-item"">
                <a class=""nav-link bgcolor"" data-toggle=""tab"" href=""#level"">Level Infomation</a>
            </li>
        </ul>
        <hr />
        <br />

        <d");
            WriteLiteral(@"iv class=""tab-content"">
            <div id=""student"" class=""tab-pane fade in active show"">

                <div class=""row"">
                    <div class=""col-sm-6"">
                        <b>Student Name: </b>
                        <input type=""text"" class=""form-control"" id=""txtStuName"" />
                        <br />
                        <b>Tell: </b>
                        <input type=""text"" class=""form-control"" id=""txtTell"" />
                        <br />
                        
                    </div>

                    <div class=""col-sm-6"">
                        <b>Invoice No. : </b>
                        <input type=""text"" class=""form-control"" id=""txtInvoiceNo"" readonly />
                        <br />

                        <b>Posting Date: </b>
                        <input type=""date"" class=""form-control"" id=""dtPosting"" />
                    </div>

                </div>
                <div class=""row"">
                    <div class=""col-sm-");
            WriteLiteral(@"12"">
                        <b>Remarks: </b>
                        <textarea class=""form-control"" id=""txtRemarks "" rows=""3""></textarea>

                    </div>

                </div>
                <hr />

            </div>

            <div id=""level"" class=""tab-pane fade"">
                <div class=""row"">
                    <div class=""col-sm-6"">
                        <b>Level Name : </b>
                        <select class=""form-control"" id=""ddlLevel""></select>
                        <br />

                        <b>Unit Price : </b>
                        <input type=""number"" class=""form-control"" id=""txtUnitPrice"" readonly/>
                        <br />

                        <b>Discount(%) : </b>
                        <input type=""number"" class=""form-control"" id=""txtDisPer"" />
                        <br />

                        <b>Discount Amount : </b>
                        <input type=""number"" class=""form-control"" id=""txtDisAmount"" />


    ");
            WriteLiteral(@"                </div>
                    <div class=""col-sm-6"">
                        <b>Start Date : </b>
                        <input type=""date"" class=""form-control"" id=""txtStartDate"" />
                        <br />

                        <b>Time : </b>
                        <input type=""text"" class=""form-control"" id=""txtTime"" />
                        <br />

                        <b>Schedule : </b>
                        <input type=""text"" class=""form-control"" id=""txtSchedule"" />

                    </div>
                </div>
                <hr />

                <div class=""row"">
                    <div class=""col-sm-12"">
                        <button class=""btn btn-outline-info"" id=""btnAddLevel"">Add Level</button>

                    </div>
                    <br />

                </div>
                <div class=""table-responsive"" style=""margin-top:20px; "">
                    <div class=""row"">
                        <div class=""col-sm-12"">
  ");
            WriteLiteral(@"                          <table id=""idTableLevelInfo"" class=""table  table-bordered table-hover"" style=""width:100%;"">
                                <thead style="" background-color:#FBC576"">
                                    <tr>
                                        <th>Level Code</th>
                                        <th>Level Name</th>
                                        <th>Unit Price</th>
                                        <th>Deposit</th>
                                        <th>Balance</th>
                                        <th>Discount(%)</th>
                                        <th>Discount Amount</th>
                                        <th>StartDate</th>
                                        <th>Time</th>
                                        <th>Schedule</th>
                                        <th>Command</th>
                                    </tr>
                                </thead>
                               
           ");
            WriteLiteral(@"                 </table>
                        </div>
                    </div>
                </div>
                <hr />

                <div class=""row"">
                    <div class=""col-sm-8"">

                    </div>
                    <div class=""col-sm-4"">
                        <b>Total : </b>
                        <input type=""number"" class=""form-control"" id=""txtTotal"" readonly />
                        <br />
                        <b>Deposit : </b>
                        <input type=""number"" class=""form-control"" id=""txtDeposit"" readonly />
                        <br />

                        <b>Balance : </b>
                        <input type=""number"" id=""txtBalance"" class=""form-control"" />
                    </div>

                </div>
                <br />



            </div>
            <div class=""row"" style=""margin-left:4px;"">
                <button class=""btn btn-outline-info"" id=""btn tbnAdd"">Add New</button>

            </div>");
            WriteLiteral(@"


        </div>

</div>


    </div>

<script type=""text/javascript"">
    //for custom datatable
    $('#idTableLevelInfo').DataTable({
       
        searching: false,
        paging: false,
        info: false
    });


   

    function GetAllLevel() {
        $.ajax({
            url: '");
#nullable restore
#line 193 "D:\KSD-LEARNING\C#\DOTNET_CORE\KSD-SCHOOL-SYSTEM\KSD-SCHOOL-SYSTEM\Views\Deposit\CreateDeposit.cshtml"
             Write(Url.Action("getLevel", "MasterData"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: ""GET"",
            dataType: ""JSON"",
            success: function (data) {
                $('#ddlLevel').empty();
                $('#ddlLevel').append(new Option(""-----Select------"", 0));

                for (var i = 0; i < data.level.length; i++) {
                    $('#ddlLevel').append(new Option(data.level[i].levelCode +'-'+ data.level[i].levelName,data.level[i].unitPrice));

                }
            }
        });
    }
    //call
    GetAllLevel();

  
    //for select level 
    $('#ddlLevel').change(function () {
        var unitPrice = $('#ddlLevel').val();
        $('#txtUnitPrice').val(unitPrice);
    })

    //fro caculate discount percentage 
    $('#txtDisPer').change(function () {
        if (Number($('#txtDisPer').val() > 100)) {
            $('#txtDisPer').val(100);
            $('#txtDisAmount').val($('#txtUnitPrice').val())
        }
        else if (Number($('#txtDisPer').val()) < 0) {
            $('#txtDisPer').val(0);
      ");
            WriteLiteral(@"      $('#txtDisAmount').val(0);
        }
        else {
            var disAmount = Number($('#txtUnitPrice').val()) * (Number($('#txtDisPer').val()) / 100)
          //  $('#txtDisAmount').val(disAmount);
            $('#txtDisAmount').val(Math.round(Math.round(disAmount * 1000) / 10) / 100)//for cut digit 2
        }
    })



  
    $('#txtDisAmount').change(function () {
        if (Number($('#txtDisPer').val()) > Number($('#txtUnitPrice').val())) {
            $('#txtDisPer').val(100);
            $('#txtDisAmount').val($('#txtUnitPrice').val());
        }
        else if (Number($('#txtDisAmount').val()) < 0) {
            $('#txtDisPer').val(0);
            $('#txtDisAmount').val(0);
        }
        else {
        
            var disper = (Number($('#txtDisAmount').val()) * 100) / Number($('#txtUnitPrice').val());
            //  $('#txtDisPer').val(disper);
            $('#txtDisPer').val(Math.round(Math.round(disper*1000)/10)/100)//for cut degit 2
        }
    });

");
            WriteLiteral("\r\n</script>\r\n\r\n\r\n");
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
