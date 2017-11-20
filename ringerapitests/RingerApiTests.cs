using System;
using Xunit;
using Shouldly;
using System.Collections;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using ringerapi;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ringerapitests;
using System.Linq;

namespace ringerapitests
{
    public class NoddyApiTests
    {
        [Fact]
        public async Task Available_Players_Should_Return_All_Available_Players()
        {
            //arrange
            var webHostBuilder = new WebHostBuilder();
            webHostBuilder.ConfigureServices(
                s => s.AddSingleton<IStartUpConfigurationService, TestStartupConfigurationService>());
            var server = new TestServer(webHostBuilder.UseStartup<Startup>());
            var client = server.CreateClient();
            //act
        
            var response = await client.GetAsync("/ringers");
            response.EnsureSuccessStatusCode();
            var responseList = await response.Content.ReadAsAsync<List<Player>>();

            //assert
            responseList.ShouldContain(TestStartupConfigurationService.DefaultListOfPlayers.First());
        }
    }
}

internal class TestStartupConfigurationService : IStartUpConfigurationService
{
    internal static List<Player> DefaultListOfPlayers = new List<Player>() { new Player(1, "Sean") };

    Func<List<Player>> _noddyRingerList = () => DefaultListOfPlayers;

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    }

    public void ConfigureEnvironment(IHostingEnvironment env)
    {
        env.EnvironmentName = "Test";
    }

    public void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddSingleton(typeof(Func<List<Player>>), _noddyRingerList);
    }
}

