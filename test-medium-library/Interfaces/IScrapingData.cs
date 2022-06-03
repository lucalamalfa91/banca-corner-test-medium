namespace test_medium_library.Interfaces
{
	public interface IScrapingData
	{
		/// <summary>
		/// asynchronous task for call a specific Web url and retrieve the result as a string value.
		/// </summary>
		public Task<string> CallUrl(string fullUrl);

		/// <summary>
		/// method for parse the HTMLDocument.
		/// </summary>
		public List<string> ParseHtml(string html);

		/// <summary>
		/// method for export a list of string in a csv file.
		/// </summary>
		public void WriteToCsv(string path, List<string> links);
	}
}
