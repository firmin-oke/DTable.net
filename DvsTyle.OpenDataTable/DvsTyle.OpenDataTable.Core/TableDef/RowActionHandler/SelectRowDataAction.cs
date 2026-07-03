using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.RowActionHandler
{
   
    [HtmlTargetElement("datatable-action-selectrowdata", ParentTag = "datatable-actions", TagStructure = TagStructure.WithoutEndTag)]
    public class SelectRowDataAction : TagHelper
    {
        [HtmlAttributeName("Disabled")]
        public bool Disabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.SelfClosing;
            output.Attributes.Add("disabled", Disabled.ToString().ToLower());
            output.Attributes.Add("visible", true.ToString().ToLowerInvariant());
            base.Process(context, output);
        }
    }
}
