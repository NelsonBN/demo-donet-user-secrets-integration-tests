using System.Text.Json;
using System.Threading.Tasks;
using Demo.Tests.Config;
using Xunit.Abstractions;

namespace Demo.Tests;

[Collection(nameof(IntegrationApiTestsFixtureCollection))]
public class DemoControllerTests
{
    private readonly IntegrationTestsFixture _testsFixture;
    private readonly ITestOutputHelper _output;

    public DemoControllerTests(
        IntegrationTestsFixture testsFixture,
        ITestOutputHelper output
    )
    {
        // Setup
        _testsFixture = testsFixture;
        _output = output;
    }


    [Fact]
    public async Task Property_FromUserSecret_DemoUserSicret()
    {
        // Arrange && Act
        var act = await _testsFixture.Client.GetAsync("Demo");
        var content = await act.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<string>(content);


        // Assert
        _output.WriteLine(response);

        act.EnsureSuccessStatusCode();
        response.Should()
            .Be("DemoUserSicret");
    }
}
