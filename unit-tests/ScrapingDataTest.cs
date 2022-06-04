using System.Collections;
using Moq;
using test_medium;
using test_medium_library;
using test_medium_library.Decorator;
using test_medium_library.Interfaces;

namespace unit_tests
{
	public class ScrapingDataTest : BaseTest
	{
		[Theory]
		[InlineData("https://en.wikipedia.org/wiki/List_of_com")]
		[InlineData("https://en.wikipedia.org/wiki/List_of_composers_by_name")]
		public async Task CallUrl(string url)
		{
			try
			{
				var scrapingData = new Mock<ScrapingData>(new ComposerDecorator());
				await scrapingData.Object.CallUrl(url);
				//Assert Positive Test
				Assert.NotEmpty(await scrapingData.Object.CallUrl(url));
			}
			catch (Exception e)
			{
				//Assert in Exception test
				Assert.Equal("404 NotFound Exception, the Provided Url not exists.", e.Message);
			}
		}

		[Theory]
		[MemberData(nameof(TestDataGenerator.GetPersonFromDataGenerator), MemberType = typeof(TestDataGenerator))]
		public void StillAliveComposerTest(ComposerTest testDataGenerator)
		{
			try
			{
				var scrapingData = new ScrapingData(new ComposerDecorator());
				var aliveComposer = scrapingData.ParseHtml(testDataGenerator.StringHtml);
				//Assert Positive Test
				Assert.Equal(aliveComposer.Count, testDataGenerator.ExpectedComposer);
			}
			catch (Exception e)
			{
				//Assert in Exception test
				Assert.Equal("Response status code does not indicate success: 404 (Not Found).", e.Message);
			}
		}
	}

	public class ComposerTest
	{
		public string StringHtml { get; set; } = null!;
		public int ExpectedComposer { get; set; }
	}

	public class TestDataGenerator : IEnumerable<object[]>
	{
		public static IEnumerable<object[]> GetPersonFromDataGenerator()
		{
			yield return new object[]
			{
				new ComposerTest
				{
					StringHtml = @"<!DOCTYPE html>
<html class='client-nojs' lang='en' dir='ltr'>
<head>
<meta charset='UTF-8'/>
<title>List of composers by name - Wikipedia</title>
<script>document.documentElement.className='client-js';RLCONF={'wgBreakFrames':false,'wgSeparatorTransformTable':['',''],'wgDigitTransformTable':['',''],'wgDefaultDateFormat':'dmy','wgMonthNames':['','January','February','March','April','May','June','July','August','September','October','November','December'],'wgRequestId':'5431d611-57b3-47ed-ab86-c2d9eca1a431','wgCSPNonce':false,'wgCanonicalNamespace':'','wgCanonicalSpecialPageName':false,'wgNamespaceNumber':0,'wgPageName':'List_of_composers_by_name','wgTitle':'List of composers by name','wgCurRevisionId':1091156092,'wgRevisionId':1091156092,'wgArticleId':6921880,'wgIsArticle':true,'wgIsRedirect':false,'wgAction':'view','wgUserName':null,'wgUserGroups':['*'],'wgCategories':['CS1 maint: multiple names: authors list','Articles with short description','Short description is different from Wikidata','Dynamic lists','Commons category link is on Wikidata','Lists of composers'],'wgPageContentLanguage':'en','wgPageContentModel':'wikitext',
'wgRelevantPageName':'List_of_composers_by_name','wgRelevantArticleId':6921880,'wgIsProbablyEditable':true,'wgRelevantPageIsProbablyEditable':true,'wgRestrictionEdit':[],'wgRestrictionMove':[],'wgFlaggedRevsParams':{'tags':{'status':{'levels':1}}},'wgVisualEditor':{'pageLanguageCode':'en','pageLanguageDir':'ltr','pageVariantFallbacks':'en'},'wgMFDisplayWikibaseDescriptions':{'search':true,'nearby':true,'watchlist':true,'tagline':false},'wgWMESchemaEditAttemptStepOversample':false,'wgWMEPageLength':200000,'wgNoticeProject':'wikipedia','wgMediaViewerOnClick':true,'wgMediaViewerEnabledByDefault':true,'wgPopupsFlags':10,'wgULSCurrentAutonym':'English','wgEditSubmitButtonLabelPublish':true,'wgCentralAuthMobileDomain':false,'wgULSPosition':'interlanguage','wgULSisCompactLinksEnabled':true,'wgWikibaseItemId':'Q616660','GEHomepageSuggestedEditsEnableTopics':true,'wgGETopicsMatchModeEnabled':false};RLSTATE={'ext.globalCssJs.user.styles':'ready','site.styles':'ready','user.styles':'ready',
'ext.globalCssJs.user':'ready','user':'ready','user.options':'loading','ext.cite.styles':'ready','skins.vector.styles.legacy':'ready','ext.visualEditor.desktopArticleTarget.noscript':'ready','ext.wikimediaBadges':'ready','ext.uls.interlanguage':'ready','wikibase.client.init':'ready'};RLPAGEMODULES=['ext.cite.ux-enhancements','site','mediawiki.page.ready','skins.vector.legacy.js','mmv.head','mmv.bootstrap.autostart','ext.visualEditor.desktopArticleTarget.init','ext.visualEditor.targetLoader','ext.eventLogging','ext.wikimediaEvents','ext.navigationTiming','ext.cx.eventlogging.campaigns','ext.centralNotice.geoIP','ext.centralNotice.startUp','ext.gadget.ReferenceTooltips','ext.gadget.charinsert','ext.gadget.extra-toolbar-buttons','ext.gadget.refToolbar','ext.gadget.switcher','ext.centralauth.centralautologin','ext.popups','ext.uls.compactlinks','ext.uls.interface','ext.growthExperiments.SuggestedEditSession'];</script>
<script>(RLQ=window.RLQ||[]).push(function(){mw.loader.implement('user.options@1i9g4',function($,jQuery,require,module){mw.user.tokens.set({'patrolToken':'+\\','watchToken':'+\\','csrfToken':'+\\'});});});</script>
<link rel='stylesheet' href='/w/load.php?lang=en&amp;modules=ext.cite.styles%7Cext.uls.interlanguage%7Cext.visualEditor.desktopArticleTarget.noscript%7Cext.wikimediaBadges%7Cskins.vector.styles.legacy%7Cwikibase.client.init&amp;only=styles&amp;skin=vector'/>
<script async='' src='/w/load.php?lang=en&amp;modules=startup&amp;only=scripts&amp;raw=1&amp;skin=vector'></script>
<meta name='ResourceLoaderDynamicStyles' content=''/>
<link rel='stylesheet' href='/w/load.php?lang=en&amp;modules=site.styles&amp;only=styles&amp;skin=vector'/>
<meta name='generator' content='MediaWiki 1.39.0-wmf.13'/>
<meta name='referrer' content='origin'/>
<meta name='referrer' content='origin-when-crossorigin'/>
<meta name='referrer' content='origin-when-cross-origin'/>
<meta name='format-detection' content='telephone=no'/>
<meta property='og:title' content='List of composers by name - Wikipedia'/>
<meta property='og:type' content='website'/>
<link rel='preconnect' href='//upload.wikimedia.org'/>
<link rel='alternate' media='only screen and (max-width: 720px)' href='//en.m.wikipedia.org/wiki/List_of_composers_by_name'/>
<link rel='alternate' type='application/x-wiki' title='Edit this page' href='/w/index.php?title=List_of_composers_by_name&amp;action=edit'/>
<link rel='apple-touch-icon' href='/static/apple-touch/wikipedia.png'/>
<link rel='shortcut icon' href='/static/favicon/wikipedia.ico'/>
<link rel='search' type='application/opensearchdescription+xml' href='/w/opensearch_desc.php' title='Wikipedia (en)'/>
<link rel='EditURI' type='application/rsd+xml' href='//en.wikipedia.org/w/api.php?action=rsd'/>
<link rel='license' href='https://creativecommons.org/licenses/by-sa/3.0/'/>
<link rel='canonical' href='https://en.wikipedia.org/wiki/List_of_composers_by_name'/>
<link rel='dns-prefetch' href='//meta.wikimedia.org' />
<link rel='dns-prefetch' href='//login.wikimedia.org'/>
</head>
<body class='mediawiki ltr sitedir-ltr mw-hide-empty-elt ns-0 ns-subject mw-editable page-List_of_composers_by_name rootpage-List_of_composers_by_name skin-vector action-view skin-vector-legacy'><div id='mw-page-base' class='noprint'></div>
<div id='mw-head-base' class='noprint'></div>
<div id='content' class='mw-body' role='main'>
	<a id='top'></a>
	<div id='siteNotice'><!-- CentralNotice --></div>
	<div class='mw-indicators'>
	</div>
	<h1 id='firstHeading' class='firstHeading mw-first-heading'>List of composers by name</h1>
	<div id='bodyContent' class='vector-body'>
		<div id='siteSub' class='noprint'>From Wikipedia, the free encyclopedia</div>
		<div id='contentSub'></div>
		<div id='contentSub2'></div>
		
		<div id='jump-to-nav'></div>
		<a class='mw-jump-link' href='#mw-head'>Jump to navigation</a>
		<a class='mw-jump-link' href='#searchInput'>Jump to search</a>
		<div id='mw-content-text' class='mw-body-content mw-content-ltr' lang='en' dir='ltr'><div class='mw-parser-output'><p class='mw-empty-elt'>
</p>
<style data-mw-deduplicate='TemplateStyles:r1033289096'>.mw-parser-output .hatnote{font-style:italic}.mw-parser-output div.hatnote{padding-left:1.6em;margin-bottom:0.5em}.mw-parser-output .hatnote i{font-style:normal}.mw-parser-output .hatnote+link+.hatnote{margin-top:-0.5em}</style><div role='note' class='hatnote navigation-not-searchable plainlinks'>This is a <a href='/wiki/Wikipedia:WikiProject_Lists#Incomplete_lists' title='Wikipedia:WikiProject Lists'>dynamic list</a> and may never be able to satisfy particular standards for completeness. You can help by <a class='external text' href='https://en.wikipedia.org/w/index.php?title=List_of_composers_by_name&amp;action=edit'>adding missing items</a> with <a href='/wiki/Wikipedia:Reliable_sources' title='Wikipedia:Reliable sources'>reliable sources</a>.</div>
<p>This is a <b>list of composers by name</b>, alphabetically sorted by surname, then by other names. The list of <a href='/wiki/Composer' title='Composer'>composers</a> is by no means complete. It is not limited by classifications such as <a href='/wiki/Genre_(music)' class='mw-redirect' title='Genre (music)'>genre</a> or time period; however, it includes only music composers of significant fame, notability or importance who also have current Wikipedia articles. For lists of music composers by other classifications, see <a href='/wiki/Lists_of_composers' title='Lists of composers'>lists of composers</a>.  
</p><p>This list is not for arrangers or lyricists (see <a href='/wiki/List_of_music_arrangers' title='List of music arrangers'>list of music arrangers</a> and <a href='/wiki/Lyricist' title='Lyricist'>lyricists</a>), unless they are also composers.  Likewise, <a href='/wiki/Songwriter' title='Songwriter'>songwriters</a> are listed separately, for example in a <a href='/wiki/List_of_singer-songwriters' title='List of singer-songwriters'>list of singer-songwriters</a> and <a href='/wiki/List_of_Songwriters_Hall_of_Fame_inductees' title='List of Songwriters Hall of Fame inductees'>list of Songwriters Hall of Fame inductees</a>.
</p>
<div class='noprint' style='text-align:center;'><div role='navigation' id='toc' class='toc plainlinks hlist' aria-labelledby='tocheading' style='margin-left:auto;margin-right:auto; text-align:left;'>
<div id='toctitle' class='toctitle' style='text-align:center;display:inline-block;'><span id='tocheading' style='font-weight:bold;'>Directory&#58;&#160;</span></div>
<div style='margin:auto; display:inline-block;'>             
<ul><li><a href='#A'>A</a></li>
<li><a href='#B'>B</a></li>
<li><a href='#C'>C</a></li>
<li><a href='#D'>D</a></li>
<li><a href='#E'>E</a></li>
<li><a href='#F'>F</a></li>
<li><a href='#G'>G</a></li>
<li><a href='#H'>H</a></li>
<li><a href='#I'>I</a></li>
<li><a href='#J'>J</a></li>
<li><a href='#K'>K</a></li>
<li><a href='#L'>L</a></li>
<li><a href='#M'>M</a></li>
<li><a href='#N'>N</a></li>
<li><a href='#O'>O</a></li>
<li><a href='#P'>P</a></li>
<li><a href='#Q'>Q</a></li>
<li><a href='#R'>R</a></li>
<li><a href='#S'>S</a></li>
<li><a href='#T'>T</a></li>
<li><a href='#U'>U</a></li>
<li><a href='#V'>V</a></li>
<li><a href='#W'>W</a></li>
<li><a href='#X'>X</a></li>
<li><a href='#Y'>Y</a></li>
<li><a href='#Z'>Z</a></li>
<li><a href='#See_also'>See also</a></li>
<li><a href='#References'>References</a></li>
<li><a href='#External_links'>External links</a></li></ul>
</div></div></div>
<h2><span class='mw-headline' id='A'>A</span><span class='mw-editsection'><span class='mw-editsection-bracket'>[</span><a href='/w/index.php?title=List_of_composers_by_name&amp;action=edit&amp;section=1' title='Edit section: A'>edit</a><span class='mw-editsection-bracket'>]</span></span></h2>
<style data-mw-deduplicate='TemplateStyles:r998391716'>.mw-parser-output .div-col{margin-top:0.3em;column-width:30em}.mw-parser-output .div-col-small{font-size:90%}.mw-parser-output .div-col-rules{column-rule:1px solid #aaa}.mw-parser-output .div-col dl,.mw-parser-output .div-col ol,.mw-parser-output .div-col ul{margin-top:0}.mw-parser-output .div-col li,.mw-parser-output .div-col dd{page-break-inside:avoid;break-inside:avoid-column}</style><div class='div-col' style='column-width: 22em;'>
<ul><li><a href='/wiki/Michel_van_der_Aa' title='Michel van der Aa'>Michel van der Aa</a> (born 1970)</li>
<li><a href='/wiki/Thorvald_Aagaard' title='Thorvald Aagaard'>Thorvald Aagaard</a> (1877–1937)</li>
<li><a href='/wiki/Truid_Aagesen' title='Truid Aagesen'>Truid Aagesen</a> (fl. 1593–1625)</li>
<li><a href='/wiki/Heikki_Aaltoila' title='Heikki Aaltoila'>Heikki Aaltoila</a> (1905–1992)</li>
<li><a href='/wiki/Juhan_Aavik' title='Juhan Aavik'>Juhan Aavik</a> (1884–1982)Annamacharya</li>
<li><a href='/wiki/Evaristo_Felice_Dall%27Abaco' title='Evaristo Felice Dall&#39;Abaco'>Evaristo Felice Dall'Abaco</a> (1675–1742)</li>
<li><a href='/wiki/Joseph_Abaco' title='Joseph Abaco'>Joseph Abaco</a> (dall'Abaco) (1710–1805)</li>
<li><a href='/wiki/Antonio_Maria_Abbatini' title='Antonio Maria Abbatini'>Antonio Maria Abbatini</a> (c. 1595 – 1680)</li>
<li><a href='/wiki/Gamal_Abdel-Rahim' title='Gamal Abdel-Rahim'>Gamal Abdel-Rahim</a> (1924–1988)</li>
<li><a href='/wiki/Mohamed_Abdelwahab_Abdelfattah' title='Mohamed Abdelwahab Abdelfattah'>Mohamed Abdelwahab Abdelfattah</a> (born 1962)</li>
<li><a href='/wiki/Behzad_Abdi' title='Behzad Abdi'>Behzad Abdi</a> (born 1973)</li>
<li><a href='/wiki/Keiko_Abe' title='Keiko Abe'>Keiko Abe</a> (born 1937)</li>
<li><a href='/wiki/Mary_Anne_%C3%A0_Beckett' title='Mary Anne à Beckett'>Mary Anne à Beckett</a> (1817–1863)</li>
<li><a href='/wiki/Rosalina_Abejo' title='Rosalina Abejo'>Rosalina Abejo</a> (1922–1991)</li>
<li><a href='/wiki/Carl_Friedrich_Abel' title='Carl Friedrich Abel'>Carl Friedrich Abel</a> (1723–1787)</li>
<li><a href='/wiki/Clamor_Heinrich_Abel' title='Clamor Heinrich Abel'>Clamor Heinrich Abel</a> (1634–1696)</li>
<li><a href='/wiki/Ludwig_Abel' title='Ludwig Abel'>Ludwig Abel</a> (1835–1895)</li>
<li><a href='/wiki/Mark_Abel' title='Mark Abel'>Mark Abel</a> (born 1948)</li>
<li><a href='/wiki/Michael_Abels' title='Michael Abels'>Michael Abels</a> (born 1962)</li>
<li><a href='/wiki/Peter_Abelard' title='Peter Abelard'>Peter Abelard</a> (1079–1142)</li>
<li><a href='/wiki/Nicanor_Abelardo' title='Nicanor Abelardo'>Nicanor Abelardo</a> (1893–1934)</li>
<li><a href='/wiki/David_Abell_(composer)' title='David Abell (composer)'>David Abell</a> (died c.1576)</li>
<li><a href='/wiki/John_Abell' title='John Abell'>John Abell</a> (1653 – after 1724)</li>
<li><a href='/wiki/Walter_Abendroth' title='Walter Abendroth'>Walter Abendroth</a> (1896–1973)</li>
<li><a href='/wiki/Jan_H%C3%A5kan_%C3%85berg' title='Jan Håkan Åberg'>Jan Håkan Åberg</a> (1916–2012)</li>
<li><a href='/wiki/Lasse_%C3%85berg' title='Lasse Åberg'>Lasse Åberg</a> (born 1940)</li>
<li><a href='/wiki/Johann_Joseph_Abert' title='Johann Joseph Abert'>Johann Joseph Abert</a> (1832–1915)</li>
<li><a href='/wiki/Willoughby_Bertie,_4th_Earl_of_Abingdon' title='Willoughby Bertie, 4th Earl of Abingdon'>4th Earl of Abingdon</a> (Willoughby Bertie) (1740–1799)</li>
<li><a href='/wiki/Peter_Ablinger' title='Peter Ablinger'>Peter Ablinger</a> (born 1959)</li>
<li><a href='/wiki/Lora_Aborn' title='Lora Aborn'>Lora Aborn</a> (1907–2005)</li>",
					ExpectedComposer = 8
				}
			};
		}

		public IEnumerator<object[]> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}


