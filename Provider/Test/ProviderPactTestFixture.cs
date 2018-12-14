using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using PactNet;
using Xunit;

namespace Provider.Test
{
    public class ProviderPactTestFixture
    {
        public readonly TestServer Server;
        public ProviderPactTestFixture()
        {

            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.UseStartup<Startup>();

            var config = new ConfigurationBuilder()
                // .AddJsonFile("appsettings.json", optional: true)
                .Build();
            webHostBuilder.UseConfiguration(config);

            Server = new TestServer(webHostBuilder);


            // var webHostBuilder = new WebHostBuilder();
            // webHostBuilder
            //     .UseStartup<Startup>()
            //     .UseUrls("http://localhost:9222")
            //     // .UseConfiguration(new ConfigurationBuilder()
            //     // .AddJsonFile("appsettings.json", optional: true)
            //     .Build().Run();
            // Server = new TestServer(webHostBuilder);
        }
    }
}