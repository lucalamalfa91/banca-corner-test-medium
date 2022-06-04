using HtmlAgilityPack;

namespace test_medium_library.Decorator
{
	public interface IParsingHtmlDecorator
	{
		/// <summary>
		/// method for parse the HTMLDocument.
		/// </summary>
		public List<string> ParseItemOfListFromHtml(HtmlDocument html);
	}
}
