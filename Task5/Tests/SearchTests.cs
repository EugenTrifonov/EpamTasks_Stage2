using NUnit.Framework;
using Task5.GoogleCloud;

namespace Tests
{
    public class SearchTests:BaseTest
    {
        
        [Test]
        [Category("All")]
        public void SearchTest() 
        {
            SearchPage page = new SearchPage(_driver);

            var searchResultPage = page.Search("Google Cloud Platform Pricing Calculator");

            Assert.IsTrue(searchResultPage is SearchResultsPage);
        }

        [Test]
        [Category("All")]
        [Category("Smoke tests")]
        public void SearchCalculatorPage()
        {
            SearchPage page = new SearchPage(_driver);

            var calculatorPage = page.Search("Google Cloud Platform Pricing Calculator").ClickFirstResult();

            Assert.IsTrue(calculatorPage is CalculatorPage);
        }

    }
}
