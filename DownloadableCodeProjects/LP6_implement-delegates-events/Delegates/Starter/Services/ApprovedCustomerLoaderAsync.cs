using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Delegates;

public static class ApprovedCustomersLoaderAsync
{
    /*
    // The .csproj file needs to include the following ItemGroup element to copy the Config folder to the output directory

    <ItemGroup>
    <!-- Include all files in the Config folder and copy them to the output directory -->
    <Content Include="Config\**\*">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    </ItemGroup>
    */

    private static readonly string ConfigFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config", "ApprovedCustomers.json");

    public static async Task<List<ApprovedCustomer>> LoadApprovedNamesAsync()
    {
        if (!File.Exists(ConfigFilePath))
        {
            throw new FileNotFoundException($"Configuration file not found: {ConfigFilePath}");
        }

        var json = await File.ReadAllTextAsync(ConfigFilePath);
        var config = await JsonSerializer.DeserializeAsync<ApprovedCustomersConfig>(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        return config?.ApprovedNames ?? new List<ApprovedCustomer>();
    }

    private class ApprovedCustomersConfig
    {
        public List<ApprovedCustomer> ApprovedNames { get; set; } = new List<ApprovedCustomer>();
    }

    public class ApprovedCustomer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
