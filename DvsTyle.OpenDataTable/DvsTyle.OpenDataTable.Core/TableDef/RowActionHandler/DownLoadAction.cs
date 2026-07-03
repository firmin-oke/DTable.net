using DvStyle.OpenDataTable.TableDef;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.RowActionHandler
{
   
    [HtmlTargetElement("datatable-action-downloadfile", ParentTag = "datatable-actions", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class DownLoadAction : TagHelper
    {
        [HtmlAttributeName("url")]
        public string Url { get; set; }

        [HtmlAttributeName("iconclass")]
        public string IconClass { get; set; }

        [HtmlAttributeName("buttonclass")]
        public string ButtonClass { get; set; }

        protected readonly IHttpContextAccessor _contextAccessor;

        public DownLoadAction(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("url", Url);
            output.Attributes.Add("visible", true.ToString().ToLowerInvariant());

            if (context.AllAttributes["iconclass"] != null && !string.IsNullOrEmpty(IconClass))
            {
                output.Attributes.Add("iconclass", IconClass);
            }
            if (context.AllAttributes["buttonclass"] != null && !string.IsNullOrEmpty(ButtonClass))
            {
                output.Attributes.Add("buttonclass", ButtonClass);
            }
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}
