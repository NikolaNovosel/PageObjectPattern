using EpamPage;
using FluentAssertions;
using NUnit.Framework;

namespace EpamPageTests
{
    /// <summary>
    /// Test class for Insight page functionality
    /// </summary
    internal class InsightTest : Test
    {
        // Tests Insight page interactions and article consistency across pages
        [Test]
        public void TestCase4()
        {
            InsightsPage insightPage = new InsightsPage(Driver!)
                        .ClickInsight()
                        .SwipeCarousel();

            string mainPageArticleTextTrim = insightPage.GetMainPageArticleTextTrim();

            insightPage.ClickReadMore();

            mainPageArticleTextTrim.Should().Be(insightPage.GetInsideArticleText());
        }
    }
}
