using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef
{
    
    [HtmlTargetElement("datatable-tooltip-external", ParentTag = "datatable-container", TagStructure = TagStructure.WithoutEndTag)]
    public class DataTableExternalToolTip : DataTableToolTip
    {
        public string PageTitle { get; set; }

        public DataTableExternalToolTip(IHttpContextAccessor contextAccessor)
            : base(contextAccessor)
        {

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (HasPermission)
            {
                TooltipButton.AddCssClass("init-tooltip-external");
                TooltipButton.Attributes.Add("data-pagetitle", PageTitle);
                foreach (var i in TagItems)
                {
                    output.PreContent.AppendHtml(i);
                }
                await output.GetChildContentAsync();
            }
        }
    }
}
