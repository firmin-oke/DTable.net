using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.ToolTip
{

    [HtmlTargetElement("datatable-tooltip-inline", ParentTag = "datatable-container", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class DataTableToolTipInline : TagHelper
    {
        protected TagBuilder AddRowButton { get; set; }
        protected TagBuilder DeleteRowButton { get; set; }

        public DataTableToolTipInline(TagBuilder deleteRowButton, TagBuilder addRowButton)
        {
            AddRowButton = addRowButton;
            DeleteRowButton = deleteRowButton;
        }

        public DataTableToolTipInline()
        {
            AddRowButton = new TagBuilder("button");
            DeleteRowButton = new TagBuilder("button");
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("style", "display:inline;");
            AddRowButton = new TagBuilder("button");
            AddRowButton.AddCssClass("inlineaddrowbtn btn btn-icon btn-primary");

            DeleteRowButton = new TagBuilder("button");
            DeleteRowButton.AddCssClass("inlinedeleterowbtn btn btn-icon btn-danger");

            AddRowButton.AddCssClass("ml-1");
            var spanadd = new TagBuilder("i");
            spanadd.AddCssClass("ti-plus");

            var spanremove = new TagBuilder("i");
            spanremove.AddCssClass("ti-trash");

            AddRowButton.InnerHtml.AppendHtml(spanadd);
            DeleteRowButton.InnerHtml.AppendHtml(spanremove);

            output.Content.AppendHtml(AddRowButton);
            output.Content.AppendHtml(DeleteRowButton);

            base.Process(context, output);
        }
    }


}
