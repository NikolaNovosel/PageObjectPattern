
namespace EpamPageTests.Core
{
    internal static class Location
    {
        // Path to directory of the executing assembly
        private static readonly string _baseDir = AppDomain.CurrentDomain.BaseDirectory;

        // Path to main project directory
        private static readonly string _projectPath = Path.GetFullPath(Path.Combine(_baseDir, @"..\..\.."));

        // Path to appsettings json
        internal static readonly string JsonAppSettings = Path.Combine(_projectPath, "appsettings.json");

        // Path to test data json
        internal static readonly string JsonTestData = Path.Combine(_projectPath, "testdata.json");
    }
}
