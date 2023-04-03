using ASP_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Movies.TagHelpers
{
	public enum MovieDetailsType
	{
		Full,
		Modal
	}

	[HtmlTargetElement("a", Attributes = "movie")]
	public class MovieDetailsTagHelper : TagHelper
	{
		private readonly IUrlHelperFactory urlHelperFactory;

		public MovieDetailsTagHelper(IUrlHelperFactory urlHelperFactory)
		{
			this.urlHelperFactory = urlHelperFactory;
		}
		public Movie Movie { get; set; }
		public MovieDetailsType ModalType { get; set; }

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext Context { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(Context);


			output.TagName = "a";
			output.Attributes.Add("class", "btn btn-primary");

			string url = "";




			if (ModalType == MovieDetailsType.Full)
			{
				url = urlHelper.ActionLink("Detail", "Home", new { id = Movie.imdbID });
				var icon = new TagBuilder("i");

				if (Movie.Type == "movie")
					icon.AddCssClass("fa-solid fa-film");
				else if (Movie.Type == "game")
					icon.AddCssClass("fa-solid fa-gamepad");
				else
					icon.AddCssClass("fa-solid fa-tv");


				output.Content.AppendHtml(icon);
				output.Content.Append(" Detail");
			}
			else
			{
				url = urlHelper.ActionLink("DetailModal", "Home", new { id = Movie.imdbID });
				var icon = new TagBuilder("i");
				icon.AddCssClass("fa-solid fa-eye");

				output.Content.AppendHtml(icon);

				output.Attributes.Add("data-open-modal", true);
			}
			output.Attributes.Add("href", url);


		}
	}
}