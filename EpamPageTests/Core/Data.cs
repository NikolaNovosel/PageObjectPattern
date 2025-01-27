using System.Text.Json;
using System.Text.Json.Serialization;

namespace EpamPageTests.Core
{
    /// <summary>
    /// Class that represents test parameters data from a JSON file.
    /// </summary>
    internal class Data
    {
        // Constructor to initialize data properties from JSON
        public Data(string careersPage, List<string> searchPage)
        => (CareersPage, SearchPage) = (careersPage, searchPage);

        // Property for the careers page specified in the JSON
        [JsonPropertyName("careersPage")]
        public string CareersPage { get; }

        // Property for the search page parameters specified in the JSON
        [JsonPropertyName("searchPage")]
        public List<string> SearchPage { get; }
    }
}
