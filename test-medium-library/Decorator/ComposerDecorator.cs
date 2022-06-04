using HtmlAgilityPack;

namespace test_medium_library.Decorator
{
	/// Decorator class for getComposerList 
	public class ComposerDecorator : IParsingHtmlDecorator
	{

		/// <inheritdoc/>
		public List<string> ParseItemOfListFromHtml(HtmlDocument html)
		{
			//specific behavio for get ComposerList
			var stringComposerList = GetStringComposerList(html);

			return stringComposerList;
		}

		#region private
		private static List<string> GetStringComposerList(HtmlDocument htmlDoc)
		{
			var htmlComposerList = htmlDoc.DocumentNode.Descendants("li")
				.Where(node => !node.GetAttributeValue("class", "").Contains("something")).ToList();

			List<string> stringComposerList = new List<string>();

			foreach (var composer in htmlComposerList)
			{
				//Get only the row with title tag, and only the row with alive composer.
				//TODO: controllare se la condizione "(born" è abbastanza o se sono necessari altri vincoli (file input sporco.)
				if (composer.InnerHtml.Contains("title") && composer.InnerText.Contains("(born"))
					stringComposerList.Add(composer.InnerText);
			}

			return stringComposerList;
		}
		#endregion private
	}
}
