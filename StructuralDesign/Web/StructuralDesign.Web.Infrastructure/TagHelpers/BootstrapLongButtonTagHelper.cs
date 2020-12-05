using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StructuralDesign.Web.TagHelpers
{
    [HtmlTargetElement("input", Attributes = "bootstrap-long-button")]
    public class BootstrapLongButtonTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add(new TagHelperAttribute("class", "btn btn-primary btn-lg btn-block"));
            output.Attributes.RemoveAll("bootstrap-long-button");
        }
    }
}
