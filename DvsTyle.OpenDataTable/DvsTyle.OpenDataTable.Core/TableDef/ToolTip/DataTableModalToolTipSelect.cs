using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DvsTyle.OpenDataTable.Core.TableDef.ToolTip
{

    [HtmlTargetElement("datatable-tooltip-modal-select", ParentTag = "datatable-container", TagStructure = TagStructure.WithoutEndTag)]
    public class DataTableToolTipModalSelect : DataTableToolTipModal
    {
        [HtmlAttributeName("select-button-action")]
        public string SelectButtonAction { get; set; }

        [HtmlAttributeName("select-modalid")]
        public string SelectModalId { get; set; }

        [HtmlAttributeName("select-modaltitle")]
        public string SelectModalTitle { get; set; }

        [HtmlAttributeName("select-btn-title")]
        public string SelectBtnTitle { get; set; }

        [HtmlAttributeName("select-display-footer-closebtn")]
        public bool SelectDisplayFooterCloseBtn { get; set; }

        [HtmlAttributeName("select-display-footer-submitbtn")]
        public bool SelectDisplayFooterSubmitBtn { get; set; }

        [HtmlAttributeName("select-tooltip-disabled")]
        public bool DisabledSelect { get; set; }

        private TagBuilder SelectButton { get; set; }

        public string SelectIconClass { get; set; }
        public string SelectButtonClass { get; set; }

        public DataTableToolTipModalSelect(IHttpContextAccessor contextAccessor)
            : base(contextAccessor)
        {

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);
            if (HasPermission)
            {
                SelectButton = new TagBuilder("button");
                if (!string.IsNullOrEmpty(SelectButtonClass))
                {
                    SelectButton.AddCssClass(SelectButtonClass);
                }
                else
                {
                    SelectButton.AddCssClass("btn btn-warning btn-icon");
                }
                if (DisabledSelect)
                {
                    SelectButton.AddCssClass("disabled");
                    SelectButton.Attributes.Add("disabled", "disabled");
                }
                SelectButton.AddCssClass("init-tooltip-modal");
                //SelectButton.AddCssClass("ml-1");

                SelectButton.Attributes.Add("title", SelectBtnTitle);
                SelectButton.Attributes.Add("data-tooltipaction", SelectButtonAction);

                SelectButton.Attributes.Add("data-modaltitle", SelectModalTitle);

                SelectButton.Attributes.Add("data-footerclosebtn", SelectDisplayFooterCloseBtn.ToString().ToLower());
                SelectButton.Attributes.Add("data-footersubmitbtn", SelectDisplayFooterSubmitBtn.ToString().ToLower());

                SelectButton.Attributes.Add("data-modalsize", Modalsize);
                SelectButton.Attributes.Add("data-modalcallbackgrid", Modalcallbackgrid);

                SelectButton.Attributes.Add("data-modalid", SelectModalId);
                var span = new TagBuilder("i");
                if (!string.IsNullOrEmpty(SelectIconClass))
                {
                    span.AddCssClass(SelectIconClass);
                }
                else
                {
                    span.AddCssClass("fas fa-reply");
                }
                SelectButton.InnerHtml.AppendHtml(span);
                TagItems.Add(SelectButton);
                output.PreContent.AppendHtml(SelectButton);
                await output.GetChildContentAsync();
            }
        }
    }
}
