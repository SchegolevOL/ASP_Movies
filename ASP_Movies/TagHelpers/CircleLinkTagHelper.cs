using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP_Movies.TagHelpers
{
	public class CircleLinkTagHelper : TagHelper
	{
		public string Procent { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (Procent!=null)
			{
				Procent = Procent.Substring(0,2);
				
				
				output.TagName = "div";
				output.Content.AppendHtml($"<div class=\"m-c\">{Procent}<div/>");
				int procent = Int32.Parse(Procent);
				if (procent>0 && procent<=25)
				{
					output.AddClass("rotate_90", HtmlEncoder.Default);
				}else if (procent > 25 && procent <= 50)
				{
					output.AddClass("rotate_180", HtmlEncoder.Default);
				}
				else if (procent > 50 && procent <= 75)
				{
					output.AddClass("rotate_270", HtmlEncoder.Default);
				}
				else if (procent > 75)
				{
					output.AddClass("rotate_360", HtmlEncoder.Default);
				}
			}
			
			
		}
	}
}
