using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace EpamPageTests.Core
{
    /// </summary>
    /// Class for reading the parameters data for testing purposes
    /// </summary>
    internal static class DataReader
    {
        // JSON content read from the configuration file
        private static readonly string _jsonString = File.ReadAllText(Location.JsonTestData);

        // Singleton instance of the Data class
        private static Data? _data;

        // Method to read and yield search page parameters from the JSON data
        internal static IEnumerable<string> GetSearchPageParams()
        {
            foreach (string parameter in _data!.SearchPage)
            {
                yield return parameter;
            }
        }

        // Method to deserialize JSON data into a Data object
        internal static Data DeserializeData()
        {
            _data = JsonSerializer.Deserialize<Data>(_jsonString);

            return _data!;
        }
    }
}