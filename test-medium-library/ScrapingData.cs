using HtmlAgilityPack;
using System.Net;
using System.Text;
using test_medium_library.Decorator;
using test_medium_library.Interfaces;

namespace test_medium_library
{
	public class ScrapingData : IScrapingData
	{

		private readonly IParsingHtmlDecorator _implementor;

		public ScrapingData(IParsingHtmlDecorator implementor)
		{
			_implementor = implementor;
		}

		/// <inheritdoc/>
		public async Task<string> CallUrl(string fullUrl)
		{
			try
			{
				var client = new HttpClient();
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
				client.DefaultRequestHeaders.Accept.Clear();
				var response = client.GetStringAsync(fullUrl);
				return await response;
			}
			catch(Exception)
			{
				throw new Exception("404 NotFound Exception, the Provided Url not exists.");
			}

			
		}

		/// <inheritdoc/>
		public virtual List<string> ParseHtml(string html)
		{
			try
			{
				var htmlDoc = new HtmlDocument();
				htmlDoc.LoadHtml(html);
				//Apply decorator pattern
				return _implementor.ParseItemOfListFromHtml(htmlDoc);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex.InnerException);
			}
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
	}
}
