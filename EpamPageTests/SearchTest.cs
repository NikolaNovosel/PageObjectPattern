using EpamPage;
using EpamPageTests.Core;
using FluentAssertions;
using NUnit.Framework;

namespace EpamPageTests
{
    /// <summary>
    /// Test class for search functionality
    /// </summary>
    internal class SearchTest : Test
    {
        // Tests search results for different keywords
        [TestCaseSource(nameof(SearchPage))]
        public void TestCase2(string keyword)
        {
            SearchPage searchPage = new(Driver);
            searchPage.ClickMagnifierIcon();
            searchPage.SendKeysSearch(keyword);
            searchPage.ClickFindSearch();
            searchPage.ScroolToLastLink();

            if (keyword == "Cloud")
            {
                searchPage.HasLastLink().Should().BeTrue();
                searchPage.CheckIfAllLinksContainKeyword(keyword).Should().BeTrue();
            }

            if (keyword != "Cloud")
            {
                searchPage.HasLastLink().Should().BeTrue();
                searchPage.CheckIfAllLinksContainKeyword(keyword).Should().BeFalse();
            }
        }
    }
}
