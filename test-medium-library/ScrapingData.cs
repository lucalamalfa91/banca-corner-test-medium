using System.Globalization;
using HtmlAgilityPack;
using System.Net;
using System.Text;
using test_medium_library.Interfaces;

namespace test_medium_library
{
	public class ScrapingData : IScrapingData
	{
		/// <inheritdoc/>
		public async Task<string> CallUrl(string fullUrl)
		{
			var client = new HttpClient();
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
			client.DefaultRequestHeaders.Accept.Clear();
			var response = client.GetStringAsync(fullUrl);
			return await response;
		}

		/// <inheritdoc/>
		public List<string> ParseHtml(string html)
		{
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);

			//implement decorator for getComposerList.
			var stringComposerList = GetStringComposerList(htmlDoc);

			return stringComposerList;
		}

		/// <inheritdoc/>
		public void WriteToCsv(string path, List<string> links)
		{
			var sb = new StringBuilder();
			foreach (var link in links)
			{
				sb.AppendLine(link);
			}
			//create csv file in a specified path.
			File.WriteAllText(Path.Combine(path, "result.csv"), sb.ToString());
		}

		#region private
		private static List<string> GetStringComposerList(HtmlDocument htmlDoc)
		{
			var htmlComposerList = htmlDoc.DocumentNode.Descendants("li")
				.Where(node => !node.GetAttributeValue("class", "").Contains("something")).ToList();

			List<string> stringComposerList = new List<string>();

			foreach (var composer in htmlComposerList)
			{
				if (composer.InnerHtml.Contains("title"))
					stringComposerList.Add(composer.InnerText);
			}

			return stringComposerList;
		}
		#endregion private
	}
}
