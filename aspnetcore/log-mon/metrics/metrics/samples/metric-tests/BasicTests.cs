using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Telemetry.Testing.Metering;

// <snippet_TestClass>
public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    public BasicTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task Get_RequestCounterIncreased()
    {
        // Arrange
        var client = _factory.CreateClient();
        var meterFactory = _factory.Services.GetRequiredService<IMeterFactory>();
        var collector = new MetricCollector<double>(meterFactory,
            "Microsoft.AspNetCore.Hosting", "http-server-request-duration");

        // Act
        var response = await client.GetAsync("/");

        // Assert
        Assert.Contains("Hello OpenTelemetry!", await response.Content.ReadAsStringAsync());

        await collector.WaitForMeasurementsAsync(minCount: 1).WaitAsync(TimeSpan.FromSeconds(5));
        Assert.Collection(collector.GetMeasurementSnapshot(),
            measurement =>
            {
                Assert.Equal("http", measurement.Tags["scheme"]);
                Assert.Equal("GET", measurement.Tags["method"]);
                Assert.Equal("/", measurement.Tags["route"]);
            });
    }
}
// </snippet_TestClass>
