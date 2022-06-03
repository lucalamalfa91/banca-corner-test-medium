using test_medium_library;
using test_medium_library.Interfaces;

namespace test_medium 
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//istanziate my class to use Interface methods.
			IScrapingData scrapingData = new ScrapingData();
	
			var response = scrapingData.CallUrl(Addresses.ListOfComposers).Result;
			var stringComposerList = scrapingData.ParseHtml(response);

			//implement logic for filter properly the stringComposerList in a new class.

			// return the result in desktop folder as csv file.
			scrapingData.WriteToCsv(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), stringComposerList);
			
		}
	}
}