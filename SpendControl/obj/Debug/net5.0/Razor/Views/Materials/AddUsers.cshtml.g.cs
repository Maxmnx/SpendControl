#pragma checksum "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c9128daead0cb2e84ef992f94830d5af6adcc96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Materials_AddUsers), @"mvc.1.0.view", @"/Views/Materials/AddUsers.cshtml")]
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
#line 1 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\_ViewImports.cshtml"
using SpendControl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\_ViewImports.cshtml"
using SpendControl.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c9128daead0cb2e84ef992f94830d5af6adcc96", @"/Views/Materials/AddUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"848ac43039d804f24dc2a5be73381d92d65fb4be", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Materials_AddUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SpendControl.Controllers.UserViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"


<div class=""container p-3"">

	<div class=""row pt-4"">
		<div class=""col-6"">
			<h2 class=""text-primary"">Керування доступом</h2>
		</div>
		<div class=""form-group row"">
			<div class=""col-8 offset-4 row"">

				<div class=""col"">
					<input type=""submit"" class=""btn btn-info w-100"" value=""Оновити""/>
				</div>
                <div class=""col"">
					");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9c9128daead0cb2e84ef992f94830d5af6adcc964310", async() => {
                WriteLiteral("<i class=\"fas fa-sign-out-alt\"></i>Назад");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\t\t\t</div>\r\n         </div>\r\n\t</div>\r\n\r\n\t<br />\r\n\r\n\t\r\n");
#nullable restore
#line 27 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
     if(Model.Count() > 0){


#line default
#line hidden
#nullable disable
            WriteLiteral(@"		<table class=""table table-bordered table-striped"">
			<thead>
				<tr>
					<th>
						Ім'я користувача
					</th>
					<th>
						Може редагувати дані про склад
					</th>
					<th>
						Може видаляти склад
					</th>
					<th>
						Може додавати матеріали
					</th>
					<th>
						Може використовувати матеріали
					</th>
					<th>
						Може видаляти матеріали
					</th>
				</tr>
				
			</thead>
			<tbody>
");
#nullable restore
#line 54 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                 foreach(var user in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t<tr>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 56 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(user.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 57 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(Html.CheckBoxFor(m => user.canEdit, user.canEdit));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 58 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(Html.CheckBoxFor(m => user.canDelete, user.canDelete));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 59 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(Html.CheckBoxFor(m => user.canAddMaterials, user.canAddMaterials));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 60 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(Html.CheckBoxFor(m => user.canUseMaterials, user.canUseMaterials));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t<td>");
#nullable restore
#line 61 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
                   Write(Html.CheckBoxFor(m => user.canDeleteMaterials, user.canDeleteMaterials));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t</tr>\r\n");
#nullable restore
#line 63 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
				}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t</tbody>\r\n\t\t</table>\r\n");
#nullable restore
#line 66 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
	}
	else
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<p>Немає користувачів</p>\r\n");
#nullable restore
#line 70 "C:\Users\Максим\MyFiles\Politeh\Web\Курсова робота\SpendControl\SpendControl\Views\Materials\AddUsers.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SpendControl.Controllers.UserViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591