using EpamPage;
using EpamPageTests.Core;
using FluentAssertions;
using NUnit.Framework;

namespace EpamPageTests
{
    /// <summary>
    /// Test class for About page functionality
    /// </summary>
    internal class AboutTest : Test
    {
        // Tests About page interactions and file download
        [Test]
        public void TestCase3()
        {
            AboutPage aboutPage = new(Driver);
            aboutPage.ClickAbout();
            aboutPage.ScrollToEpamAtGlance();
            aboutPage.ClickDownload();

            AboutPageValidation.WaitForFileDownload().Should().BeTrue();
        }
    }
}
