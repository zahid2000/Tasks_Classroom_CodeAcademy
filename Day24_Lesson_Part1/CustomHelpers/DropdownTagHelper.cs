using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace Day24_Lesson_Part1.CustomHelpers
{
    //[HtmlTargetElement("div",ParentTag ="td",TagStructure =TagStructure.WithoutEndTag)]
    public class DropdownTagHelper:TagHelper
    {
      
        public string ItemsName { get; set; }
        public string Icons { get; set; }
        public string Colors { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder dropdown = new StringBuilder();
            var itemNameList = ItemsName.Split(',',' ');
            var itemIconList = Icons.Split(',',' ');
            var itemColorList = Colors.Split(',', ' ');
            output.Attributes.SetAttribute("class", "dropdown");
            dropdown.Append("<button class=\"btn text-warning bg-light btn-sm dropdown-toggle\"type=\"button\" " +
                                     "id=\"dropdownMenuButton1\"data-bs-toggle=\"dropdown\"aria-expanded=\"false\">" +
                                     "<i class=\"fa fa-cogs\"></i>" +
                             "</button>" +
                             "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton1\">");
            for (int i = 0; i < itemNameList.Length; i++)
            {
                dropdown.Append($"<li>" +
                                    $"<a class=\"dropdown-item\" href=\"#\">" +
                                    $"<i class=\"fa fa-{itemIconList[i]} text-{itemColorList[i]}\"></i> &nbsp; {itemNameList[i]}" +
                                    $"</a>" +
                                $"</li>");
            }
            dropdown.Append("</ul>");
            output.Content.SetHtmlContent(dropdown.ToString());
            


            base.Process(context, output);
        }
    }
}
