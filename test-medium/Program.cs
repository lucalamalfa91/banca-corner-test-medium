using test_medium_library;
using test_medium_library.Decorator;
using test_medium_library.Interfaces;

namespace test_medium 
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//istanziate my class to use Interface methods.
			IScrapingData scrapingData = new ScrapingData(new ComposerDecorator());
	
			var response = scrapingData.CallUrl(Addresses.ListOfComposers).Result;
			var stringComposerList = scrapingData.ParseHtml(response);

			// return the result in desktop folder as csv file.
			scrapingData.WriteToCsv(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), stringComposerList);
			
		}
	}
}