using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Day24_Lesson_Part1.CustomHelpers
{
    [HtmlTargetElement("email",TagStructure=TagStructure.WithoutEndTag)]
    public class EmailTagHelper:TagHelper
    {
    
        public string MailTo { get; set; }
        private const string EmailDomain = "code.edu.az";
        public string To { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string email=$"{MailTo}@{EmailDomain}";
            output.Attributes.SetAttribute("href", $"mailto:{email}");
            output.Content.SetContent($"{To} : {email}");
        }
    }
}
