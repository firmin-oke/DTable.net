using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.RowActionHandler
{
    
    [HtmlTargetElement("datatable-actions", ParentTag = "datatable-settings", TagStructure = TagStructure.NormalOrSelfClosing)]
    [RestrictChildren("datatable-action-updaterow", "datatable-action-addto", "datatable-action-edit", "datatable-action-delete",
       "datatable-action-newmodalfromrow", "datatable-action-selectrowdata", "datatable-action-downloadfile")]
    public class RowAction : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            await output.GetChildContentAsync();
        }
    }
}
