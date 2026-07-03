using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.RowActionHandler
{

    [HtmlTargetElement("datatable-action-delete", ParentTag = "datatable-actions", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class JQueryDataTableActionDelete : TagHelper
    {
        [HtmlAttributeName("Disabled")]
        public bool Disabled { get; set; }

        [HtmlAttributeName("url")]
        public string Url { get; set; }

        [HtmlAttributeName("displayconfirm")]
        public bool DisplayConfirm { get; set; }

        [HtmlAttributeName("confirmmessage")]
        public string ConfirmMessage { get; set; }

        [HtmlAttributeName("iconclass")]
        public string IconClass { get; set; }

        [HtmlAttributeName("buttonclass")]
        public string ButtonClass { get; set; }

        protected readonly IHttpContextAccessor _contextAccessor;

        public bool HasPermission { get; set; } = true;
        public JQueryDataTableActionDelete(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (HasPermission)
            {
                output.Attributes.Add("visible", true.ToString().ToLowerInvariant());
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Attributes.Add("displayconfirm", DisplayConfirm.ToString().ToLowerInvariant());
                output.Attributes.Add("confirmmessage", ConfirmMessage);
                output.Attributes.Add("disabled", Disabled.ToString().ToLower());
                output.Attributes.Add("url", Url);
                if (context.AllAttributes["iconclass"] != null && !string.IsNullOrEmpty(IconClass))
                {
                    output.Attributes.Add("iconclass", IconClass);
                }
                if (context.AllAttributes["buttonclass"] != null && !string.IsNullOrEmpty(ButtonClass))
                {
                    output.Attributes.Add("buttonclass", ButtonClass);
                }
            }
            else
            {
                output.Attributes.Add("visible", false.ToString().ToLowerInvariant());
            }
        }
    }
}
